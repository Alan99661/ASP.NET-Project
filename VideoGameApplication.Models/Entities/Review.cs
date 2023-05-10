using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Models.BaseClasses;

namespace VideoGameApplication.Models.Entities
{
    internal class Review : BaseModel
    {
        public User User { get; set; }
        public Game Game { get; set; }
        public string Content { get; set; }
    }
}
