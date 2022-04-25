using DataStructuresTraining.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresTraining
{
    public static class SingleLinkedListsExtensions
    {
        public static SingleLinkListNode? Merge(this SingleLinkListNode? parent, SingleLinkListNode? newNode)
        {
            if (parent == null) return newNode ?? null;

            if (newNode?.val <= parent.val)
            {
                parent = new SingleLinkListNode(newNode.val, parent);
                parent.next = parent.next?.Merge(newNode.next);
            }
            else
                parent.next = parent.next?.Merge(newNode);

            return parent;
        }
        public static void PrintLinkedList(this SingleLinkListNode? list)
        {
            if (list == null) return;
            Console.WriteLine(list.val);
            PrintLinkedList(list.next);
        }
        public static SingleLinkListNode? AddTwoNumbers(this SingleLinkListNode? l1, SingleLinkListNode? l2, int remain = 0)
        {
            if (l1 == null && l2 == null)
                if (remain > 0) return AddTwoNumbers(new(remain), null);
                else return null;

            int curSumResult = (l1?.val ?? 0) + (l2?.val ?? 0) + Math.Max(remain, 0);
            remain = curSumResult / 10;

            if (curSumResult >= 10)
                curSumResult -= 10;

            return new(curSumResult, AddTwoNumbers(l1?.next, l2?.next, remain));
        }
    }
}

