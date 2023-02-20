using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;
using Whois.NET;

namespace WhoIs.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public string WhoIsText { get; set; }


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public static string TextToHtml(string text)
        {
            text = HttpUtility.HtmlEncode(text);
            text = text.Replace("\r\n", "\r");
            text = text.Replace("\n", "\r");
            text = text.Replace("\r", "<br>\r\n");
            text = text.Replace("  ", " &nbsp;");
            return text;
        }
        public void OnGet()
        {
            WhoIsText = "NA";
        }

        public void OnPost(string action="err", string target="err")
        {
            if ( action =="check")
            {
                var result = WhoisClient.Query(target);
                WhoIsText = TextToHtml(result.Raw);
            }
        }
    }
}