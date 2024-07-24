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

public partial class ActivityCaptcha : System.Web.UI.Page
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
        Image4.ImageUrl = dt.Rows[no][0].ToString();
        Image5.ImageUrl = dt.Rows[no][1].ToString();
        Image6.ImageUrl = dt.Rows[no][2].ToString();
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

            if (HiddenField1.Value == "" || HiddenField2.Value == "" || HiddenField3.Value == "")
            {
                Label1.Text = "Image Not Selected.....";
                return;
            }
             
                cmd = new SqlCommand("insert into clientactivitycaptcha (path1,path2,path3,ans) values(@path1,@path2,@path3,@ans)", con);
               cmd.Parameters.AddWithValue ("@path1",HiddenField1 .Value  );
               cmd.Parameters.AddWithValue("@path2", HiddenField2.Value);
               cmd.Parameters.AddWithValue("@path3", HiddenField3.Value);
               cmd.Parameters.AddWithValue ("@ans",TextBox1 .Text );
               cmd.ExecuteNonQuery();
               cmd.Dispose();
               Label1.Text = "Record Inserted......";         
     }
        catch (Exception ex)
        {
            Label1.Text = ex.ToString();
        }

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        try
        {
            HiddenField1.Value = "";
            cmd = new SqlCommand("select count(*) from clientactivitycaptcha", con);
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
    protected void Button5_Click(object sender, EventArgs e)
    {
        try
        {
            HiddenField2.Value = "";
            cmd = new SqlCommand("select count(*) from clientactivitycaptcha", con);
            int no = int.Parse(cmd.ExecuteScalar().ToString());
            long l1 = DateTime.Now.Ticks;
            no = no + 2;
            string path2 = l1 + "_" + no + "_" + FileUpload2.FileName;
            FileUpload2.SaveAs(Server.MapPath("~/UploadImage/" + path2));
            Image2.ImageUrl = "~/UploadImage/" + path2;
            HiddenField2.Value = path2;
        }
        catch (Exception ex)
        {
            Label1.Text = ex.ToString();
        }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        try
        {
            HiddenField3.Value = "";
            cmd = new SqlCommand("select count(*) from clientactivitycaptcha", con);
            int no = int.Parse(cmd.ExecuteScalar().ToString());
            long l1 = DateTime.Now.Ticks;
            no = no + 3;
            string path3 = l1 + "_" + no + "_" + FileUpload3.FileName;
            FileUpload3.SaveAs(Server.MapPath("~/UploadImage/" + path3));
            Image3.ImageUrl = "~/UploadImage/" + path3;
            HiddenField3.Value = path3;
        }
        catch (Exception ex)
        {
            Label1.Text = ex.ToString();
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        HiddenField1.Value = "";
        HiddenField2.Value = "";
        HiddenField3.Value = "";
        Image1.ImageUrl = "";
        Image2.ImageUrl = "";
        Image3.ImageUrl = "";
        TextBox1.Text = "";

    }
}
