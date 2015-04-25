using System;
using System.Linq;
using Xunit;

namespace QuickSort
{
    public class PartitionFacts
    {
        [Fact]
        public void PartitionCorrect()
        {
            var rand = new Random();

            for (int c = 0; c < 1000; ++c)
            {
                var samples = Enumerable.Range(0, 20).Select(_ => rand.Next(20)).ToArray();

                var values = string.Join(",", samples);

                IPartition partition = new Partition();
                int pivot = partition.Sort(samples, 0, samples.Length - 1);

                Assert.True(pivot >= 0);
                Assert.True(pivot < samples.Length);

                for (int i = 0; i < pivot; ++i)
                {
                    Assert.True(samples[i] <= samples[pivot], string.Format("Item {0}:{1} > Pivot {2}:{3} [{4}]", i, samples[i], pivot, samples[pivot], values));
                }

                for (int i = pivot + 1; i < samples.Length; ++i)
                {
                    Assert.True(samples[i] >= samples[pivot], string.Format("Item {0}:{1} < Pivot {2}:{3} [{4}]", i, samples[i], pivot, samples[pivot], values));
                }
            }
        }
    }
}
