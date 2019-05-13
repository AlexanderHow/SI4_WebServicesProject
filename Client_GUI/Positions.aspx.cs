using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VelibSOAP;

public partial class Positions : System.Web.UI.Page
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
                DropDownList1.Items.Add(li);
                DropDownList2.Items.Add(li);
            }
        }
    }
    protected void Selection_Change1(Object sender, EventArgs e)
    {
        string citynameU = DropDownList1.SelectedItem.Text;

        string cityname = citynameU.ToLowerInvariant();
        string response = client.GetStationsCity(cityname);
        string[] stationsA = response.Split(',');

        string result = client.GetPositions(cityname);
        string[] positionsA = result.Split(',');
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

                string[] lat = positionsA[i].Split(':');
                TableCell c2 = new TableCell();
                c2.Controls.Add(new LiteralControl(lat[1]));

                r.Cells.Add(c2);

                string[] lng = positionsA[i+1].Split(':');
                TableCell c3 = new TableCell();
                c3.Controls.Add(new LiteralControl(lng[1].Substring(0, lng[1].Length - 3)));

                r.Cells.Add(c3);

                Table1.Rows.Add(r);
                i += 2;
            }
        }
    }

    protected void Selection_Change2(Object sender, EventArgs e)
    {
        string citynameU = DropDownList2.SelectedItem.Text;

        string cityname = citynameU.ToLowerInvariant();
        string response = client.GetStationsCity(cityname);
        string[] stationsA = response.Split(',');
        string[] idT = { "0", "0" };

        foreach (string s in stationsA)
        { 
            if (s.Contains("number"))
            {
                idT = s.Split(':');
            }

            if (s.Contains("name") && !s.Contains("contract"))
            {
                string name = s.Substring(13);
                string[] nameCorrect = name.Split('\"');

                ListItem li = new ListItem();
                li.Text = nameCorrect[0].ToUpperInvariant();
                li.Value = idT[1];
                DropDownList3.Items.Add(li);
            }
        }
    }

    protected void Selection_Change3(Object sender, EventArgs e)
    {
        string id = DropDownList3.SelectedValue;
        id = id.Substring(1);
        string cityname = DropDownList2.SelectedItem.Text.ToLower();

        string result = client.GetPosition(id, cityname);

        string[] datas = result.Split(',');
        
        TableRow r = new TableRow();

        TableCell c = new TableCell();
        c.Controls.Add(new LiteralControl(DropDownList3.SelectedItem.Text));

        r.Cells.Add(c);

        string[] lat = datas[0].Split(':');
        TableCell c2 = new TableCell();
        c2.Controls.Add(new LiteralControl(lat[1]));

        r.Cells.Add(c2);

        string[] lng = datas[1].Split(':');
        TableCell c3 = new TableCell();
        c3.Controls.Add(new LiteralControl(lng[1].Substring(0, lng[1].Length - 3)));

        r.Cells.Add(c3);

        Table1.Rows.Add(r);
    }
}