using GenHTTP.Engine;
using GenHTTP.Modules.Controllers;
using GenHTTP.Modules.IO;
using GenHTTP.Modules.Layouting;
using GenHTTP.Modules.Practices;
using GenHTTP.Modules.Websites;

using Project.Controllers;
using Project.Themes;

namespace Project
{

    public static class Program
    {

        public static int Main(string[] args)
        {
            var controller = Controller.From<WebsiteController>();

            var resources = Resources.From(ResourceTree.FromAssembly("Static"));

            var app = Layout.Create()
                            .Add("static", resources)
                            .Fallback(controller);

            var website = Website.Create()
                                 .Content(app)
                                 .Theme(new ProjectTheme());

            return Host.Create()
                       .Handler(website)
#if DEBUG
                       .Development()
#endif
                       .Defaults()
                       .Console()
                       .Run();
        }

    }

}
