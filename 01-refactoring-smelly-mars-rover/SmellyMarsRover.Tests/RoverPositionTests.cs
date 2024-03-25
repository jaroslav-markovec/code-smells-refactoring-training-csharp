using NUnit.Framework;

namespace SmellyMarsRover.Tests;

public class RoverPositionTests
{
    [Test]
    public void FacingNorthMoveForward()
    {
        var rover = new Rover(0, 0, "N");

        rover.Receive("f");

        Assert.That(rover, Is.EqualTo(new Rover(0, 1, "N")));
    }

    [Test]
    public void FacingNorthMoveBackward()
    {
        var rover = new Rover(0, 0, "N");

        rover.Receive("b");

        Assert.That(rover, Is.EqualTo(new Rover(0, -1, "N")));
    }

    [Test]
    public void FacingSouthMoveForward()
    {
        var rover = new Rover(0, 0, "S");

        rover.Receive("f");

        Assert.That(rover, Is.EqualTo(new Rover(0, -1, "S")));
    }

    [Test]
    public void FacingSouthMoveBackward()
    {
        var rover = new Rover(0, 0, "S");

        rover.Receive("b");

        Assert.That(rover, Is.EqualTo(new Rover(0, 1, "S")));
    }

    [Test]
    public void FacingWestMoveForward()
    {
        var rover = new Rover(0, 0, "W");

        rover.Receive("f");

        Assert.That(rover, Is.EqualTo(new Rover(-1, 0, "W")));
    }

    [Test]
    public void FacingWestMoveBackward()
    {
        var rover = new Rover(0, 0, "W");

        rover.Receive("b");

        Assert.That(rover, Is.EqualTo(new Rover(1, 0, "W")));
    }

    [Test]
    public void FacingEastMoveForward()
    {
        var rover = new Rover(0, 0, "E");

        rover.Receive("f");

        Assert.That(rover, Is.EqualTo(new Rover(1, 0, "E")));
    }

    [Test]
    public void FacingEastMoveBackward()
    {
        var rover = new Rover(0, 0, "E");

        rover.Receive("b");

        Assert.That(rover, Is.EqualTo(new Rover(-1, 0, "E")));
    }
}