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

public partial class ChangePassword : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;


    SqlDataAdapter adp;
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
            

            if (!Page.IsPostBack)
            {
                showdata();
                count = 0;

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
 //   static string opass="", npass="", cpass="";

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
         //   if (opass == "")
             //   opass=TextBox2.Text;
            if (TextBox2.Text == ""||TextBox3.Text == "" || TextBox4.Text == "")// || opass =="")
            {
                Label1.Text = "Please Reagain Type OldPassword,New Password And ConfirmPassword.....";
                return;
            }
            cmd = new SqlCommand("select * from newregistration where mailid=@mailid and password=@password", con);
            cmd.Parameters.AddWithValue("@mailid", TextBox1.Text);
            cmd.Parameters.AddWithValue("@password", TextBox2.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b == false)
            {
                Label1.Text = "Your MailID And Password Is Invalid.So, Please Type Correct MailId And Password ,Select the Options ......";
                showdata();
                return;
            }
            else
            {

                cmd = new SqlCommand("update newregistration set password=@password ,cpassword=@cpassword where mailid=@mailid", con);
                cmd.Parameters.AddWithValue("@password", TextBox3.Text);
                cmd.Parameters.AddWithValue("@cpassword", TextBox4.Text);
                cmd.Parameters.AddWithValue("@mailid", TextBox1.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Label1.Text = "Your Password Changed.....";

            }


        }
        catch (Exception ex)
        {
            if (rs != null) rs.Close();
            Label1.Text = ex.ToString();
        }
    }
}
