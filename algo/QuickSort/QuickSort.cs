using System;

namespace Sort
{
    public class QuickSort : ISorter
    {
        private readonly IPartition _partition;

        public QuickSort(IPartition partition)
        {
            _partition = partition;
        }

        public void Sort(int[] collection)
        {
            PartialSort(collection, 0, collection.Length - 1);
        }

        private void PartialSort(int[] collection, int lo, int hi)
        {
            if (hi <= lo)
            {
                return;
            }

            var pivot = _partition.Sort(collection, lo, hi);
            PartialSort(collection, lo, pivot - 1);
            PartialSort(collection, pivot + 1, hi);
        }
    }
}
