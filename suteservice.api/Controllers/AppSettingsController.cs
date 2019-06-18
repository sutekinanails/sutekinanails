using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace suteservice.api.Controllers {
    public class AppSettingsController : ControllerBase {

        private readonly AppSettings _settings;

        public AppSettingsController (IOptions<AppSettings> settingsOptions) {
            _settings = settingsOptions.Value;
        }

        public IActionResult Index () {
            //ViewData["ConnectionString"] = _settings.ConnectionString;
            //ViewData["Database"] = _settings.Database;
            //return View();
            throw new NotImplementedException ();
        }
    }
}