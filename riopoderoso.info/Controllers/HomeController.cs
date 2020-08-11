using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using riopoderoso.info.Models;
using Elisur;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Configuration;

namespace riopoderoso.info.Controllers
{
    public class HomeController : Controller
    {
        private Tools _tools;
        private UserManager<IdentityUser> _userManager;
        private Interfaces.IUnitOfWork _unitOfWork;

        public HomeController(Tools tools,
                              UserManager<IdentityUser> userManager,
                              Interfaces.IUnitOfWork unitOfWork)
        {
            _tools = tools;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Prueba()
        {
            
            return View();
        }

        public async Task<IActionResult> EventoSistema()
        {
            
            // Get logged user name.
            string loggedUserName = _tools.GetLoggedUserName();
            ViewBag.loggedUserName = loggedUserName;

            // Get logged user roles.
            IList<string> roles = await _tools.GetLoggedUserRoles();
            ViewBag.roles = roles;

            // Get connection string name of current logged user.
            string ConnectionStringName = _tools.GetConnectionStringName().Result;
            ViewBag.ConnectionStringName = ConnectionStringName;

            // Get connection string content of current logged user.
            string ConnectionStringContent = _tools.GetConnectionStringContent("Anonymous").Result;
            ViewBag.ConnectionStringContent = ConnectionStringContent;

            // Get URL host.
            string host = _tools.GetUrlHost();
            ViewBag.host = host;

            return View();
        }
        
        public IActionResult InsertTipoCurso()
        {
            //TiposCursos _tiposCursos = new TiposCursos();
            //Interfaces.ITiposCursosRepository _tiposCursosRepository = new TiposCursosRepository(_unitOfWork);

            //_tiposCursos.Nombre = "Tipo de Curso 05";
            //_tiposCursosRepository.Create(_tiposCursos);

            return View();
        }
    }
}
