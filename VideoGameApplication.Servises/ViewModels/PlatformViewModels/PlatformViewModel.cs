using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Models.Entities;

namespace VideoGameApplication.Servises.ViewModels.PlatformViewModels
{
    public class PlatformViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Game> Games { get; set; }
    }
}
