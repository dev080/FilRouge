using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Form4: Form
    {
        //SqlCommand sCommand;
        //SqlDataAdapter sAdapter;
        //SqlCommandBuilder sBuilder;
        //DataSet sDs;
        //DataTable sTable;
        //private SqlDataAdapter dataAdapter; //bouton2

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        //    string connectionString = "Data Source=.;Initial Catalog=FilRouge_essai_modif;Integrated Security=True";
        //    string sql = "SELECT * FROM Client";
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    connection.Open();

        //    sCommand = new SqlCommand(sql, connection);
        //    sAdapter = new SqlDataAdapter(sCommand);
        //    sBuilder = new SqlCommandBuilder(sAdapter);

        //    sDs = new DataSet();
        //    sAdapter.Fill(sDs, "Stores");
        //    sTable = sDs.Tables["Stores"];

        //    connection.Close();

        //    dataGridView1.DataSource = sDs.Tables["Stores"];
        //    //dataGridView1.ReadOnly = true;
        //    //save_btn.Enabled = false;
        //    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void button2_Click(object sender, EventArgs e)
        {
        //    try
        //    {

        //        // Specify a connection string. Replace the given value with a 
        //        // valid connection string for a Northwind SQL Server sample
        //        // database accessible to your system.
        //        String connectionString ="Integrated Security=SSPI;Persist Security Info=False;" +"Initial Catalog=Northwind;Data Source=localhost";

        //        // Create a new data adapter based on the specified query.
        //        dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

        //        // Create a command builder to generate SQL update, insert, and
        //        // delete commands based on selectCommand. These are used to
        //        // update the database.
        //        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

        //        // Populate a new data table and bind it to the BindingSource.
        //        DataTable table = new DataTable();
        //        table.Locale = System.Globalization.CultureInfo.InvariantCulture;
        //        dataAdapter.Fill(table);
        //        bindingSource1.DataSource = table;

        //        // Resize the DataGridView columns to fit the newly loaded content.
        //        dataGridView1.AutoResizeColumns(
        //            DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        //    }
        //    catch (SqlException)
        //    {
        //        MessageBox.Show("To run this example, replace the value of the " +
        //            "connectionString variable with a connection string that is " +
        //            "valid for your system.");
        //    }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
        }
    }
}
