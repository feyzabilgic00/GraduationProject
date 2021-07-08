using Business.ViewModels.Block;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlockService
    {
        void AddBlock(BlockViewModel blockViewModel);
        List<BlockViewModel> GetAll();
        BlockViewModel GetBlock(int id);
        void Delete(int id);
    }
}
