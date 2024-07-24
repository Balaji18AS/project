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

public partial class Identify : System.Web.UI.Page
{
    SqlConnection con;
    
    
    SqlDataAdapter adp;
    DataTable dt;
    Random r;
    static string s;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            con = (SqlConnection)Application.Get("connection");
            Label2.Text = Session["mailid"].ToString();
            Label3.Text = Session["squestion"].ToString();

            if (!Page.IsPostBack)
            {
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
            LinkButton1.Enabled = false;
            showdata();
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == Session["sanswer"].ToString())
            Label1.Text = "Your Password Is:" + Session["password"].ToString();
        else
        {
            Label1.Text = "Type Correct Answer And Select Options....";
            LinkButton1.Enabled = false;
            showdata();
        }

    }
}
