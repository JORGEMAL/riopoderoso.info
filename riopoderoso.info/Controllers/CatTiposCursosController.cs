using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Elisur;
using riopoderoso;
using Devart.Data.PostgreSql;

namespace riopoderoso.info.Controllers
{
    // ******************************************************************************
    //                            Catalogo de tipos de cursos.
    // ******************************************************************************
    public class CatTiposCursosController : Controller
    {
        private TiposCursos _tiposCursos;
        private ITiposCursosRepository _tiposCursosRepository;

        // -----------------------------------------------------------------------------
        //                              Constructor.
        // -----------------------------------------------------------------------------
        public CatTiposCursosController(TiposCursos tiposCursos,
                                        ITiposCursosRepository tiposCursosRepository)
        {
            _tiposCursos = tiposCursos;
            _tiposCursosRepository = tiposCursosRepository;
        }

        // -----------------------------------------------------------------------------
        //                              Index.
        // -----------------------------------------------------------------------------
        public IActionResult Index()
        {
            IEnumerable<TiposCursos> tiposCursos = _tiposCursosRepository.GetAllRecords();
            return View(tiposCursos);
        }

        // -----------------------------------------------------------------------------
        //                              Insert data.
        // -----------------------------------------------------------------------------
        public IActionResult Insert([FromBody]CRUDModel<TiposCursos> value)
        {
            //PgSqlMonitor monitor = new PgSqlMonitor();
            //monitor.IsActive = true;

            _tiposCursos.Nombre = value.value.Nombre;
            long sequenceValue = _tiposCursosRepository.Create(_tiposCursos);
            value.key = sequenceValue;
            value.value.Id = sequenceValue;

            return Json(value.value);
        }

        // -----------------------------------------------------------------------------
        //                              Update data.
        // -----------------------------------------------------------------------------
        public IActionResult Update([FromBody]CRUDModel<TiposCursos> value)
        {
            _tiposCursos.Id = (long) value.key;
            _tiposCursos.Nombre = value.value.Nombre;
            _tiposCursos.FechaModificacion = DateTime.Now;
            _tiposCursosRepository.Update(_tiposCursos);

            return Json(value.value);
        }

        // -----------------------------------------------------------------------------
        //                              Delete data.
        // -----------------------------------------------------------------------------
        public IActionResult Delete([FromBody]CRUDModel<TiposCursos> value)
        {
            _tiposCursosRepository.Delete((long) value.key);
            return Json(value);
        }

        // -----------------------------------------------------------------------------
        //                              Get data.
        // -----------------------------------------------------------------------------
        public IActionResult GetAllRecords(long id = -1)
        {
            IEnumerable<TiposCursos> tiposCursos = _tiposCursosRepository.GetAllRecords(id);
            ViewBag.result = tiposCursos;
            return View();
        }
    }



    public class CRUDModel<T> where T : class
    {
        //public string action { get; set; }

        //public string table { get; set; }

        //public string keyColumn { get; set; }

        public object key { get; set; }

        public T value { get; set; }

        //public List<T> added { get; set; }

        //public List<T> changed { get; set; }

        //public List<T> deleted { get; set; }

        //public IDictionary<string, object> @params { get; set; }
    }
}