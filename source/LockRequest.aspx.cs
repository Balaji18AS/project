using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class LockRequest : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
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
    //  static string pass="";


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        //  pass = TextBox3.Text;



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
        try
        {

            cmd = new SqlCommand("select * from newregistration where accno=@accno and loginname=@loginname ", con);
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
                Label1.Text = "Invalid Account Number and Login Name.......";
                return;
            }

            if (status.Equals("not blocked"))
            {
                Label1.Text = "Your Status is Not Blocked......";
                return;
            }


            cmd = new SqlCommand("select * from lrtable where accno=@accno and loginname=@loginname", con);
            cmd.Parameters.AddWithValue("accno", TextBox1.Text);
            cmd.Parameters.AddWithValue("loginname", TextBox2.Text);
            rs = cmd.ExecuteReader();
            bool  b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Lock Request Details Already Inserted....";
                return;
            }

            cmd = new SqlCommand("insert into lrtable values(@accno,@loginname,@rdate)", con);
            cmd.Parameters.AddWithValue("accno", TextBox1.Text);
            cmd.Parameters.AddWithValue("loginname", TextBox2.Text);
            cmd.Parameters.AddWithValue("rdate", DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt"));
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "Lock Request Details Inserted.....";






        }
        catch (Exception ex)
        {
            if (rs != null) rs.Close();
            Label1.Text = ex.ToString();
        }

    }
}
