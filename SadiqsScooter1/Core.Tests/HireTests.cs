using System.Net.WebSockets;
using System.Reflection;
using Newtonsoft.Json.Serialization;
using NuGet.Frameworks;

namespace Core.Tests;

public class HireTests
{
    [Fact]
    public void NewScooterCanBeHired()
    {
        var scooter = new Scooter();

        var result = scooter.Hire();

        Assert.True(result);
    }

    [Fact]
    public void ScooterCannotBeHiredTwice()
    {
        var scooter = new Scooter();

        _ = scooter.Hire();
        var secondHire = scooter.Hire();

        Assert.False(secondHire);
    }

    [Fact]
    public void PersonCanHireAScooter()
    {
        var person = new Person();
        var scooter = new Scooter();

        var startHireResult = person.StartHire(scooter);

        Assert.True(startHireResult);
    }

    [Fact]
    public void PersonCannotStartTwoHires()
    {
        var person = new Person();
        var scooter = new Scooter();

        _ = person.StartHire(scooter);
        var secondHireResult = person.StartHire(scooter);

        Assert.False(secondHireResult);
    }

    [Fact]
    public void DifferentPeopleCannotHireTheSameScooter()
    {
        var personOne = new Person();
        var personTwo = new Person();
        var scooter = new Scooter();

        var personOneHireResult = personOne.StartHire(scooter);
        var personTwoHireResult = personTwo.StartHire(scooter);

        Assert.True(personOneHireResult);
        Assert.False(personTwoHireResult);
    }

    [Fact]
    public void DifferentPeopleCanHireDifferentScooters()
    {
        var personOne = new Person();
        var personTwo = new Person();
        var scooterOne = new Scooter();
        var scooterTwo = new Scooter();

        var personOneHireResult = personOne.StartHire(scooterOne);
        var personTwoHireResult = personTwo.StartHire(scooterTwo);

        Assert.True(personOneHireResult);
        Assert.True(personTwoHireResult);
    }

    [Fact]
    public void PersonCanHireASecondScooterAfterEndingFirstHire()
    {
        var person = new Person();
        var scooterOne = new Scooter();
        var scooterTwo = new Scooter();

        _ = person.StartHire(scooterOne);
        person.EndHire();
        var secondHireResult = person.StartHire(scooterTwo);

        Assert.True(secondHireResult);
    }

    [Fact]
    public void DifferentPersonCanHireAScooterAfterEndingFirstHire() {
        var personOne = new Person();
        var personTwo = new Person();
        var scooter = new Scooter();

        _ = personOne.StartHire(scooter);
        personOne.EndHire();
        var secondPersonHireResult = personTwo.StartHire(scooter);

        Assert.True(secondPersonHireResult);
    }
}


// A person can hire a scooter
// A person cannot start two hires
// Different people cannot hire the same scooter
// Different people can hire different scooters

// A person can hire a new scooter after ending current hire
// A scooter can be hired by a different person after ending current hire
