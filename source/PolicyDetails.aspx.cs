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

public partial class PolicyDetails : System.Web.UI.Page
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
            DateTime adate, ddate;
            adate = DateTime.Parse(Label3.Text);
            ddate = DateTime.Parse(TextBox3.Text);
            int no = adate.CompareTo(ddate);
            if (no > 0)
            {
                Label1.Text = "Enter Due Date Must Be GreaterThan Amount Payment Date....";
                return;
            }
            //cmd = new SqlCommand("select * from policydetails where  policyno=@policyno and month(ddate)>=month1 and month(ddate)<=month2", con);
            cmd = new SqlCommand("select amount from amountdetails where accno=@accno", con);
            cmd.Parameters.AddWithValue("@accno", Label2.Text);
            rs = cmd.ExecuteReader();
            float amount=0;
            if (rs.Read())
                amount = float.Parse (rs["amount"].ToString());
            rs.Close();
            cmd.Dispose();
            if (amount < float.Parse(TextBox4.Text))
            {
                Label1 .Text ="Amount Is Very Low,So Your Details Not Inserted.....";
                return ;
            }
            cmd=new SqlCommand ("update amountdetails set amount=amount-@amount where accno=@accno",con );
            cmd.Parameters.AddWithValue ("@amount",TextBox4 .Text );
            cmd.Parameters.AddWithValue ("@accno",Label2 .Text );
            int n=cmd.ExecuteNonQuery ();
            cmd.Dispose ();

            if (n!=0)
            {
                //cmd = new SqlCommand("select policyno from policydetails where accno=@accno and policyno=@policyno", con);
                //cmd.Parameters.AddWithValue("@accno", Label2.Text);
                //cmd.Parameters.AddWithValue("@policyno", TextBox1.Text);
                //rs = cmd.ExecuteReader();
                cmd=new SqlCommand ("insert into policydetails(accno,policyno,policyname,apdate,ddate,damount) values(@accno,@policyno,@policyname,@apdate,@ddate,@damount)",con );
                cmd.Parameters.AddWithValue ("@accno",Label2 .Text );
                cmd.Parameters.AddWithValue ("@policyno",TextBox1 .Text );
                cmd.Parameters.AddWithValue ("@policyname",TextBox2 .Text );
                cmd.Parameters.AddWithValue ("@apdate",Label3 .Text );
                cmd.Parameters.AddWithValue ("@ddate",TextBox3 .Text );
                cmd.Parameters.AddWithValue ("@damount",TextBox4 .Text );
               int n1= cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (n1 != 0)
                {
                    cmd = new SqlCommand("select isnull(max(tno),0)+1 from withdrawdeposit", con);
                    int tno = int.Parse(cmd.ExecuteScalar().ToString());
                    cmd.Dispose();
                    cmd = new SqlCommand("insert into withdrawdeposit (tno,accno,type,wddate,amount) values(@tno,@accno,@type,@wddate,@amount)", con);
                    cmd.Parameters.AddWithValue ("@tno",tno);
                    cmd.Parameters.AddWithValue ("@accno",Session ["accountno"]);
                    cmd.Parameters.AddWithValue ("@type","Policy");
                    cmd.Parameters.AddWithValue ("@wddate",Label3 .Text );
                    cmd.Parameters.AddWithValue ("@amount",TextBox4 .Text );
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                }
                Label1.Text = "Amount Paid........";


            }

            
        }
        catch (Exception ex)
        {
            if (rs != null) rs.Close();
            Label1.Text = ex.ToString();
        }
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        try
        {
            cmd = new SqlCommand("Select policyname,duration,dueamount from commondetails where policyno=@policyno", con);
            cmd.Parameters.AddWithValue("@policyno", TextBox1.Text);
            rs = cmd.ExecuteReader();
            if (rs.Read ())
            {
                TextBox2.Text = rs["policyname"].ToString();
                Label4.Text = rs["duration"].ToString();
                TextBox4.Text = rs["dueamount"].ToString();
                rs.Close();
                cmd.Dispose();
            }
            else 
            {
                Label1.Text = "Please Type Correct Policy Number........";

                rs.Close();
                cmd.Dispose();


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
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        Label4.Text = "";
    }
}
