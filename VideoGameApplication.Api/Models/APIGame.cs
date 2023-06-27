using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameApplication.Api.Models
{
    public class ApiGame : ApiModel
    {
        public string? Description_raw { get; set; }
        public string? Website { get; set; }
        public string? Released { get; set; }
        public string? background_image { get; set; }
        public int? Metacritic { get; set; }
        public List<ApiPlatforms>? parent_platforms { get; set; }
        public List<ApiModel>? Genres { get; set; }
        public List<ApiModel>? Developers { get; set; }
        public List<ApiScreenshot>? ShortScreenshots { get; set; }
    }
}
