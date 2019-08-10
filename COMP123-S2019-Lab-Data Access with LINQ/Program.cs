using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP123_S2019_Lab_Data_Access_with_LINQ
{
    public static class Program  //change to public static 
    {
        public static MainForm mainForm;
        public static AboutForm aboutForm;
        public static Student student;
        public static StudentInfoForm studentInfoForm;
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mainForm = new MainForm();
            aboutForm = new AboutForm();
            student = new Student();
            studentInfoForm = new StudentInfoForm();

            Application.Run(new MainForm());
        }
    }
}
