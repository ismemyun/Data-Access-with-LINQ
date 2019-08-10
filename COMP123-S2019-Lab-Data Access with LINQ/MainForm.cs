using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP123_S2019_Lab_Data_Access_with_LINQ
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This is the event handler for the MainForm's FormClosing event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ToolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This is the event handler for the exitToolStripMenuItem Click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// This is the event handler for the aboutToolStripMenuItem Click evnet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.aboutForm.ShowDialog();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'sectionCDatabaseDataSet2.StudentTable' 資料表。您可以視需要進行移動或移除。
            this.studentTableTableAdapter.Fill(this.sectionCDatabaseDataSet2.StudentTable);

        }
        /// <summary>
        /// This is the event handler for the helpToolStripButton Click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            Program.aboutForm.ShowDialog();
        }

        /// <summary>
        /// This is the handler for ShowDataButton Click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowDataButton_Click(object sender, EventArgs e)
        {
            Program.studentInfoForm.Show();
            this.Hide();
            //var StudentList =
            //    from student in this.sectionCDatabaseDataSet2.StudentTable
            //    select student;
            //foreach (var student in StudentList.ToList())
            //{
            //    Debug.WriteLine("Student ID: " + student.StudentID +
            //        " Last Name: " + student.LastName);
            //}
        }

        private void StudentDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void StudentDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            //local scope aliases
            var rowIndex = StudentDataGridView.CurrentCell.RowIndex;
            var rows = StudentDataGridView.Rows;
            var columnCount = StudentDataGridView.ColumnCount;
            var cells = rows[rowIndex].Cells;
            string outputString = string.Empty;

            rows[rowIndex].Selected = true;
            for (int index = 0; index < columnCount; index++)
            {
                outputString += cells[index].Value.ToString() + " ";
            }
            SelectionLabel.Text = outputString;

            Program.student.id = int.Parse(cells[(int)StudentField.ID].Value.ToString());
            Program.student.StudentID = cells[(int)StudentField.STUDENT_ID].Value.ToString();
            Program.student.FirstName = cells[(int)StudentField.FIRST_NAME].Value.ToString();
            Program.student.LastName = cells[(int)StudentField.LAST_NAME].Value.ToString();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //configure the file dialog
            StudentSaveFileDialog.FileName = "Student.txt";
            StudentSaveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            StudentSaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            //open the file dialog
            var result = StudentSaveFileDialog.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                //open a stream to write
                using (StreamWriter outputString = new StreamWriter(
                    File.Open(StudentSaveFileDialog.FileName, FileMode.Create)))

                {
                    //write stuff to the file
                    outputString.WriteLine(Program.student.id);
                    outputString.WriteLine(Program.student.StudentID);
                    outputString.WriteLine(Program.student.FirstName);
                    outputString.WriteLine(Program.student.LastName);

                    //cleeanup
                    outputString.Close();
                    outputString.Dispose();

                }
            MessageBox.Show("File Saved SuccessFully!", "Saving...",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            //configure the file dialog
            StudentOpenFileDialog.FileName = "Student.txt";
            StudentOpenFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            StudentOpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            //open the file dialog
            var result = StudentOpenFileDialog.ShowDialog();
            if (result != DialogResult.Cancel)
            {

            }
            try
            {
                //Open the stream for reading
                using (StreamReader inputStream = new StreamReader(
                    File.Open(StudentOpenFileDialog.FileName, FileMode.Open)))
                {
                    Program.student.id = int.Parse(inputStream.ReadLine());
                    Program.student.StudentID = inputStream.ReadLine();
                    Program.student.FirstName = inputStream.ReadLine();
                    Program.student.LastName = inputStream.ReadLine();

                    //cleanup
                    inputStream.Close();
                    inputStream.Dispose();
                }
                ShowDataButton_Click(sender, e);
            }
            catch (IOException exception)
            {
                Debug.WriteLine("ERROR:" + exception.Message);
                MessageBox.Show("ERROR" + exception.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
