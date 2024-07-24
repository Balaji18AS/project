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

public partial class ForgotPassword : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    SqlDataAdapter adp;
    DataTable dt;
    Random r = new Random();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            con = (SqlConnection)Application.Get("connection");

            if (!Page.IsPostBack)
                binddata();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.ToString();
        }

    }
    static string s;
    void binddata()
    {

        s = "";
        RadioButtonList1.Items.Clear();
        adp = new SqlDataAdapter("select * from objectcaptcha", con);
        dt = new DataTable();
        adp.Fill(dt);
        int n = r.Next(dt.Rows.Count);
        Image1.ImageUrl = "~/UploadImage/" + dt.Rows[n][0].ToString();
        RadioButtonList1.Items.Add(dt.Rows[n][1].ToString());
        RadioButtonList1.Items.Add(dt.Rows[n][2].ToString());
        RadioButtonList1.Items.Add(dt.Rows[n][3].ToString());
        RadioButtonList1.Items.Add(dt.Rows[n][4].ToString());
        s = dt.Rows[n][5].ToString();


    }
   
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            cmd = new SqlCommand("select squestion,sanswer,password from newregistration where mailid=@mailid", con);
            cmd.Parameters.AddWithValue("@mailid", TextBox1 .Text );
            rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                Session.Add("mailid", TextBox1.Text);
                Session.Add("squestion", rs["squestion"].ToString());
                Session.Add("sanswer", rs["sanswer"].ToString());
                Session.Add("password", rs["password"].ToString());

                rs.Close();
                cmd.Dispose();
                Response.Redirect("Identify.aspx");
            }
            else
            {
                rs.Close();
                cmd.Dispose();
                Label1.Text = "Type Correct ID And Select The Options.....";
                LinkButton1.Enabled = false;
                binddata();
            }
        }
        catch (Exception ex)
        {
            if (rs != null) rs.Close();
            Label1.Text = ex.ToString();
        }
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedItem.Text.ToLower() == s.ToLower())
        {
        
            LinkButton1.Enabled = true;
        }
        else
        {
            Label1.Text = "Your Option Is InCorrect ,So Select Correct Options.....";
            LinkButton1.Enabled = false;
            binddata();
        }
    }
}
