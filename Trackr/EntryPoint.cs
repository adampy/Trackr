using System;
using System.Collections.Generic;
using System.Linq;
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

            /*FormController.auth = new AuthenticationScreen();
            FormController.auth.Show();*/

            APIHandler.SetAuthorizationHeader(WebRequestHandler.ConvertToBase64("hbushell1:password"));
            Student student = Task.Run<Student>(async () => await APIHandler.GetStudent(username: "hbushell1")).Result;
            FormController.studentMain = new StudentMainForm(student);
            FormController.studentMain.Show();

            Application.Run();
        }
    }

    public static class FormController {
        /// <summary>
        /// Static class that keeps references to the open windows. This allows windows to be closed once used to free up memory resources.
        /// </summary>
        public static AuthenticationScreen auth;
        public static StudentMainForm studentMain;
    }

    public class Stack
    {
        /// <summary>
        /// A stack is used to store the previous panels in the back button. This stack is specialised in Panel operations
        /// </summary>

        private int indx = -1;
        private Panel[] arr;
        private Button previousPanel;


        public Stack(int maxSize)
        {
            this.arr = new Panel[maxSize];
        }

        public void Push(Panel item)
        {
            this.indx++;
            arr[indx] = item;
            item.BringToFront();
            if (indx > 0) {
                previousPanel.Show();
                previousPanel.BringToFront();
            }
        }

        public object Pop()
        {
            Panel toReturn = this.arr[this.indx];
            this.indx--;
            toReturn.SendToBack();
            if (indx == 0) {
                previousPanel.Hide();
            }
            return toReturn;
        }

        public object Peek()
        {
            return this.arr[this.indx];
        }

        public void SetPreviousPanelButton(Button btn) {
            previousPanel = btn;
            previousPanel.BringToFront();
        }
     
    }
}
