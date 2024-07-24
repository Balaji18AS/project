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

public partial class SendAccountNo : System.Web.UI.Page
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
          TextBox1.Text = "Bank@gmail.Com";
       TextBox2.Text = Session["toid"].ToString();
           TextBox3.Text = Session["ano"].ToString();
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
        adp = new SqlDataAdapter("select * from admincheck", con);
        dt = new DataTable();
        adp.Fill(dt);
        DropDownList1.DataSource = dt;
        DropDownList1.DataTextField = "ans";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, "Select");
        r = new Random();
        int no = r.Next(0, dt.Rows.Count);
        Image1.ImageUrl = dt.Rows[no][0].ToString();
        Image2.ImageUrl = dt.Rows[no][1].ToString();
        Image3.ImageUrl = dt.Rows[no][2].ToString();
        s = dt.Rows[no][3].ToString();

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Text.ToLower() == s.ToLower())
        {
            Label1.Text = "Your Answer Is Correct ,Click Submit Button........";
           // DropDownList1.Enabled = false;
            LinkButton1.Enabled = true;
        }
        else
        {
            Label1.Text = "Select Correct Options......";
            LinkButton1.Enabled = false;
            showdata();
        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            cmd = new SqlCommand("select accno from mailinfo where accno=@accno", con);
       cmd.Parameters.AddWithValue("@accno", Session["ano"].ToString());
           // cmd.Parameters.AddWithValue("@accno", TextBox3.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Already Stored.....";
                return;
            }
            cmd = new SqlCommand("insert into mailinfo(fromid,toid,accno,subject) values(@fromid,@toid,@accno,@subject)", con);
            cmd.Parameters.AddWithValue ("@fromid",TextBox1 .Text );
            cmd.Parameters.AddWithValue ("@toid",TextBox2 .Text );
            cmd.Parameters.AddWithValue ("@accno",TextBox3 .Text );
            cmd.Parameters.AddWithValue ("@subject",TextBox4 .Text );
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "Successfully Send  Your Account Number......";
            

        }
        catch (Exception ex)
        {
            if (rs != null) rs.Close();
            Label1.Text = ex.ToString();
        }

    }
   
}
