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
                string cityname = s.Substring(9);
                string[] citynameCorrect = cityname.Split('\"');
                ListItem li = new ListItem();
                li.Text = citynameCorrect[0].ToUpperInvariant();
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