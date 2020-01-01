using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace RLmmr.Controllers
{
    [Route("v1/")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public Player ActivePlayer;

        //https://localhost:44332/v1/?regNr=xup968
        [HttpGet]
        [EnableCors("MyPolicy")]
        //public IEnumerable<string> ParseReg(string regNr)
        public ActionResult<Player> ParseMMR(string steamusername)
        {
            try
            {
                ActivePlayer = new Player();

                int _1sIndex = -1;
                int _2sIndex = -1;
                int _3sIndex = -1;
                int _soloIndex  = -1;
                int _hoopsIndex = -1;
                int _rumbleIndex = -1;
                int _dropshotIndex = -1;
                int _snowdayIndex = -1;

        Utils.Web.Navigate("https://rocketleague.tracker.network/profile/steam/" + steamusername);


                for (int i = 1; i<= 10; i++)
                {
                    //Debug.WriteLine(Utils.Web.GetInnerText("//*[@id=\"season-13\"]/table[2]/tbody/tr[" + i + "]/td[2]"));
                    try
                    {
                        string _temp = Utils.Web.GetInnerText("//*[@id=\"season-13\"]/table[2]/tbody/tr[" + i + "]/td[2]");

                        if (_temp.Contains("Ranked Duel 1v1"))
                            _1sIndex = i;
                        else if (_temp.Contains("Ranked Doubles 2v2"))
                            _2sIndex = i;
                        else if (_temp.Contains("Ranked Standard 3v3"))
                            _3sIndex = i;
                        else if (_temp.Contains("Ranked Solo Standard 3v3"))
                            _soloIndex = i;
                        else if (_temp.Contains("Hoops"))
                            _hoopsIndex = i;
                        else if (_temp.Contains("Rumble"))
                            _rumbleIndex = i;
                        else if (_temp.Contains("Dropshot"))
                            _dropshotIndex = i;
                        else if (_temp.Contains("Snowday"))
                            _snowdayIndex = i;
                    }
                    catch
                    {

                    }
                    
                }



                ////*[@id="season-13"]/table[2]/tbody/tr[4]/td[2]
                ActivePlayer.SteamUsername = steamusername;
                ActivePlayer._1sMMR = Utils.GetRawMMR(Utils.Web.GetInnerText("//*[@id=\"season-13\"]/table[2]/tbody/tr[" + _1sIndex + "]/td[4]"));
                ActivePlayer._2sMMR = Utils.GetRawMMR(Utils.Web.GetInnerText("//*[@id=\"season-13\"]/table[2]/tbody/tr[" + _2sIndex + "]/td[4]"));
                ActivePlayer._3sMMR = Utils.GetRawMMR(Utils.Web.GetInnerText("//*[@id=\"season-13\"]/table[2]/tbody/tr[" + _3sIndex + "]/td[4]"));
                ActivePlayer._soloMMR = Utils.GetRawMMR(Utils.Web.GetInnerText("//*[@id=\"season-13\"]/table[2]/tbody/tr[" + _soloIndex + "]/td[4]"));
                ActivePlayer._hoopsMMR = Utils.GetRawMMR(Utils.Web.GetInnerText("//*[@id=\"season-13\"]/table[2]/tbody/tr[" + _hoopsIndex + "]/td[4]"));
                ActivePlayer._rumbleMMR = Utils.GetRawMMR(Utils.Web.GetInnerText("//*[@id=\"season-13\"]/table[2]/tbody/tr[" + _rumbleIndex + "]/td[4]"));
                ActivePlayer._dropshotMMR = Utils.GetRawMMR(Utils.Web.GetInnerText("//*[@id=\"season-13\"]/table[2]/tbody/tr[" + _dropshotIndex + "]/td[4]"));
                ActivePlayer._snowdayMMR = Utils.GetRawMMR(Utils.Web.GetInnerText("//*[@id=\"season-13\"]/table[2]/tbody/tr[" + _snowdayIndex + "]/td[4]"));

            }
            catch (Exception exception)
            {
                return NotFound();
                //Utils.ShowErrorBox(regNr + " is not a vehicle that is supported by the program.", exception);
            }

            
            return ActivePlayer;
        }
    }
}
