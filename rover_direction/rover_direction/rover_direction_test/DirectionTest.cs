using NUnit.Framework;
using rover_direction;

namespace rover_direction_test
{
    [TestFixture]
    public class DirectionTest
    {
        private Direction east;
        private Direction north;

        [SetUp]
        public void SetUp()
        {
            north = new Direction('N');
            east = new Direction('E');
        }

        [Test]
        public void ShouldTurnEastWhenTurnRightFromNorth()
        {
            var east = north.TurnRight();
            Assert.That(east, Is.EqualTo(new Direction('E')));
        }

        [Test]
        public void ShouldTurnWestWhenTurnLeftFromNorth()
        {
            var west = north.TurnLeft();
            Assert.That(west, Is.EqualTo(new Direction('W')));
        }

        [Test]
        public void ShouldTurnNorthWhenTurnLeftFromEast()
        {
            var north = east.TurnLeft();
            Assert.That(north, Is.EqualTo(new Direction('N')));
        }
    }
}