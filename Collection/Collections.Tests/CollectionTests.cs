using NUnit.Framework;
using System;
using System.Linq;

namespace Collections.Tests
{
    public class CollectionTests
    {
     
        [Test]
        public void Test_EmptyConstructor()
        {
            var nums = new Collection<int>();

            Assert.AreEqual(0, nums.Count);
            Assert.AreEqual(16, nums.Capacity);
        }

        [Test]
        public void Test_CollectionWithTwoNumbers()
        {
            var nums = new Collection<int>(1,2);

            Assert.AreEqual(2, nums.Count);
            Assert.AreEqual(16, nums.Capacity);
        }


        [Test]
        public void Test_Collections_Add()
        {
            var nums = new Collection<int>();

            nums.Add(1);

            Assert.AreEqual(1, nums.Count);
            Assert.AreEqual(16, nums.Capacity);
        }

        [Test]
        [Timeout(1000)]
        public void Test_Collections_1MillionItems()
        {
            const int itemsCount = 1000000;
            var nums = new Collection<int>();
            nums.AddRange(Enumerable.Range(1, itemsCount).ToArray());
            
            Assert.That(nums.Count == itemsCount);
            Assert.That(nums.Capacity >= nums.Count);
        }


        [Test]
        public void Test_Collections_AddRange()
        {
            var nums = new Collection<int>();
            int range = 10;
            nums.AddRange(Enumerable.Range(1,range).ToArray());

            Assert.AreEqual(10, nums.Count);
            Assert.AreEqual(16, nums.Capacity);
        }

        [Test]
        public void Test_Collections_InsertValidIndex()
        {
            var nums = new Collection<int>();

            nums.InsertAt(0, 5);

            Assert.That(nums.Count == 1);
            Assert.That(nums[0] == 5); 
        }

        [Test]
        public void Test_Collections_InsertInvalidIndex()
        {
            var nums = new Collection<int>();

            Assert.That(() => { nums.InsertAt(17, 6); },
                Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() => { nums.InsertAt(-1, 6); },
                Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collections_ExchangeWithValidIndex()
        {
            var nums = new Collection<int>(1,2,3);

            nums.Exchange(0,1);

            Assert.AreEqual(2, nums[0]);
            Assert.AreEqual(1, nums[1]);
        }

        [Test]
        public void Test_Collections_ExchangeWithInvalidIndex()
        {
            var nums = new Collection<int>(1, 2, 3);

            Assert.That(() => { nums.Exchange(0, 5); },
                Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collections_RemoveAll()
        {
            var nums = new Collection<int>(1, 2);
            for(int i = nums.Count-1; i >=0 ; i--)
            {
                nums.RemoveAt(i);
            }

            Assert.That(nums.Count, Is.EqualTo(0));
        }

        [Test]
        public void Test_Collections_RemoveAtValidIndex()
        {
            var nums = new Collection<int>(1, 2, 3);

            nums.RemoveAt(0);
            Assert.AreEqual(2,nums[0]); 
        }

        [Test]
        public void Test_Collections_RemoveAtInvalidIndex()
        {
            var nums = new Collection<int>(1, 2, 3);

            Assert.That(() => { nums.Exchange(0, 5); },
                  Throws.InstanceOf<Exception>());
        }

        [Test]
        public void Test_Collections_ClearWithEmptyCollection()
        {
            var nums = new Collection<int>();
            nums.Clear();
            Assert.AreEqual(0,nums.Count);
        }

        [Test]
        public void Test_Collections_ClearCollectionWithTwoValues()
        {
            var nums = new Collection<int>(1,2);
            nums.Clear();
            Assert.AreEqual(0, nums.Count);
        }

        [Test]
        public void Test_Collections_ToString()
        {
            var nums = new Collection<int>(1, 2);
            string actual = nums.ToString();
            string expected = "[1, 2]";

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Test_Collection_AddRangeWithGrow()
        {
            var nums = new Collection<int>();

            int oldCapacity = nums.Capacity;

            var newNums = Enumerable.Range(1000, 2000).ToArray();

            nums.AddRange(newNums);

            string expectedNums = "[" + string.Join(", ", newNums) + "]";

            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
        }

        [Test]
        public void Test_Collections_GetByValidIndex()
        {
            var nums = new Collection<int>(1, 2);

            int number1 = nums[0];
            int number2 = nums[1];

            Assert.That(number1,Is.EqualTo(1));
            Assert.That(number2,Is.EqualTo(2));
        }

        [Test]
        public void Test_Collections_GetByInvalidIndex()
        {
            var nums = new Collection<int>(1, 2);

            Assert.That(() => { int number1 = nums[-1]; },
                Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.That(() => { int number1 = nums[2]; },
                Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.That(() => { int number1 = nums[200]; },
            Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collections_SetByValidIndex()
        {
            var nums = new Collection<int>(1, 2);

            nums[0] = 5;
            nums[1] = 6;

            Assert.That(nums[0], Is.EqualTo(5));
            Assert.That(nums[1], Is.EqualTo(6));
        }

        [Test]
        public void Test_Collections_SetByInvalidIndex()
        {
            var nums = new Collection<int>(1, 2);

            Assert.That(() => { nums[-1] = 5; },
                Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.That(() => { nums[2] = 6; },
                Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.That(() => { nums[200] = 6; },
                Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

    }
}