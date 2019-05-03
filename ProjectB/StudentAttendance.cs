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
 
    public partial class StudentAttendance : Form
    {
        public int id;
        public StudentAttendance()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=SAM-PC\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True");

        /// <summary>
        /// the function is inserting student attendence data into its table
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "INSERT INTO StudentAttendance(AttendanceId,StudentId,AttendanceStatus) VALUES ('" + comboBox1.SelectedValue + "','" + comboBox2.SelectedValue + "','" + textBox1.Text + "')";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.ExecuteNonQuery();

            MessageBox.Show("Your data has been added successfully");
            con.Close();
        }
        /// <summary>
        /// the function is displaying attendencedate,student registration no and attendence status in grid view
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "SELECT Student.RegistrationNumber,ClassAttendance.Attendancedate,StudentAttendance.AttendanceStatus from(StudentAttendance join ClassAttendance on ClassAttendance.Id = StudentAttendance.AttendanceId) join Student on Student.Id = StudentAttendance.StudentId";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
           
            con.Close();
        }
        /// <summary>
        /// the function slects the attendence date from classattendence and regno from student and displays it combo boxes on load event
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void StudentAttendance_Load(object sender, EventArgs e)
        {
            con.Open();
            String query = "SELECT Id,AttendanceDate from ClassAttendance";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "AttendanceDate";
            comboBox1.ValueMember = "Id";
            String query1 = "SELECT Id,RegistrationNumber from Student";
            SqlDataAdapter sda1 = new SqlDataAdapter(query1, con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            comboBox2.DataSource = dt1;
            comboBox2.DisplayMember = "RegistrationNumber";
            comboBox2.ValueMember = "Id";


            con.Close();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
            
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

        }
        /// <summary>
        /// the function is closing the current form and opens the home form
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button3_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            this.Hide();
            hm.Show();
        }
    }
}
