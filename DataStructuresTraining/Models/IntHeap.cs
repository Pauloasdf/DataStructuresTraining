using static DataStructuresTraining.Models.Enums;

namespace DataStructuresTraining
{
    public class IntHeap
    {
        public int[] Elements { get; set; }
        public int TreeSize { get; set; }
        public HeapType Type { get; set; }
        public IntHeap(int size, HeapType type)
        {
            Elements = new int[size];
            TreeSize = 0;
            Type = type;
        }
    }
}
