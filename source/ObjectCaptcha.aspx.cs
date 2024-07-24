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
using System.Data.SqlClient ;

public partial class ObjectCaptcha : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;

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
        adp = new SqlDataAdapter("select * from admincheck", con);
        dt = new DataTable();
        adp.Fill(dt);
        DropDownList2.DataSource = dt;
        DropDownList2.DataTextField = "ans";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, "Select");
        r = new Random();
        int no = r.Next(0, dt.Rows.Count);
        Image2.ImageUrl = dt.Rows[no][0].ToString();
        Image3.ImageUrl = dt.Rows[no][1].ToString();
        Image4.ImageUrl = dt.Rows[no][2].ToString();
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

   
  
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            if (TextBox1.Text.ToLower() != TextBox5.Text.ToLower() &&TextBox2.Text.ToLower() != TextBox5.Text.ToLower() && TextBox3.Text.ToLower() != TextBox5.Text.ToLower() && TextBox4.Text.ToLower() != TextBox5.Text.ToLower())
            {
                Label1.Text = "Type Correct Options And Select Image....";
                return;
            }

            if (HiddenField1.Value == "")
            {
                Label1.Text = "Image Not Selected.....";
                return;
            }
               
                    cmd = new SqlCommand("insert into objectcaptcha(path,option1,option2,option3,option4,answer) values(@path,@option1,@option2,@option3,@option4,@answer)", con);
                    cmd.Parameters.AddWithValue("@path", HiddenField1 .Value );
                    cmd.Parameters.AddWithValue("@option1", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@option2", TextBox2.Text);
                    cmd.Parameters.AddWithValue("@option3", TextBox3.Text);
                    cmd.Parameters.AddWithValue("@option4", TextBox4.Text);
                    cmd.Parameters.AddWithValue("@answer", TextBox5.Text);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    Label1.Text = "Record Inserted......";
      


             

      
        
        }
        catch (Exception ex)
        {
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
        Image1.ImageUrl = "";
        HiddenField1.Value = "";

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            HiddenField1.Value = "";
            cmd = new SqlCommand("select count(*) from objectcaptcha", con);
            int no = int.Parse(cmd.ExecuteScalar().ToString());
            long l1 = DateTime.Now.Ticks;
            no = no + 1;
            string path1 = l1 + "_" + no + "_" + FileUpload1.FileName;
            FileUpload1.SaveAs(Server.MapPath("~/UploadImage/" + path1));
            Image1.ImageUrl = "~/UploadImage/" + path1;
            HiddenField1.Value = path1;
              
        }
        catch (Exception ex)
        {
            Label1.Text = ex.ToString();
        }

    }
}


