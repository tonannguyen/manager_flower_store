﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Model;

namespace Web.UI
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["logined"] == null)
                Response.Redirect("~/Login.aspx");

            //string select
            string quantityDate     = "SELECT Sum(QuantityOfDate) FROM Revenues WHERE CONVERT(DATE, CreatedTime) = CONVERT(DATE, GETDATE())";
            string quantityLastWeek = "SELECT Sum(QuantityOfDate)" +
                                      " FROM Revenues" +
                                      " WHERE CONVERT(DATE, CreatedTime) >= DATEADD(day, -(DATEPART(dw, GETDATE()) + 6), CONVERT(DATE, GETDATE()))" +
                                      " AND CONVERT(DATE, CreatedTime) <  DATEADD(day, 1 - DATEPART(dw, GETDATE()), CONVERT(DATE, GETDATE()))";
            string quantityLastMonth = "SELECT Sum(QuantityOfDate)" +
                                      " FROM Revenues" +
                                      " WHERE CONVERT(DATE, CreatedTime) >= DATEADD(MONTH, DATEDIFF(MONTH, 31, CURRENT_TIMESTAMP), 0)" +
                                      " AND CONVERT(DATE, CreatedTime) < DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP), 0)";
            string quantityQuarter = "SELECT Sum(QuantityOfDate)" +
                                      " FROM Revenues" +
                                      " datepart(qq,CONVERT(DATE, GETDATE())) - datepart(qq,CONVERT(DATE, CreatedTime)) = 1" +
                                      " AND YearID = datepart(year,getdate())";
            string quntityYear = "SELECT Sum(QuantityOfDate) FROM Revenues WHERE CONVERT(DATE, CreatedTime) > DATEADD(year,-1,GETDATE())";
            lblDay.Text = getQuantity(quantityDate);
            lblLastWeek.Text = getQuantity(quantityLastWeek);
            lblLastMonth.Text = getQuantity(quantityLastMonth);
            lblQuarter.Text = getQuantity(quantityQuarter);
            lblYear.Text = getQuantity(quntityYear);            
        }

        protected string getQuantity(string q)
        {
            string total = "";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterDbContext"].ToString());
            try
            {
                con.Open();
                string query = q;
                SqlCommand cmd = new SqlCommand(query, con);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    bool success = dr.Read();
                    if (success)
                    {
                        total = dr.GetValue(0).ToString();
                    }
                }

            }
            catch
            {
            }
            finally
            {
                con.Close();
            }
            return total;
        }
    }
}