using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresTraining.Models
{
    public class SingleLinkListNode
    {
        public int val;
        public SingleLinkListNode? next;
        public SingleLinkListNode(int val = 0, SingleLinkListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
