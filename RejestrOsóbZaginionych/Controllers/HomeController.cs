using RejestrOsóbZaginionych.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RejestrOsóbZaginionych.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Działanie systemu informatycznego.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Dane kontaktowe:";

            return View();
        }

        public async Task<ActionResult> PersonsList(string sortOrder)
        {
            ViewBag.wojewodztwo = String.IsNullOrEmpty(sortOrder) ? "desc" : "";
            ViewBag.status = sortOrder == "statusasc" ? "status" : "statusasc";

            var missingPeople = from s in db.MissingPersons
                           select s;

            switch (sortOrder)
            {
                case "desc":
                    missingPeople = missingPeople.OrderByDescending(s => s.wojewodztwo);
                    break;
                case "statusasc":
                    missingPeople = missingPeople.OrderBy(s => s.status);
                    break;
                case "status":
                    missingPeople = missingPeople.OrderByDescending(s => s.status);
                    break;
                default:
                    missingPeople = missingPeople.OrderBy(s => s.wojewodztwo);
                    break;
            }
            return View(await missingPeople.AsNoTracking().ToListAsync());
        }

        [HttpGet]
        public ActionResult AddMissingPerson()
        {
            missingPersons addPanel = new missingPersons();
            return View(addPanel);
        }

        [HttpPost]
        public ActionResult AddMissingPerson(RejestrOsóbZaginionych.Controllers.missingPersons missingPerson)
        {
            HttpPostedFileBase file = Request.Files["SendFile"];
            string filename = Path.GetFileNameWithoutExtension(file.FileName);
            string extension = Path.GetExtension(file.FileName);
            filename = filename + DateTime.Now.ToString("yymmssffff")+ extension;
            missingPerson.obraz = "./../Images/" + filename;
            filename = Path.Combine(Server.MapPath("./../Images/"), filename);
            file.SaveAs(filename);

            using (Model1 dbModel = new Model1())
            {
                dbModel.MissingPersons.Add(missingPerson);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Pomyślnie dodano zaginioną osobę";
            return View();
        }

        public ActionResult Login()
        {
            UserLogin loginPanel = new UserLogin();
            return View(loginPanel);
        }

        [HttpPost]
        public ActionResult Authorize(RejestrOsóbZaginionych.Models.UserLogin user)
        {
            using(Model1 db = new Model1())
            {
                var userDetails = db.Users.Where(x => x.login == user.login && x.password == user.password).FirstOrDefault();
                if (userDetails == null)
                {
                    user.LoginErrorMessage = "Zły login lub hasło.";
                    return View("Login", user);
                } 
                else
                {
                    Session["login"] = userDetails.login;
                    Session["rank"] = userDetails.rank;
                    return RedirectToAction("Index", "Home");
                }

            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult Register()
        {
            UserRegister registerModel = new UserRegister();
            return View(registerModel);
        }

        [HttpPost]
        public ActionResult Register(users user)
        {
            using (Model1 dbModel = new Model1())
            {
                dbModel.Users.Add(user);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Pomyślnie zarejestrowano";
            return View("Register", new UserRegister());
        }

        public ActionResult AdminPanel()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DeleteMissingPerson(int id)
        {
            using (Model1 dbModel = new Model1())
            {
                missingPersons PersonDelete = dbModel.MissingPersons.SingleOrDefault(s => s.id == id);
                return View(PersonDelete);
            }
        }

        [HttpPost]
        public ActionResult DeleteMissingPerson(string id)
        {
            using (Model1 dbModel = new Model1())
            {
                int id_new = Int32.Parse(id);
                missingPersons ConfirmDelete = dbModel.MissingPersons.SingleOrDefault(x => x.id == id_new);
                dbModel.MissingPersons.Remove(ConfirmDelete);
                dbModel.SaveChanges();
                //return View(ConfirmDelete);
                return RedirectToAction("PersonsList", "Home");
            }
        }

        [HttpGet]
        public ActionResult EditMissingPerson(int id)
        {
            using (Model1 dbModel = new Model1())
            {
                missingPersons PersonDelete = dbModel.MissingPersons.SingleOrDefault(s => s.id == id);
                return View(PersonDelete);
            }
        }

        [HttpPost]
        public ActionResult EditMissingPerson(AddMssingPerson person)
        {

            using (Model1 dbModel = new Model1())
            {
                HttpPostedFileBase file = Request.Files["SendFile"];
                missingPersons ConfirmEdit = dbModel.MissingPersons.SingleOrDefault(x => x.id == person.id);
                ConfirmEdit.imie = person.imie;
                ConfirmEdit.nazwisko = person.nazwisko;
                ConfirmEdit.wiek = person.wiek;
                ConfirmEdit.plec = person.plec;
                ConfirmEdit.wojewodztwo = person.wojewodztwo;
                ConfirmEdit.data = Convert.ToDateTime(person.data);
                if (file.ContentType.Contains("image"))
                {
                    string filename = Path.GetFileNameWithoutExtension(file.FileName);
                    string extension = Path.GetExtension(file.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssffff") + extension;
                    person.obraz = "./../Images/" + filename;
                    filename = Path.Combine(Server.MapPath("./../Images/"), filename);
                    file.SaveAs(filename);
                    ConfirmEdit.obraz = person.obraz;
                }
                ConfirmEdit.opis = person.opis;
                ConfirmEdit.status = person.status;
                dbModel.SaveChanges();
                return RedirectToAction("PersonsList", "Home");
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            using (Model1 dbModel = new Model1())
            {
                missingPersons PersonDelete = dbModel.MissingPersons.SingleOrDefault(s => s.id == id);
                return View(PersonDelete);
            }
        }


    }
}