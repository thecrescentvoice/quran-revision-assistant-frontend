using Microsoft.AspNetCore.Mvc;
using Presentation.Services;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class RevisionController : Controller
    {
        private readonly IPythonApiClient _api;
        public RevisionController(IPythonApiClient api) => _api = api;
n        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
n        [HttpPost]
        public async Task<IActionResult> Revise(string inputText)
        {
            var resp = await _api.ReviseAsync(new ReviseRequest { Text = inputText });
            ViewBag.Result = resp?.RevisedText ?? "No response from Python API.";
            ViewBag.Input = inputText;
            return View("Index");
        }
    }
}
