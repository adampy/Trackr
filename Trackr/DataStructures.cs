using System.Windows.Forms; // Used for the accessing "Panel" and "Button" classes
using System;

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
        /// <summary>
        /// A singly linked list class. The start node is stored as an attribute, and each node has a link to the next node and some data.
        /// </summary>
        private object[] array;
        private int length;
        private CustomListNode head;

        public CustomList(int maxCapacity = 0) {
            array = new object[maxCapacity];
            length = 0;
            head = new CustomListNode();
        }

        public void Add(object data) {
            CustomListNode toAdd = new CustomListNode();
            toAdd.data = data;
            toAdd.next = head;
            head = toAdd;
            length++;
        }

        public object Get(int index) {
            CustomListNode node = head;
            for (int i = 0; i < index; i++) {
                node = node.next;
            }
            return node.data;
        }

        public void Set(int index, object data) {
            CustomListNode node = head;
            for (int i = 0; i < index; i++) {
                node = node.next;
            }
            node.data = data;
        }

        public int GetLength() {
            return length;
        }
        
        public dynamic ToArray<T>() {
            T[] toReturn = new T[this.length];
            CustomListNode node = head;
            for (int i = 0; i < length; i++) {
                toReturn[i] = (T)node.data;
                node = node.next;
            }
            return toReturn;
        }
        public bool Contains(object element) {
            bool found = false;
            CustomListNode node = head;
            for (int i = 0; i < length; i++) {
                found = found || element.Equals(node.data);
                node = node.next;
            }
            return found;
        }
    }

    public class CustomListNode {
        public CustomListNode next;
        public object data;
    }
}
