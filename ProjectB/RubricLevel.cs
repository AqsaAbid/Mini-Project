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
    public partial class RubricLevel : Form
    {
        public int id;
        public RubricLevel()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=SAM-PC\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True");


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        /// <summary>
        /// the function is inserting the rubric level data into rubriclevel table
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "INSERT INTO RubricLevel(RubricId,Details,MeasurementLevel) VALUES ('" + comboBox1.SelectedValue + "','" + richTextBox1.Text + "','" + textBox1.Text + "')";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.ExecuteNonQuery();

            MessageBox.Show("Your data has been added successfully");
            con.Close();
        }
        /// <summary>
        /// the function is diplaying rubric level data into grid view
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "SELECT * FROM RubricLevel";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            con.Close();
        }
        /// <summary>
        /// the function is updating the rubric level data
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();

            string query = "UPDATE RubricLevel SET Details = '" + richTextBox1.Text + "' WHERE Id = '" + id + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Updated Successfully");
        }
        /// <summary>
        /// the function is deleting the rubric level data
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "DELETE FROM RubricId WHERE Id = '" + id + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Your record has deleted");
        }
        /// <summary>
        /// the function is closing current form and opens home form       /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button5_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            this.Hide();
            hm.Show();
        }
        /// <summary>
        /// the function is displaying the data on text boxes, of the row that is double clicked in data grid view so that it can be deleted or updated
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
            richTextBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }
        /// <summary>
        /// the function selects details and rubricid and displays it in combo box
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void RubricLevel_Load(object sender, EventArgs e)
        {
            con.Open();
            String query = "SELECT Id,Details,CloId from Rubric";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Details";
            comboBox1.ValueMember = "Id";
            con.Close();
        }
    }
}
