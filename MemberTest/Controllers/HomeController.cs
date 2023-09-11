using MemberTest.Models;
using MemberTest.Models.EFModels;
using MemberTest.Models.LogicModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace MemberTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
    }
}