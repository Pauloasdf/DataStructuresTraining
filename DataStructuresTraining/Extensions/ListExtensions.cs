using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresTraining.Extensions
{
    public static class ListExtensions
    {
        public static void PrintListOfInt(this List<int> list)
        {
            list.ForEach(x => Console.WriteLine($"{x} "));
        }
    }
}
