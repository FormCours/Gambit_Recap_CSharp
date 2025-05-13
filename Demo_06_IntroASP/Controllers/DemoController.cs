using Demo_06_IntroASP.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo_06_IntroASP.Controllers
{
    public class DemoController : Controller
    {
        private readonly SingletonService _single1;
        private readonly SingletonService _single2;
        private readonly ScopedService _scoped1;
        private readonly ScopedService _scoped2;
        private readonly TransientService _transient1;
        private readonly TransientService _transient2;

        public DemoController(SingletonService single1, SingletonService single2, ScopedService scoped1, ScopedService scoped2, TransientService transient1, TransientService transient2)
        {
            _single1 = single1;
            _single2 = single2;
            _scoped1 = scoped1;
            _scoped2 = scoped2;
            _transient1 = transient1;
            _transient2 = transient2;
        }

        public IActionResult Index()
        {
            ViewData["S1"] = _single1.InitializeCurrent;
            ViewData["S2"] = _single2.InitializeCurrent;
            ViewData["SC1"] = _scoped1.InitializeCurrent;
            ViewData["SC2"] = _scoped2.InitializeCurrent;
            ViewData["T1"] = _transient1.InitializeCurrent;
            ViewData["T2"] = _transient2.InitializeCurrent;
            return View();
        }
    }
}
