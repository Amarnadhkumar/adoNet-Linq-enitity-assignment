using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            DataClasses1DataContext mydata = new DataClasses1DataContext();
            GridView1.DataSource = mydata.FootBalls;
            GridView1.DataBind();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            japandata();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            windata();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Drawdata();
        }
        private void japandata()
        {
            DataClasses1DataContext data = new DataClasses1DataContext();

            GridView1.DataSource = from football in data.FootBalls
                                   where football.TeamName1 == "Japan" || football.TeamName2 == "Japan"
                                   select football;
            GridView1.DataBind();
        }
        private void windata()
        {
            DataClasses1DataContext data = new DataClasses1DataContext();

            GridView1.DataSource = from football in data.FootBalls
                                   where football.Matchresult == "Win"
                                   select football;
            GridView1.DataBind();
        }
        private void Drawdata()
        {
            DataClasses1DataContext data = new DataClasses1DataContext();

            GridView1.DataSource = from football in data.FootBalls
                                   where football.Matchresult == "Draw"
                                   select football;
            GridView1.DataBind();
        }

    }
}