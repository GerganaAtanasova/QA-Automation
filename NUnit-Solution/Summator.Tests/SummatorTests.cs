using NUnit.Framework;

namespace Summator.Tests
{
    public class Tests
    {


        [Test]
        public void Test_Sum_TwoPositiveNumbers()
        {
            int result = Summator.Sum(new int[] { 1, 2 });

            Assert.That(result == 3);
        }

        [Test]
        public void Test_Sum_TwoNegativeNumbers()
        {
            int result = Summator.Sum(new int[] { -1, -2 });

            Assert.That(result == -3);
        }


        [Test]
        public void Test_Sum_EmptyArr()
        {
            int result = Summator.Sum(new int[] {});

            Assert.That(result == 0); 
        }

        [Test]
        public void Test_Sum_OneNumber()
        {
            int result = Summator.Sum(new int[] { 5});

            Assert.That(result == 5);
        }

    }
}