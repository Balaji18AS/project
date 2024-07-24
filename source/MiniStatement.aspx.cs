using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;


public partial class MiniStatement : System.Web.UI.Page
{
    SqlConnection con;
    SqlDataAdapter adp;
    SqlCommand cmd;

    SqlDataAdapter adp1;
    DataSet ds;
    DataTable dt;
    Random r;
    static string s;
    static int count = 0;

 
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            con = (SqlConnection)Application.Get("connection");
            Label2.Text = DateTime.Now.Year.ToString();
            if (!Page.IsPostBack)
            {
                count = 0;
                showdata();
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.ToString();
        }





    }
    void showdata()
    {
        adp = new SqlDataAdapter("select * from clientactivitycaptcha", con);
        dt = new DataTable();
        adp.Fill(dt);
        DropDownList1.DataSource = dt;
        DropDownList1.DataTextField = "ans";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, "Select");
        r = new Random();
        int no = r.Next(0, dt.Rows.Count);
        Image1.ImageUrl = "~/UploadImage/" + dt.Rows[no][0].ToString();
        Image2.ImageUrl = "~/UploadImage/" + dt.Rows[no][1].ToString();
        Image3.ImageUrl = "~/UploadImage/" + dt.Rows[no][2].ToString();
        s = dt.Rows[no][3].ToString();

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (DropDownList1.SelectedItem.Text == s)
        {

            LinkButton1.Enabled = true;
        }
        else
        {
            if (count == 3)
            {

                cmd = new SqlCommand("update newregistration set status='Blocked' where accno=@accno and loginname=@loginname", con);
                cmd.Parameters.AddWithValue("accno", Session["accountno"].ToString());
                cmd.Parameters.AddWithValue("loginname", Session["loginname"].ToString());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Response.Redirect("LockedForm.aspx");

            }
            count++;



            LinkButton1.Enabled = false;
            showdata();
        }
        
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (DropDownList2.SelectedIndex >= 1 && DropDownList2.SelectedIndex <= 3)
          //  MultiView1.ActiveViewIndex = DropDownList2.SelectedIndex-1;
        //else if (DropDownList2.SelectedIndex == 0 || DropDownList2.SelectedIndex == 4)
          //  MultiView1.ActiveViewIndex = -1;
        GridView1.Visible = false ;
        if (DropDownList2.SelectedIndex == 0)
        {
            //GridView1.Visible = false;
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            MultiView1.ActiveViewIndex = -1;
            

        }
        else if (DropDownList2 .SelectedIndex ==1)
        {
            TextBox3 .Text ="";
            TextBox4 .Text ="";
            MultiView1.ActiveViewIndex = 0;
        }
        else if (DropDownList2 .SelectedIndex ==2)
        {
            TextBox1.Text ="";
            TextBox2 .Text ="";
            TextBox4 .Text ="";
            MultiView1.ActiveViewIndex = 1;
        }
            else if (DropDownList2 .SelectedIndex ==3)
        {
                TextBox1.Text ="";
            TextBox2 .Text ="";
            TextBox3 .Text ="";
            MultiView1.ActiveViewIndex = 2;
        }
        else if (DropDownList2 .SelectedIndex ==4)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            MultiView1.ActiveViewIndex = -1;

        }
        
       

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            if (DropDownList2.SelectedIndex == 0)
            {
                Label1.Text = "Select Options.......";
                return;
            }
            if (DropDownList2.SelectedIndex == 1)
            {
                DateTime fdate = DateTime.Parse(TextBox1.Text);
                DateTime tdate = DateTime.Parse(TextBox2.Text);
                int n = fdate.CompareTo(tdate);//dt1 greater return positive
                //equal return 0,dt1 less return negative
                if (n > 0)
                {
                    Label1.Text = "ToDate Must Be GreaterThan FromDate......";
                    return;
                }
                DateTime dt = DateTime.Now;
                string s = dt.ToString("dd-MMM-yyyy");
                dt = DateTime.Parse(s);
                int n1 = tdate.CompareTo(dt);
                if (n1 > 0)
                {
                    Label1.Text = "ToDate Must Be LessThan "+s+ "......";
                    return;
                }

                bindgrid1();

            }
            else if (DropDownList2.SelectedIndex == 2)
            {
                bindgrid2();
            }
            else if (DropDownList2.SelectedIndex == 3)
            {
                bindgrid3();
            }
            else if (DropDownList2.SelectedIndex == 4)
            {
                bindgrid4();
            }

        }
        catch (Exception ex)
        {
          
            Label1.Text = ex.ToString();
        }
    }
    void bindgrid1()
    {
        
    

        try
        {
       

            //change coding

            GridView1.Visible = true;
            adp1 = new SqlDataAdapter("select type,wddate,amount from withdrawdeposit where accno=@accno and wddate>=@fdate and wddate<=@tdate", con);
            adp1.SelectCommand.Parameters.AddWithValue("@accno", Session["accountno"]);
            adp1.SelectCommand.Parameters.AddWithValue("@fdate", TextBox1.Text);
            adp1.SelectCommand.Parameters.AddWithValue("@tdate", TextBox2.Text);
            ds = new DataSet();
            adp1.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();


            //end change coding


         
           // Response.Redirect("MiniStatementCrystalReport.aspx");
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    void bindgrid2()
    {

         try
        {
          

        GridView1.Visible = true;
        adp1 = new SqlDataAdapter("select type,wddate,amount from withdrawdeposit where accno=@accno and month(wddate)=@mon and year(wddate)=@year ", con);
        adp1.SelectCommand.Parameters.AddWithValue("@accno", Session["accountno"]);
        adp1.SelectCommand.Parameters.AddWithValue("@mon", TextBox3.Text);
        adp1.SelectCommand.Parameters.AddWithValue("@year", Label2.Text);
        ds = new DataSet();
        adp1.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();



       
        }
         catch (Exception ex)
         {
             Label1.Text = ex.Message;
         }


    }

    void bindgrid3()
    {
         try
        {
           
        GridView1.Visible = true;
        adp1 = new SqlDataAdapter("select type,wddate,amount from withdrawdeposit where accno=@accno and  year(wddate)=@year", con);

        adp1.SelectCommand.Parameters.AddWithValue("@accno", Session["accountno"]);
        adp1.SelectCommand.Parameters.AddWithValue("@year", TextBox4.Text);
        ds = new DataSet();
        adp1.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();


       
        }
         catch (Exception ex)
         {
             Label1.Text = ex.Message;
         }

    }

    void bindgrid4()
    {

           try
        {
            
        GridView1.Visible = true;
        adp1 = new SqlDataAdapter("select type,wddate,amount from withdrawdeposit where accno=@accno", con);
        adp1.SelectCommand.Parameters.AddWithValue("@accno", Session["accountno"]);
       
        ds = new DataSet();
        adp1.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();


      
        }
           catch (Exception ex)
           {
               Label1.Text = ex.Message;
           }

    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        if (DropDownList2.SelectedIndex == 1)
        {
            bindgrid1();
        }
        else if (DropDownList2.SelectedIndex == 2)
        {
            bindgrid2();
        }
        else if (DropDownList2.SelectedIndex == 3)
        {
            bindgrid3();
        }
        else if (DropDownList2.SelectedIndex == 4)
        {
            bindgrid4();
        }

    }
    }


