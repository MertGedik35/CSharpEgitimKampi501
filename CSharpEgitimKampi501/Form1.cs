using CSharpEgitimKampi501.Dtos;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi501
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Server = ASUS-PC\\MSSQL2022;initial Catalog = EgitimKampi501Db;integrated security = true");
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        {
            string query = "Select * from TblProduct";
            var values = await connection.QueryAsync<ResulProductDto>(query);
            dataGridView1.DataSource = values;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string query = "Insert into TblProduct (ProductName,ProductStock,ProductPrice,ProductCategory) values (@productName,@productStock,@productPrice,@productCategory)";
            var parameters = new DynamicParameters();
            parameters.Add("@productName", txtProductName.Text);
            parameters.Add("@productStock", txtProductStock.Text);
            parameters.Add("@productPrice", txtProductPrice.Text);
            parameters.Add("@productCategory", txtProductCategory.Text);
            await connection.ExecuteAsync(query, parameters);
            MessageBox.Show("Ürün Eklendi");
        }
    }
}
