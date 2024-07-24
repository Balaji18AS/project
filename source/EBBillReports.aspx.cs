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
using System.Data.SqlClient ;

public partial class EBBillReports : System.Web.UI.Page
{
    
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter adp;
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
            Label3.Text = "";
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
        GridView1.Visible = false;
        Label3.Text = "";
        if (DropDownList2.SelectedIndex == 0 || DropDownList2.SelectedIndex ==3 )
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            MultiView1.ActiveViewIndex = -1;
        }
        else if (DropDownList2.SelectedIndex ==1)
        {
            MultiView1.ActiveViewIndex = 0;
            TextBox2.Text = "";
        }
        else if (DropDownList2.SelectedIndex == 2)
        {
            MultiView1.ActiveViewIndex = 1;
            TextBox1.Text = "";
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
             else if (DropDownList2.SelectedIndex == 1)
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

        }
        catch (Exception ex)
        {
          
            Label1.Text = ex.ToString();
        }
    }
    void bindgrid1()
    {
        GridView1.Visible = true;
        Label3.Text = "AccountNo:"+Session["accountno"].ToString();
        adp1 = new SqlDataAdapter("select  ebno,pdate,amount from ebdetails where accno=@accno and month(pdate)=@mon and year(pdate)=@year ", con);
        adp1.SelectCommand.Parameters.AddWithValue("@accno", Session["accountno"]);
        adp1.SelectCommand.Parameters.AddWithValue("@mon", TextBox1.Text);
        adp1.SelectCommand.Parameters.AddWithValue("@year", Label2.Text);
        ds = new DataSet();
        adp1.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }

    void bindgrid2()
    {
        GridView1.Visible = true;
        Label3.Text = "AccountNo:" + Session["accountno"].ToString();
        adp1 = new SqlDataAdapter("select  ebno,pdate,amount from ebdetails where accno=@accno and  year(pdate)=@year ", con);
       

        adp1.SelectCommand.Parameters.AddWithValue("@accno", Session["accountno"]);
        adp1.SelectCommand.Parameters.AddWithValue("@year", TextBox2.Text);
        ds = new DataSet();
        adp1.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }

    void bindgrid3()
    {
        GridView1.Visible = true;
        Label3.Text = "AccountNo:" + Session["accountno"].ToString();
        adp1 = new SqlDataAdapter("select  ebno,pdate,amount from ebdetails where accno=@accno  ", con);
       
        adp1.SelectCommand.Parameters.AddWithValue("@accno", Session["accountno"]);

        ds = new DataSet();
        adp1.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
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
     

    }

   
}


