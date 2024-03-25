using NUnit.Framework;

namespace SmellyMarsRover.Tests;

public class RoverPositionTests
{
    [Test]
    public void FacingNorthMoveForward()
    {
        var rover = new Rover(0, 0, "N");

        rover.Receive("f");

        Assert.That(new Rover(0, 1, "N"), Is.EqualTo(rover));
    }

    [Test]
    public void FacingNorthMoveBackward()
    {
        var rover = new Rover(0, 0, "N");

        rover.Receive("b");

        Assert.That(new Rover(0, -1, "N"), Is.EqualTo(rover));
    }

    [Test]
    public void FacingSouthMoveForward()
    {
        var rover = new Rover(0, 0, "S");

        rover.Receive("f");

        Assert.That(new Rover(0, -1, "S"), Is.EqualTo(rover));
    }

    [Test]
    public void FacingSouthMoveBackward()
    {
        var rover = new Rover(0, 0, "S");

        rover.Receive("b");

        Assert.That(new Rover(0, 1, "S"), Is.EqualTo(rover));
    }

    [Test]
    public void FacingWestMoveForward()
    {
        var rover = new Rover(0, 0, "W");

        rover.Receive("f");

        Assert.That(new Rover(-1, 0, "W"), Is.EqualTo(rover));
    }

    [Test]
    public void FacingWestMoveBackward()
    {
        var rover = new Rover(0, 0, "W");

        rover.Receive("b");

        Assert.That(new Rover(1, 0, "W"), Is.EqualTo(rover));
    }

    [Test]
    public void FacingEastMoveForward()
    {
        var rover = new Rover(0, 0, "E");

        rover.Receive("f");

        Assert.That(new Rover(1, 0, "E"), Is.EqualTo(rover));
    }

    [Test]
    public void FacingEastMoveBackward()
    {
        var rover = new Rover(0, 0, "E");

        rover.Receive("b");

        Assert.That(new Rover(-1, 0, "E"), Is.EqualTo(rover));
    }
}