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
    }
}

