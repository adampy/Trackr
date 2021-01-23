using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackr.Algorithms {
    public static class Sorts {
        public static T[] MergeSort<T>(T[] arr, bool ascending = true) {
            if (arr.Length == 1) {
                return arr;
            }

            int midpoint = (arr.Length + 1) / 2; // Assigning to int removes any fractional part
            T[] left = new T[midpoint];
            T[] right = new T[arr.Length - midpoint];

            for (int i = 0; i < arr.Length; i++) {
                if (i < midpoint) {
                    left[i] = arr[i];
                } else {
                    right[i - midpoint] = arr[i];
                }
            }

            T[] sortedLeft = MergeSort<T>(left, ascending);
            int leftIndx = 0;
            T[] sortedRight = MergeSort<T>(right, ascending);
            int rightIndx = 0;
            T[] fullySorted = new T[arr.Length];
            int sortedIndx = 0;

            while (true) {
                if (sortedLeft.Length == leftIndx && sortedRight.Length == rightIndx) {
                    break; // Array sorted
                }
                if (sortedLeft.Length == leftIndx && sortedRight.Length > rightIndx) {
                    // Add all the right items
                    fullySorted[sortedIndx] = sortedRight[rightIndx];
                    rightIndx++;
                } else if (sortedRight.Length == rightIndx && sortedLeft.Length > leftIndx) {
                    // Add all the left items
                    fullySorted[sortedIndx] = sortedLeft[leftIndx];
                    leftIndx++;
                } else {
                    // Compare the next items and add the larger one
                    if (ascending && ((ITask)sortedRight[rightIndx]).LargerThan((ITask)sortedLeft[leftIndx])) {
                        fullySorted[sortedIndx] = sortedLeft[leftIndx];
                        leftIndx++;
                    } else {
                        fullySorted[sortedIndx] = sortedRight[rightIndx];
                        rightIndx++;
                    }
                }
                sortedIndx++; // Sorted index increases on all conditions, so place here instead
            }
            return fullySorted;
        }
    }
}
