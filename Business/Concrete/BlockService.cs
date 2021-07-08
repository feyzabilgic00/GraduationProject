using AutoMapper;
using Business.Abstract;
using Business.ViewModels.Block;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlockService : IBlockService
    {
        public IBlockDal _blockDal;
        private readonly IMapper _mapper;
        public BlockService(IBlockDal blockDal,IMapper mapper)
        {
            _blockDal = blockDal;
            _mapper = mapper;
        }
        public void AddBlock(BlockViewModel blockViewModel)
        {
            Block block = new Block {BlockName=blockViewModel.BlockName};
             _blockDal.Add(block);
        }

        public List<BlockViewModel> GetAll()
        {
            return _mapper.Map<List<BlockViewModel>>(_blockDal.GetAll());
        }

        public void Delete(int id)
        {
            Block block = _blockDal.Get(i=>i.Id==id);
            _blockDal.Delete(block);
        }
        public BlockViewModel GetBlock(int id)
        {
            Block block = _blockDal.Get(i => i.Id == id);
            return _mapper.Map<Block,BlockViewModel>(block);
        }
    }
}
