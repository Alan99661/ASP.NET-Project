using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameApplication.Servises.ViewModels.GenreViewModels
{
    public class GenreUpdateModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string>? GameIds { get; set; }
    }
}
