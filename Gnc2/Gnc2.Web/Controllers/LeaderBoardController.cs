using Gnc2.Service.ServiceLeaderBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gnc2.Controllers
{
    public class LeaderBoardController : BaseController
    {
        public PartialViewResult Default()
        {
            Gnc2.Service.ServiceLeaderBoard.LeaderBoardClient sLeaderBoard = new Service.ServiceLeaderBoard.LeaderBoardClient();

           //LeaderListModel leaderList =  sLeaderBoard.Top5("A4B38CCC-FDC4-4413-B6F2-085806B327E5",5);

            //var qq = sLeaderBoard.Top5("A4B38CCC-FDC4-4413-B6F2-085806B327E5", 5);

           //return PartialView(qq);
            return PartialView();
            
        }
    }
}


  

           

       