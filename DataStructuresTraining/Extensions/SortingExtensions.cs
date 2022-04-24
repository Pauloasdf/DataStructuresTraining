namespace DataStructuresTraining
{
    public static class SortingExtensions
    {
        public static int RemoveElement(this int[] nums, int val)
        {
            int lastUpdatedIndex = 0;
            int i = 0;

            while (i < nums.Length)
            {
                if (nums[i] != val)
                {
                    SwapNumbers(nums, lastUpdatedIndex, i);
                    lastUpdatedIndex++;
                }
                i++;
            }
            Array.Resize(ref nums, lastUpdatedIndex);
            return lastUpdatedIndex + 1;
        }
        public static void SwapNumbers(this int[] nums, int indexOne, int indexTwo)
        {
            int temp = nums[indexOne];
            nums[indexOne] = nums[indexTwo];
            nums[indexTwo] = temp;
        }
        public static List<int> QuickSort(this List<int> numbers, bool isEqual = false)
        {
            if (numbers.Count < 2 || isEqual) return numbers;

            List<int> lower = new();
            List<int> equal = new();
            List<int> bigger = new();

            int pivot = numbers.Last();
            //pivot is the last number in the array
            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                if (numbers[i] > pivot) bigger.Add(numbers[i]);
                else if (numbers[i] < pivot) lower.Add(numbers[i]);
                else equal.Add(numbers[i]);
            }
            lower = QuickSort(lower);
            equal = QuickSort(equal, true);
            bigger = QuickSort(bigger);

            return lower.Concat(equal).Concat(bigger).ToList();
        }
        public static int Partition(this int[] numbers, int left, int right)

        {
            // Após escolhido o primeiro PIVÔ, o array é percorrido das extremidades para o centro.
            // Caso encontre na esquerda um elemento maior que o pivo e na direita um maior, os troca de lugar
            // 
            int pivot = numbers[left];
            while (true)
            {
                while (numbers[left] < pivot)
                    left++;
                while (numbers[right] > pivot)
                    right--;
                if (left < right)
                {
                    int temp = numbers[right];
                    numbers[right] = numbers[left];
                    numbers[left] = temp;
                }
                else return right;
            }
        }
        public static void QuickSort_Recursive(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);
                if (pivot > 1)
                    QuickSort_Recursive(arr, left, pivot - 1);
                if (pivot + 1 < right)
                    QuickSort_Recursive(arr, pivot + 1, right);
            }
        }
    }
}
