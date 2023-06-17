using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Models.BaseClasses;

namespace VideoGameApplication.Models.Entities
{
    public class Platform : BaseModel
    {
        public string Name { get; set; }
        public virtual List<Game>? Games { get; set; }

    }
}
