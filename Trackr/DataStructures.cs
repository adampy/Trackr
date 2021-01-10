using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // Used for the accessing "Panel" and "Button" classes

namespace Trackr {

    public class PanelStack {
        /// <summary>
        /// A stack is used to store the previous panels in the back button. This stack is specialised in Panel operations.
        /// </summary>

        private int indx = -1;
        private Panel[] arr;
        private Button previousPanel;

        public PanelStack(int maxSize) {
            this.arr = new Panel[maxSize];
        }
        public void Push(Panel item) {
            this.indx++;
            arr[indx] = item;
            item.BringToFront();
            if (indx > 0) {
                previousPanel.Show();
                previousPanel.BringToFront();
            } else {
                previousPanel.Hide();
            }
        }
        public object Pop() {
            Panel toReturn = this.arr[this.indx];
            this.indx--;
            toReturn.SendToBack();
            if (indx == 0) {
                previousPanel.Hide();
            }
            return toReturn;
        }
        public object Peek() {
            return this.arr[this.indx];
        }
        public void SetPreviousPanelButton(Button btn) {
            previousPanel = btn;
            previousPanel.BringToFront();
        }
    }
    
    public class CustomList {
        private object[] array;
        private int length;

        public CustomList(int maxCapacity = 0) {
            array = new object[maxCapacity];
            length = 0;
        }

        public void Add(object data) {
            length++;
            if (length > array.Length) {
                // Make new array with an additional length
                object[] newArray = new object[length];
                for (int i = 0; i < array.Length; i++) {
                    // Copy all elements to new array
                    newArray[i] = array[i];
                }
                array = newArray; // Replace old array with new one
            }
            array[length - 1] = data; // Append new item
        }

        public object Get(int index) {
            return array[index];
        }

        public void Set(int index, object data) {
            array[index] = data;
        }

        public int GetLength() {
            return length;
        }
        
        public dynamic ToArray<T>() {
            T[] toReturn = new T[this.array.Length];
            for (int i = 0; i < this.array.Length; i++) {
                toReturn[i] = (T)this.array[i];
            }
            return toReturn;
        }
    }
}
