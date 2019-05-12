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
                string cityname = s.Substring(9);
                string[] citynameCorrect = cityname.Split('\"');
                ListItem li = new ListItem();
                li.Text = citynameCorrect[0].ToUpperInvariant();
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
        ItemsBulletedList5.Items.Clear();
        ItemsBulletedList6.Items.Clear();
        string cityname = citynameU.ToLowerInvariant();
        string response = client.GetStationsCity(cityname);
        string[] stationsA = response.Split(',');
        int i = 0;
        foreach (string s in stationsA)
        {
            if (s.Contains("name") && !s.Contains("contract"))
            {
                string name = s.Substring(13);
                string[] nameCorrect = name.Split('\"');
                ListItem li = new ListItem();
                li.Text = nameCorrect[0].ToUpperInvariant();
                li.Value = nameCorrect[0];
                if (i == 0)
                {
                    ItemsBulletedList3.Items.Add(li);
                    i += 1;
                }
                else if (i == 1)
                {
                    ItemsBulletedList4.Items.Add(li);
                    i += 1;
                }
                else if (i == 2)
                {
                    ItemsBulletedList5.Items.Add(li);
                    i += 1;
                }
                else if (i == 3)
                {
                    ItemsBulletedList6.Items.Add(li);
                    i = 0;
                }
            }
        }
    }
}