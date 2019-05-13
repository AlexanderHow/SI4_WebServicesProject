using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VelibSOAP;

public partial class Disponibilites : System.Web.UI.Page
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
                string cityname = citynames[1].Substring(1, citynames[1].Length-2);
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

        string cityname = citynameU.ToLowerInvariant();
        string response = client.GetStationsCity(cityname);
        string[] stationsA = response.Split(',');

        int nbTotalVelib = 0;
        int tmp = 0;
        string dispo = client.GetNbBikesCity(cityname);
        dispo = dispo.Substring(2, dispo.Length - 3);
        string[] result = dispo.Split(',');
        foreach (string s in result)
        {
            tmp = Int32.Parse(s);
            nbTotalVelib += tmp;
        }

        Total.Text = "Nombre total de vélibs disponibles : " + nbTotalVelib;

        int i = 0;

        foreach (string s in stationsA)
        {
            if (s.Contains("name") && !s.Contains("contract"))
            {
                string name = s.Substring(13);
                string[] nameCorrect = name.Split('\"');

                TableRow r = new TableRow();

                TableCell c = new TableCell();
                c.Controls.Add(new LiteralControl(nameCorrect[0].ToUpperInvariant()));

                r.Cells.Add(c);

                TableCell c2 = new TableCell();
                c2.Controls.Add(new LiteralControl(result[i]));

                r.Cells.Add(c2);

                Table1.Rows.Add(r);
                i += 1;
            }
        }
    }
}