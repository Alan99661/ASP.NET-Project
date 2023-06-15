using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Models.BaseClasses;

namespace VideoGameApplication.Models.Entities
{
    public class Review : BaseModel
    {
        public User User { get; set; }
        public Game Game { get; set; }
        public string Content { get; set; }
		public bool Certified { get; set; }
    }
}
