using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Models.BaseClasses;

namespace VideoGameApplication.Models.Entities
{
    public class Screenshot : BaseModel
    {
        public string Url { get; set; }
        public virtual Game Game { get; set; }
    }
}
