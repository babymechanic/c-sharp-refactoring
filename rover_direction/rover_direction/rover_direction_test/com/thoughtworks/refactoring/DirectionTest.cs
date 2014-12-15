using NUnit.Framework;


namespace com.thoughtworks.refactoring{

[TestFixture]
public class DirectionTest {

    private Direction north;
    private Direction east;

    [SetUp]
    public void setUp() {
        north = new Direction('N');
        east = new Direction('E');
    }

    [Test]
    public void shouldTurnEastWhenTurnRightFromNorth() {
        Direction east = north.turnRight();
        Assert.That(east, Is.EqualTo(new Direction('E')));
    }

    [Test]
    public void shouldTurnWestWhenTurnLeftFromNorth() {
        Direction west = north.turnLeft();
			Assert.That(west, Is.EqualTo(new Direction('W')));
    }

    [Test]
    public void shouldTurnNorthWhenTurnLeftFromEast() {
        Direction north = east.turnLeft();
			Assert.That(north, Is.EqualTo(new Direction('N')));
    }
}
}
