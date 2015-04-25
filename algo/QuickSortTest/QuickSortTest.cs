using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sort;
using Xunit;

namespace QuickSortTest
{
    public class QuickSortTest
    {
        private ISorter _sorter;

        public QuickSortTest()
        {
            _sorter = new QuickSort(new Partition());
        }

        [Fact]
        public void QuickSortSortCorrectly()
        {
            var rand = new Random();

            for (int c = 0; c < 1000; c++)
            {
                var samples = Enumerable.Range(0, 1000).Select(_ => rand.Next(1000)).ToArray();
                var sampleInString = string.Join(",", samples);

                _sorter.Sort(samples);

                for (int i = 0; i < samples.Length - 1; ++i)
                {
                    Assert.True(samples[i] <= samples[i + 1],
                        string.Format("Value at {0} is larger than the next. \nSample: {1}.", i, sampleInString));
                }
            }
        }
    }
}
