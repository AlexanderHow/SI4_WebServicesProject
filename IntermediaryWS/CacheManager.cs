using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IntermediaryWS
{
    class CacheManager
    {
        private string APYKEY = "030659a64d21952287040f96eba110fa0db31d7d";
        private string ROOTURL = "https://api.jcdecaux.com/vls/v1/";
        private string WRONGRQT = @"{ 'value' : 'Wrong request'}";
        private Dictionary<String, String> cache = new Dictionary<string, string>();
        private List<String> defaultRequestList = new List<string>();

        public CacheManager(List<String> defaultRqts)
        {
            this.defaultRequestList.AddRange(defaultRqts);
            intiCache();
        }

        private void intiCache()
        {
            WebRequest request = null;
            StreamReader reader = null;
            WebResponse response = null;
            Stream dataStream = null;
            string tmpUrl;
            foreach (string url in this.defaultRequestList)
            {
                tmpUrl = ROOTURL + url + "?apiKey=" + APYKEY;
                request = WebRequest.Create(tmpUrl);
                response = request.GetResponse();
                dataStream = response.GetResponseStream();
                reader = new StreamReader(dataStream);
                this.cache.Add(url, reader.ReadToEnd());
            }
            if (reader != null)
            {
                reader.Close();
            }
            if (response != null)
            {
                response.Close();
            }
        }

        public async Task<string> manageRequest(string baseUrl, Dictionary<string, string> additionalParams)
        {
            string result;
            //search in cache
            foreach (KeyValuePair<string, string> cachentry in this.cache)
            {
                if (baseUrl.StartsWith(cachentry.Key))
                {
                    result = await retrieveFromCache(cachentry.Key, baseUrl, additionalParams);
                    return result;
                }
            }
            result = await doRequest(baseUrl, additionalParams);
            return result;
        }

        //TODO : generalize request to optimize cache + return a retrieve on result
        private async Task<string> doRequest(string baseUrl, Dictionary<string, string> additionalParams)
        {
            //build url
            string url = ROOTURL + baseUrl + "?";
            foreach (KeyValuePair<string, string> entry in additionalParams)
            {
                url = url + entry.Key + "=" + entry.Value + "&";
            }
            url = url + "apiKey=" + APYKEY;

            //do the request to JCDC
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse(); //exist getAsyncResponse
            Console.WriteLine("Status: " + ((HttpWebResponse)response).StatusDescription);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            //add to cache result
            this.cache.Add(baseUrl, responseFromServer);

            return responseFromServer;
        }

        private async Task<string> retrieveFromCache(string key, string baseUrl, Dictionary<string, string> additionalParams)
        {
            string restUrl = baseUrl.Replace(key, "");
            string[] diffUrl = (restUrl.Contains("/")) ? restUrl.Remove(0, 1).Split('/') : new string[0];
            string cacheResult = this.cache[key];
            if (cacheResult.StartsWith("{")) //it's a jsonObject
            {
                return dealWithJsonObject(JObject.Parse(cacheResult), diffUrl, 0, additionalParams);
            }
            else if (cacheResult.StartsWith("[")) //it's a jsonArray
            {
                return dealWithJsonArray(JArray.Parse(cacheResult), diffUrl, 0, additionalParams);
            }
            else //it's a value
            {
                return dealWithValue(cacheResult, diffUrl, 0, additionalParams);
            }
        }

        private string dealWithValue(string cacheResult, string[] diffUrl, int v, Dictionary<string, string> additionalParams)
        {
            //si pas a fin de diffurl c'est wrong, ignore additional pas applied osef
            if (v >= diffUrl.Count())
            {
                return cacheResult;
            }
            else
            {
                return WRONGRQT;
            }
        }

        private string dealWithJsonArray(JArray jArrayFromCache, string[] diffUrl, int v, Dictionary<string, string> additionalParams)
        {
            //proceedNext pour chaque element, add le return dans une array si c'est pas une WrongRQT
            string result = "[ ";
            string tmp;
            foreach (JObject obj in jArrayFromCache)
            {
                tmp = dealWithJsonObject(obj, diffUrl, v, additionalParams);

                if (!tmp.Equals(WRONGRQT))
                {

                    result = result + tmp + ",";
                }
            }

            result = result.Remove(result.Length - 1);
            result = result + " ]";
            return result;
        }

        private string dealWithJsonObject(JObject jObjectFromCache, string[] diffUrl, int v, Dictionary<string, string> additionalParams)
        {
            //Apply amap additionalParam, maybe nor wanted if there are key of the same name at multiple levels !!!
            foreach (KeyValuePair<string, string> entry in additionalParams)
            {
                if (jObjectFromCache.ContainsKey(entry.Key)) //key correspond to a proprety
                {
                    if (!jObjectFromCache[entry.Key].ToString().Equals(entry.Value)) //wrong value of property WARNiNG case sensitive
                    {
                        //System.Diagnostics.Debug.WriteLine("1 "+ jObjectFromCache[entry.Key].ToString() + " " + entry.Value+ "\n");
                        return WRONGRQT;
                    }
                }
            }

            if (v < diffUrl.Count())
            {
                if (jObjectFromCache.ContainsKey(diffUrl[v])) //following of url correspond to a proprety
                {
                    return proceedToNextResult(jObjectFromCache[diffUrl[v]].ToString(), diffUrl, ++v, additionalParams);
                }
                else
                {
                    if (jObjectFromCache.Properties().First().Value.ToString().Equals(diffUrl[v])) //it correspond to the value of the first property aka the id
                    {
                        return dealWithJsonObject(jObjectFromCache, diffUrl, ++v, additionalParams);
                    }
                    else //wrong url regarding the cache => return bad request
                    {
                        return WRONGRQT;
                    }
                }
            }
            else //apply additionalParams and return
            {
                foreach (KeyValuePair<string, string> entry in additionalParams)
                {
                    if (jObjectFromCache.ContainsKey(entry.Key)) //key correspond to a proprety
                    {
                        if (!jObjectFromCache[entry.Key].ToString().Equals(entry.Value)) //wrong value of property WARNiNG case sensitive
                        {
                            return WRONGRQT;
                        }
                    }
                    /*else non strict ici
                    {
                        System.Diagnostics.Debug.WriteLine("4\n");
                        return WRONGRQT;
                    }*/
                }
                return jObjectFromCache.ToString();
            }

        }

        private string proceedToNextResult(string v1, string[] diffUrl, int v2, Dictionary<string, string> additionalParams)
        {
            if (v1.StartsWith("{")) //it's a jsonObject
            {
                return dealWithJsonObject(JObject.Parse(v1), diffUrl, v2, additionalParams);
            }
            else if (v1.StartsWith("[")) //it's a jsonArray
            {
                return dealWithJsonArray(JArray.Parse(v1), diffUrl, v2, additionalParams);
            }
            else //it's a value
            {
                return dealWithValue(v1, diffUrl, v2, additionalParams);
            }
        }
    }
}
