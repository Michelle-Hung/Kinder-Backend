using Kinder_Backend.Controllers;
using Kinder_Backend.Models;
using NUnit.Framework;

namespace KinderBackendUnitTest;

public class Tests
{
    private MyTravelController _myTravelController;

    [SetUp]
    public void Setup()
    {
        _myTravelController = new MyTravelController();
    }

    [Test]
    public void get_travel_list_should_success()
    {
        var actual = _myTravelController.Get();
        var expected = new TravelResponse();

        Assert.Equals(actual, expected);
    }
}