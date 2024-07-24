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

public partial class AmountTransfer : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    SqlDataAdapter adp;
    DataTable dt;
    Random r=new Random ();
    static int count = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            con = (SqlConnection)Application.Get("connection");
            TextBox1.Text = Session["accountno"].ToString();
            TextBox4.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            if (!Page.IsPostBack)
            {
                binddata();
                count = 0;
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

        s="";
        RadioButtonList1.Items.Clear();
        adp=new SqlDataAdapter ("select * from objectcaptcha", con);
        dt = new DataTable();
        adp.Fill(dt);
        int n = r.Next(dt.Rows.Count);
        Image1.ImageUrl = "~/UploadImage/"+dt.Rows[n][0].ToString();
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
            if (TextBox1.Text == TextBox2.Text)
            {
                Label1.Text = "Type Another Account Number.....";
                return;
            }
            cmd = new SqlCommand("select accno from  accountholder where accno=@accno", con);
            cmd.Parameters.AddWithValue("@accno", TextBox2.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b == false)
            {
                Label1.Text = "Transfer Account Number  Not Found,Please Type Correct Account Number....";
                return;
            }
          
            float amount = 0;
            cmd = new SqlCommand("select amount from amountdetails where accno=@accno", con);
            cmd.Parameters.AddWithValue("@accno", TextBox1.Text);
            rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                amount = float.Parse(rs["amount"].ToString());
                rs.Close();
                cmd.Dispose();
            }
            else
            {
                Label1.Text = "Your Details Not Inserted In AmountDetails Table......";
                return;
            }
            if (amount < float.Parse(TextBox3.Text))
            {
                Label1.Text = "Your Amount Is Very Low,So Amount Not Transferred.......";
                return;
            }
            
            cmd = new SqlCommand("update amountdetails set amount=amount-@amount where accno=@accno", con);
            cmd.Parameters.AddWithValue("@amount",TextBox3 .Text );
            cmd.Parameters.AddWithValue("@accno",TextBox1 .Text );
            int no = cmd.ExecuteNonQuery();
            cmd.Dispose();
            if (no != 0)
            {
                cmd = new SqlCommand("insert into amounttransfer (fromaccount,toaccount,tamount,tdate) values(@fromaccount,@toaccount,@tamount,@tdate)", con);
                cmd.Parameters .AddWithValue ("@fromaccount",TextBox1 .Text );
                cmd.Parameters .AddWithValue ("@toaccount",TextBox2 .Text );
                cmd.Parameters .AddWithValue ("@tamount",TextBox3 .Text );
                cmd.Parameters .AddWithValue ("@tdate",TextBox4 .Text );
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = new SqlCommand("update amountdetails set amount=amount+@amount where accno=@accno", con);
                cmd.Parameters.AddWithValue("@amount", TextBox3.Text);
                cmd.Parameters.AddWithValue("@accno", TextBox2.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Label1.Text = "Amount Tranfer From " + TextBox1.Text + " Account Number To " + TextBox2.Text + " Account Number.....";
                    
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
           

            if (count == 3)
            {
                //  Label1.Text = "Your Status is Locked.So Please Contact Administrator....";

                cmd = new SqlCommand("update newregistration set status='Blocked' where accno=@accno and loginname=@loginname", con);
                cmd.Parameters.AddWithValue("accno", Session["accountno"].ToString());
                cmd.Parameters.AddWithValue("loginname", Session["loginname"].ToString());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Response.Redirect("LockedForm.aspx");

            }
            count++;


            LinkButton1.Enabled = false;
            binddata();
        }
    }
}
