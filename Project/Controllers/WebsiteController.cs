using GenHTTP.Api.Content;
using GenHTTP.Api.Content.Templating;
using GenHTTP.Modules.IO;
using GenHTTP.Modules.Markdown;
using GenHTTP.Modules.Scriban;
using GenHTTP.Modules.Scriban.Providers;
using System;

namespace Project.Controllers
{

    #region Model

    public record Points(string Unit, string Estimation);

    #endregion

    public class WebsiteController
    {
        private static readonly Random _Random = new Random();

        private static string[] STORY_POINTS = new string[]
        {
            "1", "2", "3", "5", "8", "13", "20", "40", "100"
        };

        private static string[] SHIRT_SIZES = new string[]
        {
            "XS", "S", "M", "L", "XL", "XXL"
        };

        public IHandlerBuilder Index()
        {
            return ModMarkdown.Page(Resource.FromAssembly("Index.md"))
                              .Title("Home");
        }

        public IHandlerBuilder Points()
        {
            var points = new Points("story points", STORY_POINTS[_Random.Next(0, STORY_POINTS.Length)]);

            return ModScriban.Page(Resource.FromAssembly("Points.html"), (r, h) => new ViewModel<Points>(r, h, points))
                             .Title("Story Points");
        }

        public IHandlerBuilder Shirt()
        {
            var points = new Points(string.Empty, SHIRT_SIZES[_Random.Next(0, SHIRT_SIZES.Length)]);

            return ModScriban.Page(Resource.FromAssembly("Points.html"), (r, h) => new ViewModel<Points>(r, h, points))
                             .Title("T-Shirt Sizes");
        }

        public IHandlerBuilder Days()
        {
            var points = new Points("days", _Random.Next(1, 300).ToString());

            return ModScriban.Page(Resource.FromAssembly("Points.html"), (r, h) => new ViewModel<Points>(r, h, points))
                             .Title("Person Days");
        }

        public IHandlerBuilder Legal()
        {
            return ModMarkdown.Page(Resource.FromAssembly("Legal.md"))
                              .Title("Legal");
        }

    }

}
