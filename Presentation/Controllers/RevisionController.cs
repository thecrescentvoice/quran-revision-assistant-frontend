using Microsoft.AspNetCore.Mvc;
using Presentation.Services;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("Revision")]
    public class RevisionController : Controller
    {
        private readonly IPythonApiClient _api;
        public RevisionController(IPythonApiClient api) => _api = api;

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Revise")]
        public async Task<IActionResult> Revise(string inputText)
        {
            var resp = await _api.ReviseAsync(new ReviseRequest { Text = inputText });
            ViewBag.Result = resp?.RevisedText ?? "No response from backend.";
            ViewBag.Input = inputText;
            return View("Index");
        }
    }
}
