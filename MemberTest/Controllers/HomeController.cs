using AutoMapper;
using AutoMapper.Execution;
using MemberTest.Models;
using MemberTest.Models.EFModels;
using MemberTest.Models.LogicModels;
using MemberTest.Models.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Diagnostics;

namespace MemberTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            //MemberLogic memberLogic = new MemberLogic();
            // read
            //var temp1 = memberLogic.GetMemberList();
            
            // create
            //Member member = new Member()
            //{
            //    Name = "黃美麗",
            //    Sex = true,
            //    Birthday = DateTime.Parse("1988-3-2"),
            //    Phone = "0920333444",
            //    Mail = "mie@gamil.com",
            //    Address = "台南市"
            //};
            //var temp2 = memberLogic.AddMember(member);

            // update
            //Member member2 = new Member()
            //{
            //    Sn = 2,
            //    Name = "黃美麗",
            //    Sex = false,
            //    Birthday = DateTime.Parse("1988-3-2"),
            //    Phone = "0920333444",
            //    Mail = "mie@gamil.com",
            //    Address = "台南市"
            //};
            //var temp3 = memberLogic.UpdateMember(member2);

            // delete
            //var temp4 = memberLogic.DeleteMember(2);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult MemberList()
        {
            MemberLogic memberLogic = new MemberLogic();
            var model = memberLogic.GetMemberList();
            var viewModel = _mapper.Map<List<Models.EFModels.Member>, List< MemberViewModel>>(model);
            return View(viewModel);
        }

        public IActionResult AddMember()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMember(MemberViewModel viewModel)
        {
            MemberLogic memberLogic = new MemberLogic();
            // 確認資料正確性
            viewModel = memberLogic.IsValid(viewModel);
            if (viewModel.IsVaild) // 正確新增資料
            {
                var member = _mapper.Map<MemberViewModel, Models.EFModels.Member>(viewModel);
                if (memberLogic.AddMember(member))
                {
                    viewModel.Msg = "新增成功";
                }
                else
                {
                    viewModel.Msg = "新增失敗";
                }
            }
            return Content(viewModel.Msg);
        }

        public IActionResult UpdateMember(int sn)
        {
            MemberLogic memberLogic = new MemberLogic();
            var member = memberLogic.GetMember(sn);
            var viewModel = _mapper.Map<Models.EFModels.Member, MemberViewModel>(member);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult UpdateMember(MemberViewModel viewModel)
        {
            MemberLogic memberLogic = new MemberLogic();
            viewModel = memberLogic.IsValid(viewModel);
            // 確認資料正確性
            viewModel = memberLogic.IsValid(viewModel);
            if (viewModel.IsVaild) // 正確新增資料
            {
                var member = _mapper.Map<MemberViewModel, Models.EFModels.Member>(viewModel);
                if (memberLogic.UpdateMember(member))
                {
                    viewModel.Msg = "編輯成功";
                }
                else
                {
                    viewModel.Msg = "編輯失敗";
                }
            }
            return Content(viewModel.Msg);
        }

        public IActionResult DeleteMember(int sn)
        {
            MemberLogic memberLogic = new MemberLogic();
            var successful = memberLogic.DeleteMember(sn);
            return Content(successful ? "刪除成功" : "刪除失敗");
        }
    }
}