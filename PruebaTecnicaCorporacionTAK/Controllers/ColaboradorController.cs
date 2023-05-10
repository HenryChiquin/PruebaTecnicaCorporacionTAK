using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaTecnicaCorporacionTAK.Models;
using PruebaTecnicaCorporacionTAK.Models.ViewModel;
using PruebaTecnicaCorporacionTAK.Models.Request;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using PruebaTecnicaCorporacionTAK.Models.Common;

namespace PruebaTecnicaCorporacionTAK.Controllers
{
    public class ColaboradorController : Controller
    {
        // GET: Colaborador
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(ColaboradorViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                using (var db = new PruebaTecnicaTakDBEntities())
                {
                    db.SP_INSERTAR_COLABORADOR(model.Nombres, model.Apellidos, model.FechaNacimiento, model.EstadoCivil, model.GradoAcademico, model.Direccion);
                    db.SaveChanges();
                    return Redirect(Url.Content("Index"));
                }

            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        [HttpGet]
        public JsonResult getAllColaborador()
        {
            try
            {
                List<Colaborador> listColaborador = new List<Colaborador>();
                using (var db = new PruebaTecnicaTakDBEntities())
                {
                    foreach(var oElement in db.SP_LISTA_COLABORADOR())
                    {
                        var oColaborador = new Colaborador()
                        {
                            IdColaborador = oElement.IdColaborador,
                            Nombres = oElement.Nombres,
                            Apellidos = oElement.Apellidos,
                            FechaNacimiento = (String.Format("{0:dd/MM/yyyy}", oElement.FechaNacimiento)),
                            EstadoCivil = oElement.EstadoCivil,
                            GradoAcademico = oElement.GradoAcademico,
                            Direccion = oElement.Direccion
                        };
                        listColaborador.Add(oColaborador);
                    }
                }
                return Json(listColaborador, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (var db = new PruebaTecnicaTakDBEntities())
            {
                db.SP_ELIMINAR_COLABORADOR(id);
                db.SaveChanges();
            }


            return Content("1");
        }
        [HttpGet]
        public ActionResult Update(int Id)
        {
            var model = new ColaboradorViewModel();
            using (var db = new PruebaTecnicaTakDBEntities())
            {
                var oColaborador = db.COLABORADOR.Find(Id);
                model.IdColaborador = oColaborador.IdColaborador;
                model.Nombres = oColaborador.Nombres;
                model.Apellidos = oColaborador.Apellidos;
                model.FechaNacimiento = oColaborador.FechaNacimiento;
                model.EstadoCivil = oColaborador.EstadoCivil;
                model.GradoAcademico = oColaborador.GradoAcademico;
                model.Direccion = oColaborador.Direccion;
   
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(ColaboradorViewModel model)
        {
            using (var db = new PruebaTecnicaTakDBEntities())
            {
                db.SP_ACTUALIZAR_COLABORADOR(model.IdColaborador,model.Nombres, model.Apellidos, model.FechaNacimiento, model.EstadoCivil, model.GradoAcademico, model.Direccion);
                db.SaveChanges();
            }


            return Redirect(Url.Content("~/Colaborador"));
        }
        
        [HttpGet]
        public JsonResult generateWebToken(int Id)
        {

            try
            {
                List<String> jwt = new List<string>();
                jwt.Add(GetToken(Id));

                return Json(jwt, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        private readonly AppSettings _appSettings;
        private string GetToken(int Id)
        {
            var model = new ColaboradorViewModel();
            using (var db = new PruebaTecnicaTakDBEntities())
            {
                var oColaborador = db.COLABORADOR.Find(Id);
                model.IdColaborador = oColaborador.IdColaborador;
                model.Nombres = oColaborador.Nombres;
                model.Apellidos = oColaborador.Apellidos;
                model.FechaNacimiento = oColaborador.FechaNacimiento;
                model.EstadoCivil = oColaborador.EstadoCivil;
                model.GradoAcademico = oColaborador.GradoAcademico;
                model.Direccion = oColaborador.Direccion;

            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, model.IdColaborador.ToString()),
                        new Claim(ClaimTypes.Name, model.Nombres),
                        new Claim(ClaimTypes.Name, model.Apellidos)
                    }
                    ),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}