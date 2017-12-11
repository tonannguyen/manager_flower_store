﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Model;



namespace Web.UI
{
    public partial class ListBill : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["logined"] != null)
            {
                load_listData();
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        private DataTable GetAllBill()
        {

            DataTable data = new DataTable();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterDbContext"].ToString());


            try
            {
                con.Open();
                string query = "select Bills.ID,Bills.EmployeeID,Bills.Type, SUM((Items.Quantity)*(Flowers.Price)) AS 'Total Bill' from Bills JOIN Items ON Bills.ID = Items.BillID JOIN Flowers ON Items.FlowerID = Flowers.ID GROUP BY Bills.ID,Bills.EmployeeID,Bills.Type";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }

            return data;
        }
        private void load_listData()
        {
            DataTable data = GetAllBill();
            if (Session["logined"] != null)
            {
              
                try
                {
                    gv_Bills.DataSource = data;
                    gv_Bills.DataBind();

                }
                catch
                {

                }

            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }

        }
	}
}



//ClassWriteBill cellData = new ClassWriteBill(
//	typeList.SelectedItem.ToString(),
//	flowerList.SelectedItem.ToString(),
//	quantity.Text,
//	price.InnerText,
//	totalPrice.InnerText
//	);
//ClassWriteBill cellData2 = new ClassWriteBill();
//listData.Add(cellData2);


//				for (int i = 1; i <= listData.Count; i++)
//				{
//					// Create new row and add it to the table.
//					TableRow tRow = new TableRow();
//tb_change.Rows.Add(tRow);
//TableCell type_cell = new TableCell();
//TableCell name_cell = new TableCell();
//TableCell quantity_cell = new TableCell();
//TableCell price_cell = new TableCell();
//TableCell total_price_cell = new TableCell();
//listData.ForEach(x => {
//						name_cell.Text = x.name;
//						type_cell.Text = x.type;
//						quantity_cell.Text = x.quantity;
//						price_cell.Text = x.price;
//						total_price_cell.Text = x.totalPrice;
//					});
//						tRow.Cells.Add(type_cell);
//						tRow.Cells.Add(name_cell);
//						tRow.Cells.Add(quantity_cell);
//						tRow.Cells.Add(price_cell);
//						tRow.Cells.Add(total_price_cell);
					
//				}