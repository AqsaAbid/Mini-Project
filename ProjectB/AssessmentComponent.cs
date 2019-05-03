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
    public partial class AssessmentComponent : Form
    {
        public int id;
        public AssessmentComponent()
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

            textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();


        }
        /// <summary>
        /// the function is inserting assessment component data into its table
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "INSERT INTO AssessmentComponent(Name,RubricId,TotalMarks,DateCreated,DateUpdated,AssessmentId) VALUES ('" + textBox1.Text + "','" + comboBox1.SelectedValue + "','" + textBox2.Text + "','" + DateTime.Now + "','" + DateTime.Now + "','" + comboBox2.SelectedValue + "')";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.ExecuteNonQuery();

            MessageBox.Show("Your data has been added successfully");
            con.Close();
        }
        /// <summary>
        /// the function is displaying assessment component data in grid view
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "SELECT * FROM AssessmentComponent";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            con.Close();
        }
        /// <summary>
        /// the function is updating assessment component data
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "UPDATE AssessmentComponent SET Name = '" + textBox1.Text + "', RubricId = '" + comboBox1.SelectedValue + "',TotalMarks = '" + textBox2.Text + "', DateCreated = '" + DateTime.Now + "',DateUpdated = '" + DateTime.Now + "', AssessmentId = '" + comboBox2.SelectedValue + "' WHERE Id = '" + id + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Updated Successfully");
        }
        /// <summary>
        /// the function is deleting assessment component data
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "DELETE FROM AssessmentComponent WHERE Id = '" + id + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Your record has deleted");
        }
        /// <summary>
        /// the function is selecting rubricid and assessemnt id and displays it in combo boxes
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void AssessmentComponent_Load(object sender, EventArgs e)
        {
            con.Open();
            String query = "SELECT Id,Title,DateCreated,TotalMarks,TotalWeightage from Assessment";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Title";
            comboBox2.ValueMember = "Id";
            String query1 = "SELECT Id,Details from Rubric";
            SqlDataAdapter sda1 = new SqlDataAdapter(query1, con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            comboBox1.DataSource = dt1;
            comboBox1.DisplayMember = "Title";
            comboBox1.ValueMember = "Id";


            con.Close();
        }
        /// <summary>
        /// the function is closing the current form and opens the open form
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button6_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            this.Hide();
            hm.Show();
        }
    }
}
