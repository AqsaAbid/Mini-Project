using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectB
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        /// <summary>
        /// the function is closing the current form and opens the student form
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }
        /// <summary>
        /// the function is closing the current form and opens the clo form
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button2_Click(object sender, EventArgs e)
        {
            Cloo cl = new Cloo();
            this.Hide();
            cl.Show();
        }
        /// <summary>
        /// the function is closing the current form and opens the rubric form
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button3_Click(object sender, EventArgs e)
        {
            Rubric rb = new Rubric();
            this.Hide();
            rb.Show();
        }
        /// <summary>
        /// the function is closing the current form and opens the rubriclevel form
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button4_Click(object sender, EventArgs e)
        {
            RubricLevel rl = new RubricLevel();
            this.Hide();
            rl.Show();
        }
        /// <summary>
        /// the function is closing the current form and opens the assessment form
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button5_Click(object sender, EventArgs e)
        {
            Assessment aa = new Assessment();
            this.Hide();
            aa.Show();
        }
        /// <summary>
        /// the function is closing the current form and opens the assessment component form
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button6_Click(object sender, EventArgs e)
        {
            AssessmentComponent ac = new AssessmentComponent();
            this.Hide();
            ac.Show();

        }
        /// <summary>
        /// the function is closing the current form and opens the class attendance form
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button7_Click(object sender, EventArgs e)
        {
            ClassAttendance ca = new ClassAttendance();
            this.Hide();
            ca.Show();
        }
        /// <summary>
        /// the function is closing the current form and opens the student attendance form
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button8_Click(object sender, EventArgs e)
        {
            StudentAttendance sta = new StudentAttendance();
            this.Hide();
            sta.Show();
        }
    }
}
