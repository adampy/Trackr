using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trackr
{
    static class EntryPoint
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormController.auth = new AuthenticationScreen();
            FormController.auth.Show();

            Application.Run();
        }
    }

    public static class FormController {
        /// <summary>
        /// Static class that keeps references to the open windows. This allows windows to be closed once used to free up memory resources.
        /// </summary>
        public static AuthenticationScreen auth;
        public static StudentMainForm studentMain;
        public static TeacherMainForm teacherMain;
    }
}
