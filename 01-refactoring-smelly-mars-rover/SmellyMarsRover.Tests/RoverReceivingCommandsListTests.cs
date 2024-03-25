using NUnit.Framework;

namespace SmellyMarsRover.Tests;

public class RoverReceivingCommandsListTests
{
    [Test]
    public void NoCommands()
    {
        var rover = new Rover(0, 0, "N");

        rover.Receive("");

        Assert.That(new Rover(0, 0, "N"), Is.EqualTo(rover));
    }

    [Test]
    public void TwoCommands()
    {
        var rover = new Rover(0, 0, "N");

        rover.Receive("lf");

        Assert.That(new Rover(-1, 0, "W"), Is.EqualTo(rover));
    }

    [Test]
    public void ManyCommands()
    {
        var rover = new Rover(0, 0, "N");

        rover.Receive("ffrbbrfflff");

        Assert.That(new Rover(0, 0, "E"), Is.EqualTo(rover));
    }
}