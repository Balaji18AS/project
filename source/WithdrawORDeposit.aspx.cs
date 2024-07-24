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

public partial class WithdrawORDeposit : System.Web.UI.Page
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
            Label3.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            con = (SqlConnection)Application.Get("connection");

            if (!Page.IsPostBack)
            {
                count = 0;
                autonumber();
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
    void autonumber()
    {
        cmd = new SqlCommand("select isnull(max(tno),0)+1 from withdrawdeposit ", con);
        TextBox1.Text = cmd.ExecuteScalar().ToString();
        cmd.Dispose();
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
            if (RadioButtonList2.SelectedIndex == 0)
            {
                cmd = new SqlCommand("select amount from amountdetails where accno=@accno", con);
                cmd.Parameters.AddWithValue("@accno", Label2.Text);
                rs = cmd.ExecuteReader();
                float amount = 0;
                if (rs.Read())
                {
                    amount = float.Parse(rs["amount"].ToString());
                    rs.Close();
                    cmd.Dispose();
                }
                else
                {
                    rs.Close();
                    cmd.Dispose();
                }
                if (amount < float.Parse(TextBox2.Text))
                {
                    Label1.Text = "Your Amount is  Very Low.So,Amount Not Withdraw,You Have To Entered Low Amount And Select The Object Captcha Option......";
                    binddata();
                    LinkButton1.Enabled = false;
                  
                    return;
                }
                cmd = new SqlCommand("update amountdetails set amount=amount-@amount where accno=@accno", con);
                cmd.Parameters.AddWithValue("@amount", TextBox2.Text);
                cmd.Parameters.AddWithValue("@accno", Label2.Text);
                int n = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (n != 0)
                {
                    cmd = new SqlCommand("insert into  withdrawdeposit(tno,accno,type,wddate,amount) values(@tno,@accno,@type,@wddate,@amount)", con);
                    cmd.Parameters.AddWithValue("@tno", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@accno", Label2.Text);
                    cmd.Parameters.AddWithValue("@type", "withdraw");
                    cmd.Parameters.AddWithValue("@wddate", Label3.Text);
                    cmd.Parameters.AddWithValue("@amount", TextBox2.Text);
                    cmd.ExecuteNonQuery();
                    Label1.Text = "Amount Successfully Withdraw.......";
                }

            }
            else if (RadioButtonList2.SelectedIndex == 1)
            {
                cmd = new SqlCommand("update amountdetails set amount=amount+@amount where accno=@accno", con);
                cmd.Parameters.AddWithValue("@amount", TextBox2.Text);
                cmd.Parameters.AddWithValue("@accno", Label2.Text);
                int n = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (n != 0)
                {
                    cmd = new SqlCommand("insert into  withdrawdeposit(tno,accno,type,wddate,amount) values(@tno,@accno,@type,@wddate,@amount)", con);
                    cmd.Parameters.AddWithValue("@tno", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@accno", Label2.Text);
                    cmd.Parameters.AddWithValue("@type", "deposit");
                    cmd.Parameters.AddWithValue("@wddate", Label3.Text);
                    cmd.Parameters.AddWithValue("@amount", TextBox2.Text);
                    cmd.ExecuteNonQuery();
                    Label1.Text = "Amount Successfully Deposit.......";
                }
            }
            else
            {
                Label1.Text = "Select Type And Choose  ObjectCaptcha Options ......"    ;
                binddata();
                LinkButton1.Enabled = false;
                return;
            }
        }

        catch (Exception ex)
        {
            if (rs != null) rs.Close();
            Label1.Text = ex.ToString();
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {  

    }
}
