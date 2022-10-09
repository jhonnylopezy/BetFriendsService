using BetFriends.FE.Integration;
using BetFriends.FE.Models;
using BetFriends.FE.Service;
using BF.Domain.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BetFriends.FE.Controllers
{
    public class HomeController : Controller
    {
        public readonly PronosticoService _pronosticoService;
        public readonly CanalService _canalService;
        public readonly JornadaService _jornadaService;
        public readonly PartidoService _partidoService;
        public readonly ParticipanteService _participanteService;

        int tiempoSesion;

        public HomeController()
        {
            this._pronosticoService = new PronosticoService();
            this._canalService = new CanalService();
            this._jornadaService = new JornadaService();
            this._partidoService = new PartidoService();
            this._participanteService = new ParticipanteService();
            this.tiempoSesion = Convert.ToInt32(ConfigurationManager.AppSettings["timeSesion"]);
        }
        public ActionResult Index()
        {
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                return Redirect("~/Home/Login");

            ViewBag.Title = "Bienvenido a BetFriend";
            return View();
           
        }

        public ActionResult CanalesXParticipante()
        {
            FormsIdentity id = (FormsIdentity)User.Identity;
            FormsAuthenticationTicket ticket = id.Ticket;
            var idParticipante=JsonConvert.DeserializeObject<ParticipanteDTO>(ticket.UserData);
            var canales = this._canalService.CanalesXParticipante(idParticipante.id);
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
        public ActionResult PartidoPorJornada(int idJornada, int idCanal)
        {
            var partidos = this._partidoService.PartidoXJornada(idJornada);
            //ViewBag.Partidos = partidos;
            ViewBag.idCanal = idCanal;
            return View(partidos);
        }
        public ActionResult PronosticoXCanal(int idCanal)
        {
            var resultado = this._pronosticoService.getPronosticoPorCanal(idCanal);
            ViewBag.Pronosticos = resultado;

            var jornadas = this._jornadaService.Listar();
            ViewBag.Jornadas = jornadas;
            ViewBag.idCanal = idCanal;
            return View();
        }
        [HttpGet]
        public ActionResult Login(string ReturnUrl = "")
        {
            if (User.Identity.IsAuthenticated)
            {
                return LogOut();
            }
            ViewBag.Message = "";

            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginView loginView, string ReturnUrl = "")
        {
            ViewBag.Message = "";
            if (ModelState.IsValid)
            {
                var participante = this._participanteService.ObtenerParticipante(loginView.UserName, loginView.Password);
                if (participante!=null)
                {
                    var userData = JsonConvert.SerializeObject(participante);
                    var authTicket = new FormsAuthenticationTicket(1, loginView.UserName, DateTime.Now, DateTime.Now.AddMinutes(this.tiempoSesion), false, userData);

                    var enTicket = FormsAuthentication.Encrypt(authTicket);
                    var faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, enTicket);
                    System.Web.HttpContext.Current.Response.Cookies.Add(faCookie);
                    ViewBag.Message = "";
                    return RedirectToAction("Index", "Home");
                }
            }
            ViewBag.Message = "Credenciales de usuario incorrecto";
            return View();
        }
        private bool ValidarLogin(LoginView loginView)
        {
            if (loginView.UserName == "admin" && loginView.Password == "admin")

                return true;
            else
                return false;
        }

        public ActionResult LogOut()
        {
            HttpCookie cookie = new HttpCookie("Cookie1", "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);

            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home", null);
        }
    }
}