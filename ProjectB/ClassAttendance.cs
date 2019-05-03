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
    public partial class ClassAttendance : Form
    {
        public ClassAttendance()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=SAM-PC\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True");

        /// <summary>
        /// the function is inserting the class attendence data into its table
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "INSERT INTO ClassAttendance(AttendanceDate) VALUES ('" + dateTimePicker1.Value.ToString("yyyyMMdd") + "')";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Your data has been added successfully");
        }
        /// <summary>
        /// the function is closing the current form and opens the home form
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button2_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            this.Hide();
            hm.Show();
        }
    }
}
