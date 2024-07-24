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

public partial class AccountCreation : System.Web.UI.Page
{
    SqlConnection con;

    SqlDataAdapter adp;
    SqlDataReader rs;
    SqlCommand cmd;
    DataTable dt;
    Random r;
    static string s;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            con = (SqlConnection)Application.Get("connection");
            TextBox8.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            if (!Page.IsPostBack)
            {
                autonumber();
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
        DropDownList2.DataSource = dt;
        DropDownList2.DataTextField = "ans";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, "Select");
        r = new Random();
        int no = r.Next(0, dt.Rows.Count);
        Image1.ImageUrl = dt.Rows[no][0].ToString();
        Image2.ImageUrl = dt.Rows[no][1].ToString();
        Image3.ImageUrl = dt.Rows[no][2].ToString();
        s = dt.Rows[no][3].ToString();

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList2.SelectedItem.Text == s)
        {

            LinkButton1.Enabled = true;
        }
        else
        {
            LinkButton1.Enabled = false;
            showdata();
        }

    }

   
    void autonumber()
    {
        cmd = new SqlCommand("select isnull(max(accno),100)+1  from accountholder", con);
        TextBox1.Text = cmd.ExecuteScalar().ToString();
        cmd.Dispose();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            if (DropDownList1.SelectedIndex == 0 || RadioButtonList1.SelectedIndex == -1)
            {
                Label1.Text = "Select All Options......";
                return;
            }
            cmd = new SqlCommand("select accno from accountholder where accno=@accno", con);
            cmd.Parameters.AddWithValue("@accno", TextBox1.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Account Number Already Stored,Please Press Clear Button Display Another Account Number....";
                return;
            }
            cmd = new SqlCommand("select toid from mailinfo where toid=@toid", con);
            cmd.Parameters.AddWithValue("@toid", TextBox16.Text);
            rs = cmd.ExecuteReader();
            b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Type Another EmailID Because this EmailID Already Stored Another Account Holder.....";
                return;
            }
            
            string dob=TextBox3 .Text +"-"+DropDownList1 .SelectedItem.Text +"-"+TextBox4 .Text ;
            DateTime dt =DateTime .Parse (dob);
            cmd = new SqlCommand("insert into accountholder(accno,name,dob,occupation,address,city,pnumber,cfacility,odate,oamount,emailid,bname,branchname,baddress,bcity,bpnumber) values(@accno,@name,@dob,@occupation,@address,@city, @pnumber,@cfacility,@odate,@oamount,@emailid,@bname,@branchname,@baddress,@bcity,@bpnumber)", con);
            cmd.Parameters.AddWithValue ("@accno",TextBox1 .Text );
            cmd.Parameters.AddWithValue ("@name",TextBox2 .Text );
            cmd.Parameters.AddWithValue ("@dob",dt.ToString ("dd-MMM-yyyy"));
            cmd.Parameters.AddWithValue ("@occupation",TextBox5 .Text );
            cmd.Parameters.AddWithValue ("@address",TextBox6 .Text );
            cmd.Parameters.AddWithValue("@city", TextBox14.Text);
            cmd.Parameters.AddWithValue ("@pnumber",TextBox7 .Text );
            if (RadioButtonList1 .SelectedIndex ==0)
            cmd.Parameters.AddWithValue ("@cfacility",true );
            else if (RadioButtonList1 .SelectedIndex ==1)
                cmd.Parameters.AddWithValue ("@cfacility",false  );
 

            cmd.Parameters.AddWithValue ("@odate",TextBox8 .Text );
            cmd.Parameters.AddWithValue ("@oamount",TextBox9 .Text );
            cmd.Parameters.AddWithValue("@emailid", TextBox16.Text);
            cmd.Parameters.AddWithValue ("@bname",TextBox10 .Text );
            cmd.Parameters.AddWithValue ("@branchname",TextBox11 .Text );
            cmd.Parameters.AddWithValue ("@baddress",TextBox12 .Text );
            cmd.Parameters.AddWithValue("@bcity", TextBox15.Text);
            cmd.Parameters.AddWithValue ("@bpnumber",TextBox13 .Text );
            int no=cmd.ExecuteNonQuery();
            cmd.Dispose();
         
            if (no != 0)
            {
                cmd = new SqlCommand("insert into amountdetails (accno,amount) values(@accno,@amount)", con);
                cmd.Parameters.AddWithValue ("@accno",TextBox1 .Text );
                cmd.Parameters.AddWithValue ("@amount",TextBox9 .Text );
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Session.Add("ano", TextBox1.Text);
                Session.Add("toid", TextBox16.Text);
                Label1.Text = "New Account Creation <br>Your Account Number Send Your Mail......";
                Response.Redirect("SendAccountNo.aspx");
            }
          
        }
        catch (Exception ex)
        {
            if (rs != null)
                rs.Close();
            Label1.Text = ex.ToString();
        }


    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";
        TextBox10.Text = "";
        TextBox11.Text = "";
        TextBox12.Text = "";
        TextBox13.Text = "";
        TextBox14.Text = "";
        TextBox15.Text = "";
        DropDownList1.SelectedIndex = 0;
        RadioButtonList1.SelectedIndex = -1;
        autonumber();
        TextBox2.Focus();

    }
   
}
