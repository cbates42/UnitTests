// want to talk to you about it, missed last week's class and hoping to understand it a little better
using System.Security.Cryptography.X509Certificates;

namespace UnitsTests
{
    public class UnitTest1
    {
        public UnitTests.Utilities util = new UnitTests.Utilities();
        [Fact]
        public void FloorTest1()
        {
            double value = 6;
            double result = util.FloorNum(value);
            Assert.True(result == 6);
        }

        [Fact]
        public void FloorTest2()
        {
            double value = 5.1;
            double result = util.FloorNum(value);
            Assert.True(result != -5);

        }

        [Fact]
        public void FloorTest3()
        {
            double value = 6.2;
            double result = util.FloorNum(value);
            Assert.True(result == 6);

        }

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void FloorTestTheory(int value)
        {
          
            int expected1 = 3;
            int expected2 = 4;
            int expected3 = 5;

            double result1 = util.FloorNum(value);
            double result2 = util.FloorNum(value);
            double result3 = util.FloorNum(value);

            Assert.True(result1 == expected1);
            Assert.True(result2 == expected2);
            Assert.True(result3 == expected3);
        }

        [Fact]
        public void HashTest1()
        {
            string teststring = "hashme";
            string hashedstring = util.Hash(teststring);
            string toCompare = teststring;
            Assert.True(util.Hash(toCompare) == hashedstring);
        }

        [Fact]
        public void HashTest2()
        {
            string teststring = "HASHME";
            string hashedstring = util.Hash(teststring);
            string toCompare = teststring.ToLower();
            Assert.True(util.Hash(toCompare) != hashedstring);
        }
        [Fact]
        public void HashTest3()
        {
            string teststring = "hashme  ";
            string hashedstring = util.Hash(teststring);
            string toCompare = "hashme";
            Assert.True(util.Hash(toCompare) != hashedstring);
        }

        [Theory]
        [InlineData("password")]
        [InlineData("12345")]
        [InlineData("Lorem ipsum")]
        public void HashTheory(string value)
        {
            
            string result = util.Hash(value);
            Assert.Equal(result.Length / 2, value.Length);
        }

        [Fact]
        public void PrimeTest1()
        {
            int testnum = 8;
            Assert.False(util.isPrime(testnum));
        }

        [Fact]
        public void PrimeTest2()
        {
            int testnum = 3;
            Assert.True(util.isPrime(testnum));
        }

        [Fact]
        public void PrimeTest3()
        {
            int testnum = 402002302;
            Assert.False(util.isPrime(testnum));
        }

        [Fact]
        public void NonPrimeDivisorTest1()
        {
            int testnum = 17;
            List<int> divisors = util.GetNonPrimeDivisors(testnum);
            Assert.True(divisors.Exists != util.isPrime);
        }

        [Fact]
        public void NonPrimeDivisorTest2()
        {
            int testnum = 17;
            List<int> divisors = util.GetNonPrimeDivisors(testnum);
            Assert.False(divisors.Exists == util.isPrime);
        }

        [Fact]
        public void DivideTest1()
        {
            int testnum1 = 4;
            int testnum2 = 9;
            int result = util.Divide(testnum1, testnum2);
            Assert.True(result == 9 / 4);
        }

        [Fact]
        public void DivideTest2()
        {
            int testnum1 = 18;
            int testnum2 = 9;
            int result = util.Divide(testnum1, testnum2);
            Assert.True(result == 18 / 9);
        }

        [Fact]
        public void DivideTest3()
        {
            int testnum1 = 4;
            int testnum2 = 9;
            int result = util.Divide(testnum1, testnum2);
            Assert.True(result == testnum2 / testnum1);
        }

        [Fact]
        public void OrderedDivisorTest1()
        {
            int testnum = 70;

            Dictionary<int, int> expected = new Dictionary<int, int>() { { 1, 1 }, { 35, 35 } };
            Dictionary<int, int> actual = util.GetNonPrimeDivisorsOrdered(testnum);
            Assert.Equal(expected, actual);
        }
    }
}