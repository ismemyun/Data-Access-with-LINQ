using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace COMP123_S2019_Lab_Data_Access_with_LINQ
{
    public partial class StudentInfoForm : Form
    {
        public StudentInfoForm()
        {
            InitializeComponent();
        }

        private void StudentInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void StudentInfoForm_Activated(object sender, EventArgs e)
        {
            //try
            //{
            //    Open the stream for reading
            //    using (StreamReader inputStream = new StreamReader(
            //        File.Open("Student.txt", FileMode.Open)))
            //        {
            //            Program.student.id = int.Parse(inputStream.ReadLine());
            //            Program.student.StudentID = inputStream.ReadLine();
            //            Program.student.FirstName = inputStream.ReadLine();
            //            Program.student.LastName = inputStream.ReadLine();

            //            cleanup
            //        inputStream.Close();
            //            inputStream.Dispose();
            //        }
            //}
            //catch (IOException exception)
            //{
            //    Debug.WriteLine("ERROR:" + exception.Message);
            //    MessageBox.Show("ERROR" + exception.Message, "ERROR",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            IDTextBox.Text = Program.student.id.ToString();
            StudentIDTextBox.Text = Program.student.StudentID;
            FirstNameTextBox.Text = Program.student.FirstName;
            LastNameTextBox.Text = Program.student.LastName;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Program.mainForm.Show();
            this.Hide();
        }
    }
}
