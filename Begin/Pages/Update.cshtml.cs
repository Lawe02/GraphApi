using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreRazor_MSGraph.Graph;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;
using Microsoft.Identity.Web;

namespace DotNetCoreRazor_MSGraph.Pages
{
    [AuthorizeForScopes(ScopeKeySection = "DownstreamApi:Scopes")]
    public class UpdateModel : PageModel
    {
        private MailboxSettings MailboxSettings { get;set; }
        public IEnumerable<Event> Events { get; private set; }
        public Event Event { get; private set; }
        private readonly GraphCalendarClient _graphCalendarClient;

        public UpdateModel(GraphCalendarClient graphCalendarClient)
        {
            _graphCalendarClient = graphCalendarClient;
        }
        public async Task OnGet(string id)
        {
            Events = await _graphCalendarClient.GetEvents("Pacific Standard Time");
            Event = Events.FirstOrDefault(x => x.Id == id);
        }



        public void OnPost()
        {

        }
    }
}
