using NUnit.Framework;

namespace SmellyMarsRover.Tests;

public class RoverRotationTests
{
    [Test]
    public void FacingNorthRotateLeft()
    {
        var rover = new Rover(0, 0, "N");

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(new Rover(0, 0, "W")));
    }

    [Test]
    public void FacingNorthRotateRight()
    {
        var rover = new Rover(0, 0, "N");

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(new Rover(0, 0, "E")));
    }

    [Test]
    public void FacingSouthRotateLeft()
    {
        var rover = new Rover(0, 0, "S");

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(new Rover(0, 0, "E")));
    }

    [Test]
    public void FacingSouthRotateRight()
    {
        var rover = new Rover(0, 0, "S");

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(new Rover(0, 0, "W")));
    }

    [Test]
    public void FacingWestRotateLeft()
    {
        var rover = new Rover(0, 0, "W");

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(new Rover(0, 0, "S")));
    }

    [Test]
    public void FacingWestRotateRight()
    {
        var rover = new Rover(0, 0, "W");

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(new Rover(0, 0, "N")));
    }

    [Test]
    public void FacingEastRotateLeft()
    {
        var rover = new Rover(0, 0, "E");

        rover.Receive("l");

        Assert.That(rover, Is.EqualTo(new Rover(0, 0, "N")));
    }

    [Test]
    public void FacingEastRotateRight()
    {
        var rover = new Rover(0, 0, "E");

        rover.Receive("r");

        Assert.That(rover, Is.EqualTo(new Rover(0, 0, "S")));
    }
}