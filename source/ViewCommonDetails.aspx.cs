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

public partial class ViewCommonDetails : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    SqlDataAdapter adp;
    DataTable dt;
    Random r = new Random();
    static int count = 0;


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            DetailsView1.Visible = false;
            con = (SqlConnection)Application.Get("connection");

            if (!Page.IsPostBack)
            {
                count = 0;
                binddata();
            }
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


    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (RadioButtonList1.SelectedItem.Text.ToLower() == s.ToLower())
        {
            Label1.Text = "Your Option Is Correct ,So Click Submit Button.....";
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


            Label1.Text = "Your Option Is InCorrect ,So Select Correct Options.....";
            LinkButton1.Enabled = false;
            binddata();
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            DetailsView1.Visible = true;
            cmd = new SqlCommand("select * from commondetails where accno=@accno", con);
            cmd.Parameters.AddWithValue("@accno", Session["accountno"]);
            rs = cmd.ExecuteReader();
            DetailsView1.DataSource = rs;
            DetailsView1.DataBind();
            rs.Close();
            cmd.Dispose();

        }
        catch (Exception ex)
        {
            if (rs != null) rs.Close();
            Label1.Text = ex.ToString();
        }
    }
}
