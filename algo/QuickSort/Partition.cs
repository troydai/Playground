namespace QuickSort
{
    public class Partition : IPartition
    {
        public int Sort(int[] samples, int lo, int hi)
        {
            var pivot = FindPivot(samples, lo, hi);
            var pivotValue = samples[pivot];
            Swap(samples, pivot, hi);

            var storeIndex = lo;
            for (int i = lo; i <= hi - 1; ++i)
            {
                if (samples[i] <= pivotValue)
                {
                    Swap(samples, i, storeIndex);
                    storeIndex++;
                }
            }

            Swap(samples, storeIndex, hi);

            return storeIndex;
        }

        private int FindPivot(int[] samples, int lo, int hi)
        {
            // choose the middle
            return (hi - lo) / 2 + lo;
        }

        private void Swap(int[] samples, int left, int right)
        {
            var temp = samples[right];
            samples[right] = samples[left];
            samples[left] = temp;
        }
    }
}