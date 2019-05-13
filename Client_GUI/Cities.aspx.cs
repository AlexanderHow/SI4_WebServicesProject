using System;
using System.Web.UI.WebControls;
using VelibSOAP;

public partial class Cities : System.Web.UI.Page
{
    IntermediaryServiceClient client = new IntermediaryServiceClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        string cities = client.GetCities();
        string[] citiesA = cities.Split(',');
        citiesA[0] = citiesA[0].Substring(1);
        Boolean list = false;
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
                if (list)
                {
                    ItemsBulletedList1.Items.Add(li);
                    list = false;
                } else
                {
                    ItemsBulletedList2.Items.Add(li);
                    list = true;
                }
            }
        }
    }
}