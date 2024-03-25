using NUnit.Framework;

namespace SmellyMarsRover.Tests;

public class RoverReceivingCommandsListTests
{
    [Test]
    public void NoCommands()
    {
        var rover = new Rover(0, 0, "N");

        rover.Receive("");

        Assert.That(rover, Is.EqualTo(new Rover(0, 0, "N")));
    }

    [Test]
    public void TwoCommands()
    {
        var rover = new Rover(0, 0, "N");

        rover.Receive("lf");

        Assert.That(rover, Is.EqualTo(new Rover(-1, 0, "W")));
    }

    [Test]
    public void ManyCommands()
    {
        var rover = new Rover(0, 0, "N");

        rover.Receive("ffrbbrfflff");

        Assert.That(rover, Is.EqualTo(new Rover(0, 0, "E")));
    }
}