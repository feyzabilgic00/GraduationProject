using AutoMapper;
using Business.Abstract;
using Business.ViewModels.Block;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Controllers
{
    public class BlockController : Controller
    {
        private readonly IBlockService _blockService=null;
        private readonly IMapper _mapper;
        public BlockController(IBlockService blockService,IMapper mapper)
        {
            _blockService = blockService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var reselt=_blockService.GetAll();
            return View(reselt);
        }
        public IActionResult AddBlock()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBlock(BlockViewModel blockViewModel)
        {
            _blockService.AddBlock(blockViewModel);
            return RedirectToAction("Index","Block");
        }
        public IActionResult DeleteBlock(int id)
        {
            _blockService.Delete(id);
            return RedirectToAction("Index","Block");
        }
    }
}
