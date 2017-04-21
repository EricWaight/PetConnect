using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Collections;

namespace PetConnect.Models
{
    public enum Species
    {
        Cat, Dog, Bird, Rabbit, Duck
    }

    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string ProfilePicUrl { get; set; }
        public Species? Species { get; set; }

        public virtual ICollection<Chirps> Chirps { get; set; }
        public virtual ICollection<UserFriends> Friends { get; set; }
    }
}