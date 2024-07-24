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

public partial class ClientLogin : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    SqlDataAdapter adp;
    DataTable dt;
    Random r;
    static string s;
    static int count;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            con = (SqlConnection)Application.Get("connection");
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
        Image1.ImageUrl = "~/UploadImage/"+dt.Rows[no][0].ToString();
        Image2.ImageUrl = "~/UploadImage/"+dt.Rows[no][1].ToString();
        Image3.ImageUrl = "~/UploadImage/"+dt.Rows[no][2].ToString();
        s = dt.Rows[no][3].ToString();

    }
  //  static string pass="";
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        cmd = new SqlCommand("select * from newregistration where accno=@accno and loginname=@loginname", con);
        cmd.Parameters.AddWithValue("accno", TextBox1.Text);
        cmd.Parameters.AddWithValue("loginname", TextBox2.Text);
        rs = cmd.ExecuteReader();
        string status = "";
        if (rs.Read())
        {
            status = rs["status"].ToString().ToLower();
            rs.Close();
            cmd.Dispose();
        }
        else
        {
            rs.Close();
            cmd.Dispose();
            Label1.Text = "Invalid Account Number and LoginName....";
            return;
        }

        if (status.Equals("blocked"))
        {
            Label1.Text = "Your Status is Blocked.....";
            return;
        }

        if (DropDownList1.SelectedItem.Text == s)
        {

            LinkButton1.Enabled = true;
        }
        else
        {
            if (count == 3)
            {
                //  Label1.Text = "Your Status is Locked.So Please Contact Administrator....";

                cmd = new SqlCommand("update newregistration set status='Blocked' where accno=@accno and loginname=@loginname", con);
                cmd.Parameters.AddWithValue("accno", TextBox1.Text);
                cmd.Parameters.AddWithValue("loginname", TextBox2.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Response.Redirect("LockedForm.aspx");

            }
            count++;


            LinkButton1.Enabled = false;
            showdata();
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            if (TextBox3.Text == "")
            {
                Label1.Text = "Please Reagain Type Password.....";
                return;
            }
            cmd = new SqlCommand("select accno,loginname,password,status from newregistration where accno=@accno and loginname=@loginname and password=@password", con);
            cmd.Parameters.AddWithValue("@accno", TextBox1.Text);
            cmd.Parameters.AddWithValue("@loginname", TextBox2.Text);
            cmd.Parameters.AddWithValue("@password", TextBox3.Text);         
          
            rs = cmd.ExecuteReader();                  
            string status = "";
            if (rs.Read ())
            {
                status = rs["status"].ToString().ToLower();
                Session.Add("accountno", TextBox1.Text);
                Session.Add("loginname", TextBox2.Text);
                rs.Close();
                cmd.Dispose();
            }
            else
            {
                rs.Close();
                cmd.Dispose();
                LinkButton1.Enabled = false;
                showdata();
                Label1.Text = "Invalid AccountNumber And Username And Password Choose Common Activity";

            }

            if (status.Equals("blocked"))
            {
                Label1.Text = "Your Status is Blocked.So Contact Administrator......";
            }
            else
            {
                Response.Redirect("AmountTransfer.aspx");
            }

        }
        catch (Exception ex)
        {
            if (rs != null) rs.Close();
            Label1.Text = ex.ToString();
        }

    }
}
