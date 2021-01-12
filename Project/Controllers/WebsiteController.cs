using System;

using GenHTTP.Api.Content;
using GenHTTP.Api.Content.Templating;

using GenHTTP.Modules.IO;
using GenHTTP.Modules.Markdown;
using GenHTTP.Modules.Scriban;

namespace Project.Controllers
{

    #region Model

    public record Points(string Unit, string Estimation);

    #endregion

    public class WebsiteController
    {
        private static readonly Random _Random = new Random();

        private static readonly string[] STORY_POINTS = new string[]
        {
            "1", "2", "3", "5", "8", "13", "20", "40", "100"
        };

        private static readonly string[] SHIRT_SIZES = new string[]
        {
            "XS", "S", "M", "L", "XL", "XXL"
        };

        public IHandlerBuilder Index()
        {
            return ModMarkdown.Page(Resource.FromAssembly("Index.md"))
                              .Title("Home")
                              .Description("Randomly generate estimates for user stories in story points, t-shirt sizes or days.");
        }

        public IHandlerBuilder Points()
        {
            var points = new Points("story points", STORY_POINTS[_Random.Next(0, STORY_POINTS.Length)]);

            return ModScriban.Page(Resource.FromAssembly("Points.html"), (r, h) => new ViewModel<Points>(r, h, points))
                             .Title("Story Points")
                             .Description("Randomly generate estimates for user stories in story points.");
        }

        public IHandlerBuilder Shirt()
        {
            var points = new Points(string.Empty, SHIRT_SIZES[_Random.Next(0, SHIRT_SIZES.Length)]);

            return ModScriban.Page(Resource.FromAssembly("Points.html"), (r, h) => new ViewModel<Points>(r, h, points))
                             .Title("T-Shirt Sizes")
                             .Description("Randomly generate estimates for user stories in t-shirt sizes.");
        }

        public IHandlerBuilder Days()
        {
            var points = new Points("days", _Random.Next(1, 300).ToString());

            return ModScriban.Page(Resource.FromAssembly("Points.html"), (r, h) => new ViewModel<Points>(r, h, points))
                             .Title("Person Days")
                             .Description("Randomly generate estimates for user stories in days.");
        }

        public IHandlerBuilder Legal()
        {
            return ModMarkdown.Page(Resource.FromAssembly("Legal.md"))
                              .Title("Legal")
                              .Description("Legal information about random-story-points.com");
        }

    }

}
