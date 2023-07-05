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
        public virtual User User { get; set; }
        public string UserName { get; set; }
        public virtual Game Game { get; set; }
        public string Content { get; set; }
		public bool Certified { get; set; }
        public float PlayTimeHours { get; set; }
    }
}
