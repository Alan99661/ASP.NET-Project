using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Database;
using VideoGameApplication.Servises.Contracts.UpdateModelGet;
using VideoGameApplication.Servises.ViewModels.DeveloperViewModels;

namespace VideoGameApplication.Servises.OtherOperations
{
    public class GetUpdateModels : IGetUpdateModels
    {
        private readonly VideoGameDBContext context;
        private readonly IMapper mapper;

        public GetUpdateModels(VideoGameDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public DeveloperUpdateModel GetDevUpdateModel(string id)
        {
            var res = context.Developers.FirstOrDefault(x => x.Id == id);
            return mapper.Map<DeveloperUpdateModel>(res);
        }
    }
}
