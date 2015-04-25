using System;
using System.Linq;
using Sort;
using Xunit;

namespace SortTest
{
    public class PartitionFacts
    {
        private IPartition _partition;

        public PartitionFacts()
        {
            _partition = new Partition();
        }

        [Fact]
        public void PartitionCorrect()
        {
            var rand = new Random();

            for (int c = 0; c < 1000; ++c)
            {
                var samples = Enumerable.Range(0, 20).Select(_ => rand.Next(20)).ToArray();
                var sampleInString = string.Join(",", samples);

                int pivot = _partition.Sort(samples, 0, samples.Length - 1);

                Assert.True(pivot >= 0);
                Assert.True(pivot < samples.Length);

                for (int i = 0; i < pivot; ++i)
                {
                    Assert.True(samples[i] <= samples[pivot], string.Format("Item {0}:{1} > Pivot {2}:{3} [{4}]", i, samples[i], pivot, samples[pivot], sampleInString));
                }

                for (int i = pivot + 1; i < samples.Length; ++i)
                {
                    Assert.True(samples[i] >= samples[pivot], string.Format("Item {0}:{1} < Pivot {2}:{3} [{4}]", i, samples[i], pivot, samples[pivot], sampleInString));
                }
            }
        }
    }
}
