using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace Azure_AD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {

        [Authorize(Roles ="admin")]
        [HttpGet("[action]")]
        [RequiredScope(RequiredScopesConfigurationKey ="AzureAd:Scopes")]
        public IActionResult GetReport()
        {
            return File(System.IO.File.ReadAllBytes(@"C:\Users\pavithra dogiparthi\Downloads\normalization.pdf"),"application/pdf");
          
        }
        [Authorize(Roles ="Manager")]
        [HttpGet("[action]")]
        public IActionResult GetReportStatus()
        {
            return Ok(new {status=@"Report Generated at -"+DateTime.Now.ToString("MM-dd-yyyy")});
        }
    }
}
