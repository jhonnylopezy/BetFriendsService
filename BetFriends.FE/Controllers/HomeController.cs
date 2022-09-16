using BetFriends.FE.Integration;
using BetFriends.FE.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BetFriends.FE.Controllers
{
    public class HomeController : Controller
    {
        public readonly PronosticoService _pronosticoService;
        public readonly CanalService _canalService;

        public HomeController()
        {
            this._pronosticoService = new PronosticoService();
            this._canalService = new CanalService();
        }
        public ActionResult Index()
        {
            var resultado=this._pronosticoService.getPronosticoPorCanal(1);
            ViewBag.Pronosticos = resultado;
            return View();
        }

        public ActionResult CanalesXParticipante()
        {
            var canales = this._canalService.CanalesXParticipante(1);
            ViewBag.Canales = canales;

            return View();
        }

        public ActionResult Canales()
        {
            var canales = this._canalService.ObtenerCanales();
            ViewBag.Canales = canales;

            return View();
        }
    }
}