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

public partial class CommonDetails : System.Web.UI.Page
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
            Label2.Text = Session["accountno"].ToString();
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
            if (RadioButtonList2.SelectedIndex == -1)
            {
                Label1.Text = "Select Duration .....";
            }
            //cmd = new SqlCommand("select accno from commondetails where accno=@accno", con);
            //cmd.Parameters.AddWithValue("@accno", Label2.Text);
            //rs = cmd.ExecuteReader();
            //bool b;
            //b = rs.Read();
            //rs.Close();
            //cmd.Dispose();
            //if (b)
            //{
            //    Label1.Text = "Common Details Already Inserted.....";
            //    return;
            //}
            cmd = new SqlCommand("select policyno from commondetails where policyno=@policyno ", con);
            cmd.Parameters.AddWithValue("@policyno", TextBox1.Text);
            bool b;
            rs = cmd.ExecuteReader();
            
                b= rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Please Type Correct(Another) Policy Number......";
                return;
            }
            cmd = new SqlCommand("select ebno from commondetails  where ebno=@ebno", con);
            cmd.Parameters.AddWithValue("@ebno", TextBox4.Text);
            rs = cmd.ExecuteReader();
            b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Please Type Correct(Another) EBConnection Number......";
                return;
            }
            cmd = new SqlCommand("select teleno from commondetails where teleno=@teleno ", con);
            cmd.Parameters.AddWithValue("@teleno", TextBox5.Text);
            rs = cmd.ExecuteReader();
            b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Please Type Correct(Another) TelePhone Number......";
                return;
            }
            cmd = new SqlCommand("insert into commondetails (accno,policyno,policyname,duration,dueamount,ebno,teleno,planname) values(@accno,@policyno,@policyname,@duration,@dueamount,@ebno,@teleno,@planname)", con);
            cmd.Parameters.AddWithValue ("@accno",Label2 .Text );
            cmd.Parameters.AddWithValue ("@policyno",TextBox1 .Text );
            cmd.Parameters.AddWithValue ("@policyname",TextBox2 .Text );
            cmd.Parameters.AddWithValue ("@duration",RadioButtonList2 .SelectedItem .Text );
            cmd.Parameters.AddWithValue ("@dueamount",TextBox3 .Text );
            cmd.Parameters.AddWithValue ("@ebno",TextBox4 .Text );
            cmd.Parameters.AddWithValue ("@teleno",TextBox5 .Text );
            cmd.Parameters.AddWithValue ("@planname",TextBox6 .Text );
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "Common Details Inserted.....";
            
            
            
      
        }
        catch (Exception ex)
        {
            if (rs != null) rs.Close();
            Label1.Text = ex.ToString();
        }
    }
}
