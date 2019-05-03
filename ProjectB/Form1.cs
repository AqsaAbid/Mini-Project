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
    public partial class Form1 : Form
    {
        public int id;
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=SAM-PC\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// this function is inserting the student data into its table
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "INSERT INTO Student (FirstName,LastName,Contact,Email,RegistrationNumber,Status) VALUES ('"+textBox1.Text+ "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Your data has been added successfully");

        }
        /// <summary>
        /// the function is displaying the student data in grid view
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "SELECT * FROM Student";
            SqlDataAdapter sda = new SqlDataAdapter(query , con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            con.Close();
        }
        /// <summary>
        /// the function is updating the student data
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            
            string query = "UPDATE Student SET FirstName = '"+textBox1.Text+"',LastName = '"+textBox2.Text+"',Contact = '"+textBox3.Text+"',Email = '"+textBox4.Text+"',RegistrationNumber = '"+textBox5.Text+"',Status = '"+textBox6.Text+"' WHERE Id = '"+ id +"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Updated Successfully");
        }
        /// <summary>
        /// the function is displaying the data on text boxes, of the row that is double clicked in data grid view so that it can be updated or deleted
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //string id1 = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
            //id = Convert.ToInt32(id1);
            id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        /// <summary>
        /// the function is deleting the student data
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "DELETE FROM Student WHERE Id = '" + id + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Your record has deleted");

        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            

        }

        private void button8_Click(object sender, EventArgs e)
        {
           
        }
        /// <summary>
        /// goes back to home page
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button5_Click_1(object sender, EventArgs e)
        {
            Home hm = new Home();
            this.Hide();
            hm.Show();
        }
    }
}
