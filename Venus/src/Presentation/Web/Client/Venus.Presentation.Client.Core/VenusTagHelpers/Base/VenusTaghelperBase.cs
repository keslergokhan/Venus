using MediatR;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.DependencyInjection;
using Scriban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.HttpRequests.Interfaces;
using Venus.Presentation.Client.Core.HtmlCustomTagParser;

namespace Venus.Presentation.Client.Core.VenusTagHelpers.Base
{
    public abstract class VenusTaghelperBase : TagHelper
    {
        protected readonly IMediator Mediator;
        protected readonly IVenusHttpContext VenusHttpContext;
        protected readonly IHtmlCustomTagParserAndRenderFactory CustomTagParserAndRenderFactory;
        protected IServiceProvider ServiceProvider;
        protected IVenusScribanManager ScribanManager;

        public VenusTaghelperBase(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            Mediator = ServiceProvider.GetRequiredService<IMediator>();
            CustomTagParserAndRenderFactory = ServiceProvider.GetRequiredService<IHtmlCustomTagParserAndRenderFactory>();
            VenusHttpContext = ServiceProvider.GetRequiredService<IVenusHttpContext>();
            ScribanManager = ServiceProvider.GetRequiredService<IVenusScribanManager>();
        }

       
    }
}
