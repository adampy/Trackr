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
            Application.Run(new AuthenticationScreen());
        }
    }

    public class Stack
    {
        /// <summary>
        /// A stack is used to store the previous panels in the back button. This stack is specialised in Panel operations
        /// </summary>

        private int indx = -1;
        private Panel[] arr;


        public Stack(int maxSize)
        {
            this.arr = new Panel[maxSize];
        }

        public void Push(Panel item)
        {
            this.indx++;
            arr[indx] = item;
            item.BringToFront();
        }

        public object Pop()
        {
            Panel toReturn = this.arr[this.indx];
            this.indx--;
            toReturn.SendToBack();
            return toReturn;
        }

        public object Peek()
        {
            return this.arr[this.indx];
        }
     
    }
}
