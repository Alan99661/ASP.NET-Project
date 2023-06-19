using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameApplication.Servises.ViewModels.GameViewModels
{
    public class GameSearchModel
    {
        public string? Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? ReleaseParam { get; set; }
        public string? DeveloperId { get; set; }
        public string? ReviewId { get; set; }
        public string? PlatformId { get; set; }
        public string? GenreId { get; set; }
        public int? MetacriticRating { get; set; }
        public int? MetacriticParam { get; set; }
    }
}
