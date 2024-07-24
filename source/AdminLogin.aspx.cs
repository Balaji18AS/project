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

public partial class AdminLogin : System.Web.UI.Page
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
        adp = new SqlDataAdapter("select * from admincheck", con);
        dt = new DataTable();
        adp.Fill(dt);
        DropDownList1.DataSource = dt;
        DropDownList1.DataTextField = "ans";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, "Select");
        r = new Random();
        int no = r.Next(0, dt.Rows.Count);
        Image1.ImageUrl = dt.Rows[no][0].ToString();
        Image2.ImageUrl = dt.Rows[no][1].ToString();
        Image3.ImageUrl = dt.Rows[no][2].ToString();
        s = dt.Rows[no][3].ToString();
        
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            if (DropDownList1.SelectedItem.Text == s)
            {
                if (FormsAuthentication .Authenticate (TextBox1 .Text ,TextBox2 .Text ))
                    Response.Redirect("AccountCreation.aspx");
                else
                {
                    Label1.Text = "Invalid  UserName And Password And<br> Display Another Image ,Select Correct Common Activities & Enter Correct Username  And Password....";
                    showdata();
                }


            }
            else
            {
                DropDownList1.SelectedIndex = 0;
               Label1 .Text ="Invalid Options.....";
                showdata();
            }
            
        }
        catch (Exception ex)
        {
            Label1.Text = ex.ToString();
        }

    }
}
