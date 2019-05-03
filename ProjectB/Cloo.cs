using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjectB
{
    public partial class Cloo : Form
    {
        public int id;
        public Cloo()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=SAM-PC\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True");

        /// <summary>
        /// the function is displaying the data on text boxes, of the row that is double clicked in data grid view so that it can be deleted or updated
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }
        /// <summary>
        /// inserting the clo data in clo table
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            String query = "INSERT INTO Clo (Name,DateUpdated,DateCreated) VALUES ('" + textBox1.Text + "','" + DateTime.Now + "','" + DateTime.Now + "')";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Your data has been added successfully");


        }
        /// <summary>
        /// the function is displaying clo table data in data grid view
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "SELECT * FROM Clo";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            con.Close();
        }
        /// <summary>
        /// the function is updating the clo data
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();

            string query = "UPDATE Clo SET Name = '" + textBox1.Text + "',DateUpdated = '" + DateTime.Now + "' WHERE Id = '" + id + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Updated Successfully");
        }
        /// <summary>
        /// the function is deleting clo data from clo table
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
      
            
            string query2 = "DELETE FROM Rubric WHERE CloId = '"+ id +"'";
            SqlDataAdapter sda1 = new SqlDataAdapter(query2, con);
            sda1.SelectCommand.ExecuteNonQuery();
            string query = "DELETE FROM Clo WHERE Id = '" + id + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Your record has deleted");
        }
        /// <summary>
        /// the function is closing the current form of clo and opens the home page
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button5_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            this.Hide();
            hm.Show();
        }
    }
}
