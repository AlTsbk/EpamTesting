using NUnit.Framework;
using triangle;

namespace Tests
{
    public class Tests
    {


        [Test]
        public void IsRightTriangle()
        {
            Assert.IsTrue(Triangle.IsTriangle(15, 19, 30));
        }

        [Test]
        public void OneSideIsNegative()
        {
            Assert.IsFalse(Triangle.IsTriangle(15, 16, -30));
        }

        [Test]
        public void AllSidesAreNegative()
        {
            Assert.IsFalse(Triangle.IsTriangle(-15, -16, -30));
        }

        [Test]
        public void ImpossibleTriangle()
        {
            Assert.IsFalse(Triangle.IsTriangle(15, 14, 31));
        }

        [Test]
        public void OneSideIsZero()
        {
            Assert.IsFalse(Triangle.IsTriangle(15, 15, 0));
        }

        [Test]
        public void TwoSidesAreEqual()
        {
            Assert.IsTrue(Triangle.IsTriangle(15, 15, 29));
        }

        [Test]
        public void AllSidesAreEqual()
        {
            Assert.IsTrue(Triangle.IsTriangle(15, 15, 15));
        }

        [Test]
        public void RightTriangle()
        {
            Assert.IsTrue(Triangle.IsTriangle(6, 8, 10));
        }

        [Test]
        public void AllSidesAreZero()
        {
            Assert.IsFalse(Triangle.IsTriangle(0, 0, 0));
        }

        [Test]
        public void AllSidesAreDouble()
        {
            Assert.IsTrue(Triangle.IsTriangle(0.7, 0.6, 0.8));
        }
       
    }
}