using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameApplication.Servises.ViewModels.ReviewViewModels
{
    internal class ReviewUpdateModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string GameId { get; set; }
        public string Content { get; set; }
    }
}
