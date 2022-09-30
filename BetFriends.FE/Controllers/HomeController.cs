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
        public readonly JornadaService _jornadaService;
        public readonly PartidoService _partidoService;

        public HomeController()
        {
            this._pronosticoService = new PronosticoService();
            this._canalService = new CanalService();
            this._jornadaService = new JornadaService();
            this._partidoService = new PartidoService();
        }
        public ActionResult Index()
        {
            var resultado=this._pronosticoService.getPronosticoPorCanal(1);
            ViewBag.Pronosticos = resultado;

            var jornadas = this._jornadaService.Listar();
            ViewBag.Jornadas = jornadas;

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

        public ActionResult Jornada()
        {
            var jornadas = this._jornadaService.Listar();
            ViewBag.Jornadas = jornadas;

            return View();
        }
        public ActionResult PartidoPorJornada(int idJornada)
        {
            var partidos = this._partidoService.PartidoXJornada(idJornada);
            //ViewBag.Partidos = partidos;

            return View(partidos);
        }
        
    }
}