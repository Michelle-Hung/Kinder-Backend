using System;
using System.Collections.Generic;
using System.Text.Json;
using Kinder_Backend.Controllers;
using Kinder_Backend.Models;
using NUnit.Framework;

namespace KinderBackendUnitTest;

[TestFixture]
public class MyTravelControllerTest
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
        var expected = new TravelResponse(){
                TravelList = new List<TravelList>{
                    new TravelList{
                    Id = 1,
                    Attraction = "淡水老街",
                    StartDate = new DateTime(2021, 9, 27),
                    PictureName = "Wuling.jpeg"
                },

                new TravelList{
                    Id = 2,
                    Attraction = "The Twelve Apostles",
                    StartDate = new DateTime(2021, 9, 27),
                    PictureName = "Wuling.jpeg"
                },new TravelList{
                    Id = 3,
                    Attraction = "The Twelve Apostles",
                    StartDate = new DateTime(2021, 9, 27),
                    PictureName = "Wuling.jpeg"
                },new TravelList{
                    Id = 4,
                    Attraction = "The Twelve Apostles",
                    StartDate = new DateTime(2021, 9, 27),
                    PictureName = "Wuling.jpeg"
                },new TravelList{
                    Id = 5,
                    Attraction = "The Twelve Apostles",
                    StartDate = new DateTime(2021, 9, 27),
                    PictureName = "Wuling.jpeg"
                },new TravelList{
                    Id = 6,
                    Attraction = "The Twelve Apostles",
                    StartDate = new DateTime(2021, 9, 27),
                    PictureName = "Wuling.jpeg"
                },
            }
        };

        Assert.AreEqual(JsonSerializer.Serialize(expected), JsonSerializer.Serialize(actual));
    }
}