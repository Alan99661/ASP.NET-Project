using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameApplication.Models.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }
        //public string UName { get; set; }
    }
}
