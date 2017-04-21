using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetConnect.Models;
using PetConnect.DAL;

namespace PetConnect.Controllers
{
    public class FeedController : Controller
    {
        //Initialize database
        private PetConnectDBContext db = new PetConnectDBContext();

        // GET: Feed
        public ActionResult FriendsFeed(int Id)
        {
            var currentUser = db.Users.Find(Id);

            if (currentUser == null)
            {
                return HttpNotFound();
            }

            var friends = db.UserFriends.Where(x => x.UserId == currentUser.Id).Select(u => u.FriendId).ToList();
            var friendChirps = db.Chirps.OrderByDescending(x => x.CreateDateTime).Where(x => friends.Contains(x.UserId)).ToList();
            return View(friendChirps);
        }
    }
}