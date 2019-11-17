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



            List<PersonaLViewModel> listaPersonas;
            using (dbwebEntities db = new dbwebEntities())
            {
                listaPersonas = (from persona in db.Persona
                                 select new PersonaLViewModel
                                 {
                                     DNI = persona.DNI,
                                     Nombre = persona.Nombre,
                                     Apellido = persona.Apellido,
                                     Mail = persona.Mail,
                                     FechaNacimiento = persona.FechaNacimiento

                                 }).ToList();
            }

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

        public ActionResult Editar(int id)
        {
            PersonaViewModel modelo = new PersonaViewModel();
            using (dbwebEntities db = new dbwebEntities())
            {
                var tablaPersona = db.Persona.Find(id);
                modelo.Nombre = tablaPersona.Nombre;
                modelo.Apellido = tablaPersona.Apellido;
                modelo.Mail = tablaPersona.Mail;
                modelo.FechaNacimiento = tablaPersona.FechaNacimiento;
                modelo.DNI = tablaPersona.DNI;


            }
            return View(modelo);
        }


        [HttpPost]
        public ActionResult Editar(PersonaViewModel pModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dbwebEntities db = new dbwebEntities())
                    {
                        var tablaPersona = db.Persona.Find(pModel.DNI);
                        tablaPersona.DNI = pModel.DNI;
                        tablaPersona.Nombre = pModel.Nombre;
                        tablaPersona.Apellido = pModel.Apellido;
                        tablaPersona.Mail = pModel.Mail;
                        tablaPersona.FechaNacimiento = pModel.FechaNacimiento;

                        db.Entry(tablaPersona).State = System.Data.Entity.EntityState.Modified;
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




        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            using (dbwebEntities db = new dbwebEntities())
            {
                var tablaPersona = db.Persona.Find(id);
                db.Persona.Remove(tablaPersona);
                db.SaveChanges();
            }
            return Redirect("~/Persona/");
        }



    }
}