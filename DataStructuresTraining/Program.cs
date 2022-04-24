using DataStructuresTraining;
using DataStructuresTraining.Extensions;
using static DataStructuresTraining.Models.Enums;

IntHeap heap = new(20, HeapType.MinHeap);
for(int i = 0; i < heap.Elements.Length; i++)
{
    heap.InsertElement(new Random().Next(heap.Elements.Length));
}