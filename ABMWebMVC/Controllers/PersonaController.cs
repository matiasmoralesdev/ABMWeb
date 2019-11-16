using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABMWebMVC.Models;
using ABMWebMVC.Models.ViewModels;

namespace ABMWebMVC.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {

            // Forma en la que nos enseñaron en el curso

            // dbwebEntities db = new dbwebEntities();
            // var listaPersonas = db.Persona.ToList();

            // Forma de Tutorial

            dbwebEntities db = new dbwebEntities();

            List<PersonaLViewModel> listaPersonas;

            listaPersonas = (from persona in db.Persona
                             select new PersonaLViewModel
                             {
                                 DNI = persona.DNI,
                                 Nombre = persona.Nombre,
                                 Apellido = persona.Apellido,
                                 Mail = persona.Mail,
                                 FechaNacimiento = persona.FechaNacimiento

                             }).ToList();


            return View(listaPersonas);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(PersonaViewModel pModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dbwebEntities db = new dbwebEntities())
                    {
                        var tablaPersona = new Persona();
                        tablaPersona.DNI = pModel.DNI;
                        tablaPersona.Nombre = pModel.Nombre;
                        tablaPersona.Apellido = pModel.Apellido;
                        tablaPersona.Mail = pModel.Mail;
                        tablaPersona.FechaNacimiento = pModel.FechaNacimiento;

                        db.Persona.Add(tablaPersona);
                        db.SaveChanges();
                    }
                    return Redirect("~/Persona/");
                }

                return View(pModel);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}