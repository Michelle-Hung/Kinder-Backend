using System;
using System.Collections.Generic;
using Kinder_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kinder_Backend.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MyTravelController : ControllerBase
    {
        private static readonly List<Travel> travels = new List<Travel>{
            new Travel{
                Id = 1,
                Attraction = "淡水老街",
                Address = "淡水",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Context = "水老街分成外側靠淡水河岸的部分(金色水岸步道)與內側的老街，四處可見此區著名的古早味現烤蛋糕、烤魷魚、阿婆鐵蛋、魚酥、巨無霸冰淇淋還有淡水魚丸等等，都是來到此地必吃不可的美食。 從淡水捷運站走出來右轉，中正路及延伸的重建街、清水街一帶，就是鼎鼎大名的淡水老街。 ... 傍晚時，在金色水岸步道還可欣賞夕陽落入海面的美景。",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            },

            new Travel{
                Id = 2,
                Attraction = "The Twelve Apostles",
                Address = "墨爾本, 澳洲",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Context = "The Twelve Apostles is a collection of limestone stacks off the shore of Port Campbell National Park, by the Great Ocean Road in Victoria, Australia. Their proximity to one another has made the site a popular tourist attraction. Seven of the original eight stacks remain standing at the Twelve Apostles viewpoint, after one collapsed in July 2005.[1] Though the view from the promontory by the Twelve Apostles never included twelve stacks, additional stacks—not considered part of the Apostles group—are located to the west within the national park.[2]",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            },new Travel{
                Id = 3,
                Attraction = "The Twelve Apostles",
                Address = "墨爾本, 澳洲",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Context = "The Twelve Apostles is a collection of limestone stacks off the shore of Port Campbell National Park, by the Great Ocean Road in Victoria, Australia. Their proximity to one another has made the site a popular tourist attraction. Seven of the original eight stacks remain standing at the Twelve Apostles viewpoint, after one collapsed in July 2005.[1] Though the view from the promontory by the Twelve Apostles never included twelve stacks, additional stacks—not considered part of the Apostles group—are located to the west within the national park.[2]",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            },new Travel{
                Id = 4,
                Attraction = "The Twelve Apostles",
                Address = "墨爾本, 澳洲",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Context = "The Twelve Apostles is a collection of limestone stacks off the shore of Port Campbell National Park, by the Great Ocean Road in Victoria, Australia. Their proximity to one another has made the site a popular tourist attraction. Seven of the original eight stacks remain standing at the Twelve Apostles viewpoint, after one collapsed in July 2005.[1] Though the view from the promontory by the Twelve Apostles never included twelve stacks, additional stacks—not considered part of the Apostles group—are located to the west within the national park.[2]",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            },new Travel{
                Id = 5,
                Attraction = "The Twelve Apostles",
                Address = "墨爾本, 澳洲",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Context = "The Twelve Apostles is a collection of limestone stacks off the shore of Port Campbell National Park, by the Great Ocean Road in Victoria, Australia. Their proximity to one another has made the site a popular tourist attraction. Seven of the original eight stacks remain standing at the Twelve Apostles viewpoint, after one collapsed in July 2005.[1] Though the view from the promontory by the Twelve Apostles never included twelve stacks, additional stacks—not considered part of the Apostles group—are located to the west within the national park.[2]",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            },new Travel{
                Id = 6,
                Attraction = "The Twelve Apostles",
                Address = "墨爾本, 澳洲",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Context = "The Twelve Apostles is a collection of limestone stacks off the shore of Port Campbell National Park, by the Great Ocean Road in Victoria, Australia. Their proximity to one another has made the site a popular tourist attraction. Seven of the original eight stacks remain standing at the Twelve Apostles viewpoint, after one collapsed in July 2005.[1] Though the view from the promontory by the Twelve Apostles never included twelve stacks, additional stacks—not considered part of the Apostles group—are located to the west within the national park.[2]",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            },
        };
        public MyTravelController()
        {
        }

        [HttpGet]
        public TravelResponse GetTravelData()
        {
            return new TravelResponse
            {
                TravelDetail = travels
            };
        }
    }
}