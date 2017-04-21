using System;
using System.Web.Mvc;
using PetConnect.Models;
using PetConnect.DAL;

namespace PetConnect.Controllers
{
    public class ProfileController : Controller
    {
        //Initialize database
        private PetConnectDBContext db = new PetConnectDBContext();

        // GET: Profile
        public ActionResult ViewProfile(int Id)
        {
            var currentUser = db.Users.Find(Id);

            if (currentUser == null)
            {
                return HttpNotFound();
            }

            return View(currentUser);
        }

        public ActionResult AddChirp(int UserId, string Text)
        {
            Chirps tempChirp = new Chirps();
            tempChirp.Text = Text;
            tempChirp.CreateDateTime = DateTime.Now;
            User tempUser = db.Users.Find(UserId);
            tempChirp.UserId = tempUser.Id;

            db.Chirps.Add(tempChirp);
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}