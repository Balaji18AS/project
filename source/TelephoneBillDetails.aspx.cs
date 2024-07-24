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

public partial class TelephoneBillDetails : System.Web.UI.Page
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
            Label2.Text = Session["accountno"].ToString();
            Label4.Text = DateTime.Now.ToString("dd-MMM-yyyy");
           
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
        Image1.ImageUrl = "~/UploadImage/" + dt.Rows[no][0].ToString();
        Image2.ImageUrl = "~/UploadImage/" + dt.Rows[no][1].ToString();
        Image3.ImageUrl ="~/UploadImage/" + dt.Rows[no][2].ToString();
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

            if (count == 3)
            {

                cmd = new SqlCommand("update newregistration set status='Blocked' where accno=@accno and loginname=@loginname", con);
                cmd.Parameters.AddWithValue("accno", Session["accountno"].ToString());
                cmd.Parameters.AddWithValue("loginname", Session["loginname"].ToString());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Response.Redirect("LockedForm.aspx");

            }
            LinkButton1.Enabled = false;
            showdata();
        }
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        try
        {
            cmd = new SqlCommand("select planname from commondetails where teleno=@teleno", con);
            cmd.Parameters.AddWithValue("@teleno", TextBox1.Text);
            rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                Label3.Text = rs["planname"].ToString();
                rs.Close();
                cmd.Dispose();
            }
            else 

            {
                Label3.Text = "";
                Label1.Text = "TelePhone Number Is InCorrect ,Please Type Correct TelePhone Number.....";
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

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
           
               cmd = new SqlCommand("select amount from amountdetails where accno=@accno", con);
            cmd.Parameters.AddWithValue("@accno", Label2.Text);
            rs = cmd.ExecuteReader();
            float amount=0;
            if (rs.Read())
                amount = float.Parse (rs["amount"].ToString());
            rs.Close();
            cmd.Dispose();
            if (amount < float.Parse(TextBox2.Text))
            {
                Label1 .Text ="Amount Is Very Low,So Your Details Not Inserted.....";
                return ;
            }
            cmd=new SqlCommand ("update amountdetails set amount=amount-@amount where accno=@accno",con );
            cmd.Parameters.AddWithValue ("@amount",TextBox2 .Text );
            cmd.Parameters.AddWithValue ("@accno",Label2 .Text );
            int n=cmd.ExecuteNonQuery ();
            cmd.Dispose ();

            if (n != 0)
            {
                cmd = new SqlCommand("insert into telephonedetails(accno,tnumber,planname,pdate,amount) values(@accno,@tnumber,@planname,@pdate,@amount)", con);
                cmd.Parameters.AddWithValue("@accno",Label2 .Text );
                cmd.Parameters.AddWithValue("@tnumber",TextBox1 .Text );
                cmd.Parameters.AddWithValue("@planname",Label3 .Text );
                cmd.Parameters.AddWithValue("@pdate",Label4 .Text );
                cmd.Parameters.AddWithValue("@amount",TextBox2 .Text );
                int n1 = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (n1 != 0)
                {
                    cmd = new SqlCommand("select isnull(max(tno),0)+1 from withdrawdeposit", con);
                    int tno = int.Parse(cmd.ExecuteScalar().ToString());
                    cmd.Dispose();
                    cmd = new SqlCommand("insert into withdrawdeposit (tno,accno,type,wddate,amount) values(@tno,@accno,@type,@wddate,@amount)", con);
                    cmd.Parameters.AddWithValue("@tno", tno);
                    cmd.Parameters.AddWithValue("@accno", Session["accountno"]);
                    cmd.Parameters.AddWithValue("@type", "TelePhone");
                    cmd.Parameters.AddWithValue("@wddate", Label4.Text);
                    cmd.Parameters.AddWithValue("@amount", TextBox2.Text);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                }
              
                Label1.Text = "Amount Paid.......";
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
    }
   
}
