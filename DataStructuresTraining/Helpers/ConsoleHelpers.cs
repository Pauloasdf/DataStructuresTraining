namespace DataStructuresTraining.Helpers
{
    public static class ConsoleHelpers
    {
        public static void PrintListOfInt(this List<int> list)
        {
            list.ForEach(x => Console.WriteLine($"{x} "));
        }
    }
}
