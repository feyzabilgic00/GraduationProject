using AutoMapper;
using Business.ViewModels.Apartment;
using Business.ViewModels.Block;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class BlockProfile:Profile
    {
        public BlockProfile()
        {
            CreateMap<Block, BlockViewModel>().ReverseMap();
          
            //var config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<Block, BlockViewModel>().ReverseMap();
            //});
            //config.AssertConfigurationIsValid();
            
        } 
    }
}
