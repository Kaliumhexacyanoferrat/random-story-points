using System.Collections.Generic;
using System.Threading.Tasks;

using GenHTTP.Api.Content;
using GenHTTP.Api.Content.Templating;
using GenHTTP.Api.Content.Websites;
using GenHTTP.Api.Protocol;

using GenHTTP.Modules.IO;
using GenHTTP.Modules.Scriban;

namespace Project.Themes
{

    public class ProjectTheme : ITheme
    {

        #region Get-/Setters

        public List<Script> Scripts => new();

        public List<Style> Styles => new()
        {
            new("theme.css", Resource.FromAssembly("Theme.css").Build())
        };

        public IHandlerBuilder? Resources => null;

        public IRenderer<ErrorModel> ErrorHandler { get; }

        public IRenderer<WebsiteModel> Renderer { get; }

        #endregion

        #region Initialization

        public ProjectTheme()
        {
            Renderer = ModScriban.Template<WebsiteModel>(Resource.FromAssembly("Template.html")).Build();

            ErrorHandler = ModScriban.Template<ErrorModel>(Resource.FromAssembly("Error.html")).Build();
        }

        #endregion

        #region Functionality

        public ValueTask<object?> GetModelAsync(IRequest request, IHandler handler)
        {
            return new ValueTask<object?>();
        }

        #endregion

    }

}
