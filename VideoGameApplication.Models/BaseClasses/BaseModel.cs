using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Models.Interfaces;

namespace VideoGameApplication.Models.BaseClasses
{
    public class BaseModel : IBaseModel
    {
        public BaseModel() 
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
