using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Models.Entities;

namespace VideoGameApplication.Servises.ViewModels.ReviewViewModels
{
    public class ReviewAddModel
    {
        public string UserId { get; set; }
        public string GameId { get; set; }
        public string Content { get; set; }
        public float? PlayTimeHours { get; set; }

	}
}
