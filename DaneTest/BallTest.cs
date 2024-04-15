using Dane;
using NUnit.Framework;

namespace DaneTest
{
    public class Tests
    {
        private Ball ball;

        [SetUp]
        public void Setup()
        {
            ball = new Ball();
        }

        [Test]
        public void TestVelocity()
        {
            double velocityX = 5;
            double velocityY = -3;

            ball.VelocityX = velocityX;
            ball.VelocityY = velocityY;

            Assert.AreEqual(velocityX, ball.VelocityX);
            Assert.AreEqual(velocityY, ball.VelocityY);
        }
    }
}
