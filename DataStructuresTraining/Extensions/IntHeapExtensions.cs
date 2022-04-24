using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataStructuresTraining.Models.Enums;

namespace DataStructuresTraining.Extensions
{
    public static class IntHeapExtensions
    {
        /// <summary>
        /// Returns the first element in the array and removes it from the heap
        /// The last node is set as root and then bubble it down in the heap.
        /// Minimum or Maximum value.
        /// </summary>
        /// <returns></returns>
        public static int Peek(this IntHeap heap)
        {
            if (heap.TreeSize == 0) throw new Exception();
            var root = heap.Elements[0];

            heap.Elements[0] = heap.Elements[^1];
            heap.Elements = heap.Elements.SkipLast(1).ToArray();
            heap.TreeSize--;
            heap.BubbleDown(0);

            return root;
        }

        private static void BubbleDown(this IntHeap heap, int elementIndex)
        {
            int[] childrenIndex = heap.GetChildren(elementIndex);

            if (childrenIndex.Length == 0) return;

            if (childrenIndex.Length > 1 && heap.Elements[childrenIndex[1]] < heap.Elements[childrenIndex[0]])
                heap.SwapElements(childrenIndex[0], childrenIndex[1]);

            int smallerChild = childrenIndex[0];
            int biggerChild = childrenIndex.Length > 1 ? childrenIndex[1] : childrenIndex[0];

            int selectedChild = smallerChild;

            switch (heap.Type)
            {
                case HeapType.MinHeap:
                    if (heap.Elements[smallerChild] < heap.Elements[elementIndex])
                        heap.SwapElements(smallerChild, elementIndex);
                    else return;
                    break;
                case HeapType.MaxHeap:
                    selectedChild = biggerChild;
                    if (heap.Elements[biggerChild] > heap.Elements[elementIndex])
                        heap.SwapElements(biggerChild, elementIndex);
                    else return;
                    break;
            }
            //Continues moving new element to top until reaching the root or failing comparison.
            heap.BubbleDown(selectedChild);
        }
        /// <summary>
        /// Returns the children of a node if they exist.
        /// </summary>
        /// <param name="parentIndex"></param>
        /// <returns></returns>
        private static int[] GetChildren(this IntHeap heap, int parentIndex)
        {
            int lastIndex = heap.TreeSize - 1;
            if (parentIndex < 0 || parentIndex > lastIndex) throw new Exception();
            if (parentIndex * 2 + 1 > lastIndex) return Array.Empty<int>();
            if (parentIndex == 0 && lastIndex >= 2) return new int[] { 1, 2 };

            int firstChild = parentIndex * 2 + 1;
            int lastChild = parentIndex * 2 + 2;

            if (lastChild > lastIndex) return new int[] { firstChild };
            else return new int[] { firstChild, lastChild };
        }
        /// <summary>
        /// Inserts and element in the end of the heap and bubble it up.
        /// </summary>
        /// <param name="newElement"></param>
        public static void InsertElement(this IntHeap heap, int newElement)
        {
            if (heap.TreeSize == heap.Elements.Length) return;
            if (heap.TreeSize == 0) heap.Elements[0] = newElement;
            else
            {
                heap.Elements[heap.TreeSize] = newElement;
                heap.BubbleUp(heap.TreeSize);
            }
            heap.TreeSize++;
        }
        /// <summary>
        /// Ordenates new element from bottom to root
        /// </summary>
        /// <param name="elementIndex"></param>
        private static void BubbleUp(this IntHeap heap, int elementIndex)
        {
            int parentIndex = elementIndex / 2;

            if (elementIndex < 1) return;

            switch (heap.Type)
            {
                case HeapType.MinHeap:
                    if (heap.Elements[elementIndex] < heap.Elements[parentIndex])
                        heap.SwapElements(elementIndex, parentIndex);
                    break;
                case HeapType.MaxHeap:
                    if (heap.Elements[elementIndex] > heap.Elements[parentIndex])
                        heap.SwapElements(elementIndex, parentIndex);
                    break;
            }
            //Continues moving new element to top until reaching the root or failing comparison.
            heap.BubbleUp(parentIndex);
        }

        private static void SwapElements(this IntHeap heap, int firstIndex, int secondIndex)
        {
            (heap.Elements[secondIndex], heap.Elements[firstIndex]) = (heap.Elements[firstIndex], heap.Elements[secondIndex]);
        }
        public static void PrintHeap(this IntHeap heap)
        {
            for (int i = 0; i < heap.Elements.Length; i++)
            {
                Console.Write(heap.Elements[i] + ", ");
            }
            Console.WriteLine("");
        }
    }
}
