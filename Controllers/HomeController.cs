using Microsoft.AspNetCore.Mvc;

namespace FragTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;

        public HomeController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            var tournamentName = _config.GetValue<string>("Tournament:Name") ?? "LOCAL SCRIMS (No Tournament Data)";
            var serverEnv = _config.GetValue<string>("Server:Environment") ?? "UNDEFINED_SECTOR";
            var steamToken = _config.GetValue<string>("Steam:WebHookToken");

            ViewBag.TournamentName = tournamentName;
            ViewBag.ServerEnvironment = serverEnv;
            
            if (string.IsNullOrEmpty(steamToken))
            {
                ViewBag.SteamStatus = "⚠️ Синхронизацию со Steam отключено!";
                ViewBag.TokenMasked = null;
            }
            else
            {
                ViewBag.SteamStatus = "✅ Канал Steam API активен";
                ViewBag.TokenMasked = "Steam Token: [ПРИХОВАНО В ЦІЛЯХ БЕЗПЕКИ - CLASSIFIED]";
            }

            return View();
        }
    }
}
