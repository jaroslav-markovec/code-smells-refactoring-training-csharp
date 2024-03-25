using NUnit.Framework;

namespace SmellyMarsRover.Tests
{
    public class RoverEqualityTest
    {
        [Test]
        public void EqualRovers()
        {
            Assert.That(new Rover(1, 1, "N"), Is.EqualTo(new Rover(1, 1, "N")));
        }

        [Test]
        public void NotEqualRovers()
        {
            Assert.That(new Rover(1, 1, "N"), Is.Not.EqualTo(new Rover(1, 1, "S")));
            Assert.That(new Rover(1, 1, "N"), Is.Not.EqualTo(new Rover(1, 2, "N")));
            Assert.That(new Rover(1, 1, "N"), Is.Not.EqualTo(new Rover(0, 1, "N")));
        }
    }
}