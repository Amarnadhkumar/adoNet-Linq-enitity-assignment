using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Asp.netmvc.context;

namespace MvcCrudOperation.Controllers
{
    public class FootballController : Controller
    {
        // GET: Football
        aspNetEntities dbobj = new aspNetEntities();
        public ActionResult Football()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFootball(FootBall model)
        {
            if (ModelState.IsValid)
            {
                FootBall footBallLeague = new FootBall();
         
                footBallLeague.TeamName1 = model.TeamName1;
                footBallLeague.TeamName2 = model.TeamName2;
                footBallLeague.Matchresult = model.Matchresult;
                footBallLeague.WinningTeam = model.WinningTeam;
                footBallLeague.Points = model.Points;
                dbobj.FootBalls.Add(footBallLeague);
                dbobj.SaveChanges();
            }
            ModelState.Clear();

            return View("Football");
        }
    }
}