using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Models.Entities;

namespace VideoGameApplication.Servises.ViewModels.DeveloperViewModels
{
    internal class DeveloperAddModel
    {
        public string Name { get; set; }
        public List<string> GameIds { get; set; }
    }
}
