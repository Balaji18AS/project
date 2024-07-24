using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class AdminViewLockRequestDetails : System.Web.UI.Page
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

    void bindgrid()
    {
        adp = new SqlDataAdapter("select * from lrtable ", con);
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.Visible = true;
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {

            bindgrid();

        }
        catch (Exception ex)
        {
         
            Label1.Text = ex.ToString();
        }

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "uu")
            {

                int accno = int.Parse(GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Values[0].ToString());
                string loginname = GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Values[1].ToString();
                cmd = new SqlCommand("update newregistration set status='Not Blocked' where accno=@accno and loginname=@loginname", con);
                cmd.Parameters.AddWithValue("accno", accno);
                cmd.Parameters.AddWithValue("loginname", loginname);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = new SqlCommand("delete from lrtable where accno=@accno and loginname=@loginname", con);
                cmd.Parameters.AddWithValue("accno", accno);
                cmd.Parameters.AddWithValue("loginname", loginname);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                bindgrid();


            }
        }
        catch (Exception ex)
        {

            Label1.Text = ex.ToString();
        }

    }
}
