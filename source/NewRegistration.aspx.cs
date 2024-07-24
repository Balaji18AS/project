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
public partial class NewRegistration : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    SqlDataAdapter adp;
    DataTable dt;
    Random r;
    static string s;
    static string pass, cpass;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            con = (SqlConnection)Application.Get("connection");
            //if (!Page.IsPostBack)
            //{
            //    binddatatable();
            //}
        }
        catch (Exception ex)
        {
            Label1.Text = ex.ToString();
        }

    }
    void binddatatable()
    {
        adp = new SqlDataAdapter("select * from clientactivitycaptcha", con);
        dt = new DataTable();
        adp.Fill(dt);
        DropDownList2.DataSource = dt;
        DropDownList2.DataTextField = "ans";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, "Select");
        r = new Random();
        int no = r.Next(0, dt.Rows.Count);
        Image1.ImageUrl = "~/UploadImage/"+dt.Rows[no][0].ToString();
        Image2.ImageUrl ="~/UploadImage/"+dt.Rows[no][1].ToString();
        Image3.ImageUrl ="~/UploadImage/"+dt.Rows[no][2].ToString();
        s = dt.Rows[no][3].ToString();
    }
 
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        try
        {
            cmd = new SqlCommand("select accno from newregistration where accno=@accno ", con);
            cmd.Parameters.AddWithValue("@accno", TextBox1.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Account  Number Already Inserted ......";
                return;
            }
            cmd = new SqlCommand("select name,dob,pnumber,address,city,emailid from accountholder where accno=@accno", con);
            cmd.Parameters.AddWithValue("@accno", TextBox1.Text);
            rs = cmd.ExecuteReader();
            if (rs.Read())
            {
                //2name,7age,8 pnumber ,10 address,11 city,
                TextBox2.Text = rs["name"].ToString();
                DateTime dt = DateTime.Parse(rs["dob"].ToString());
                int year = dt.Year;
                int cyear = DateTime.Now.Year;
                int age = cyear - year;
                TextBox7.Text = age.ToString();
                TextBox8.Text = rs["pnumber"].ToString();
                TextBox10.Text = rs["address"].ToString();
                TextBox11.Text = rs["city"].ToString();
                TextBox9.Text = rs["emailid"].ToString();
                

                rs.Close();
                cmd.Dispose();
                binddatatable();
            }
            else
            {
                rs.Close();
                cmd.Dispose();
                clear ();            
                Label1.Text = "Type Correct Account Number ......";
                
                
            }
        }
        catch (Exception ex)
        {
            if (rs != null) rs.Close();
            Label1.Text = ex.ToString();
        }


    }
    void clear()
    {
       
        TextBox2 .Text ="";
        TextBox3 .Text ="";
        TextBox4 .Text ="";
        TextBox5 .Text ="";
        TextBox6 .Text ="";
        TextBox7 .Text ="";
        TextBox8 .Text ="";
        TextBox9 .Text ="";
        TextBox10 .Text ="";
        TextBox11.Text ="";
        TextBox12.Text ="";
        TextBox13.Text ="";
        TextBox14.Text ="";
        TextBox1 .Focus ();
        DropDownList1 .SelectedIndex =0;
        DropDownList2 .SelectedIndex =0;
        RadioButtonList1 .SelectedIndex =-1 ;
        RadioButtonList2 .SelectedIndex =-1 ;
        Image1.ImageUrl = "";
        Image2.ImageUrl = "";
        Image3.ImageUrl = "";
        DropDownList2.Items.Clear();
   
    }
    
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            if (DropDownList1.SelectedIndex == 0 || RadioButtonList1.SelectedIndex == -1 || RadioButtonList2.SelectedIndex == -1)
            {
                Label1.Text = "Select All Options......";
                return;
            }
           
            pass = "";
            cpass = "";
            pass = TextBox4.Text;
            cpass = TextBox5.Text;
            cmd = new SqlCommand("insert into newregistration(accno,name,loginname,password,cpassword,fname,age,gender,mstatus,cnumber,mailid,address,city,pincode,country,squestion,sanswer,status) values(@accno,@name,@loginname,@password,@cpassword,@fname,@age,@gender,@mstatus,@cnumber,@mailid,@address,@city,@pincode,@country,@squestion,@sanswer,@status)", con);
            cmd.Parameters.AddWithValue ("@accno",TextBox1 .Text );
            cmd.Parameters.AddWithValue ("@name",TextBox2 .Text );
            cmd.Parameters.AddWithValue ("@loginname",TextBox3 .Text );
            if (pass != "" && cpass != "")
            {
                cmd.Parameters.AddWithValue("@password", pass);
                cmd.Parameters.AddWithValue("@cpassword", TextBox5.Text);
            }
            else
            {
                Label1.Text = "Record Cannot Inserted ,So Reagain Type Password And Confirm Password.....";
                return;
            }
           cmd.Parameters.AddWithValue ("@fname",cpass  );
            cmd.Parameters.AddWithValue ("@age",TextBox7 .Text );
            cmd.Parameters.AddWithValue ("@gender",RadioButtonList1 .SelectedItem .Text );
            cmd.Parameters.AddWithValue ("@mstatus",RadioButtonList2 .SelectedItem .Text );
            cmd.Parameters.AddWithValue ("@cnumber",TextBox8 .Text );
           cmd.Parameters.AddWithValue ("@mailid",TextBox9 .Text );
            cmd.Parameters.AddWithValue ("@address",TextBox10 .Text );
            cmd.Parameters.AddWithValue ("@city",TextBox11 .Text );
            cmd.Parameters.AddWithValue ("@pincode",TextBox12 .Text );
            cmd.Parameters.AddWithValue ("@country",TextBox13 .Text );
            cmd.Parameters.AddWithValue ("@squestion",DropDownList1 .SelectedItem .Text );
            cmd.Parameters.AddWithValue ("@sanswer",TextBox14 .Text );
            cmd.Parameters.AddWithValue("status", "Not Locked");
           cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "Record Inserted.....";
            
        }
        catch (Exception ex)
        {
            Label1.Text = ex.ToString();
        }

    }
   
protected void  LinkButton2_Click(object sender, EventArgs e)
{
    TextBox1 .Text ="";
     clear ();

}
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList2.SelectedItem.Text == s)
        {
            LinkButton1.Enabled = true;
        }
        else
        {
            LinkButton1.Enabled  = false;
            binddatatable();
        }
    }
}
