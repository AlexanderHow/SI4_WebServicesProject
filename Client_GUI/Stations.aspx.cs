using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VelibSOAP;

public partial class Stations : System.Web.UI.Page
{
    IntermediaryServiceClient client = new IntermediaryServiceClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        string cities = client.GetCities();
        string[] citiesA = cities.Split(',');
        citiesA[0] = citiesA[0].Substring(1);
        foreach (string s in citiesA)
        {
            if (s.Contains("name") && !s.Contains("commercial"))
            {
                string[] citynames = s.Split(':');
                string cityname = citynames[1].Substring(1, citynames[1].Length - 2);
                if (cityname.StartsWith("\""))
                {
                    cityname = cityname.Substring(1);
                }
                ListItem li = new ListItem();
                li.Text = cityname.ToUpperInvariant();
                li.Value = cityname;
                DropDownList.Items.Add(li);
            }
        }
    }

    protected void Selection_Change(Object sender, EventArgs e)
    {
        string citynameU = DropDownList.SelectedItem.Text;
        ItemsBulletedList3.Items.Clear();
        ItemsBulletedList4.Items.Clear();
        string cityname = citynameU.ToLowerInvariant();
        string response = client.GetStationsCity(cityname);
        string[] stationsA = response.Split(',');
        Boolean list = false;
        foreach (string s in stationsA)
        {
            if (s.Contains("name") && !s.Contains("contract"))
            {
                string name = s.Substring(13);
                string[] nameCorrect = name.Split('\"');
                ListItem li = new ListItem();
                li.Text = nameCorrect[0].ToUpperInvariant();
                li.Value = nameCorrect[0];
                if (list)
                {
                    ItemsBulletedList3.Items.Add(li);
                    list = false;
                }
                else
                {
                    ItemsBulletedList4.Items.Add(li);
                    list = true;
                }
            }
        }
    }
}