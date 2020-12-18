using System;
using System.Collections.Generic;
using System.Linq;

namespace rps
{
    public class PlayerBase
    {
    static private List<Player> playerBase;
    private static List<Guid> playerBaseGuidList;
    private static List<string> playerBaseFnameList;
    private static List<string> playerBaseLnameList;






        //methods

        public bool addPlayer(Player p){
            try{
                playerBase.Add(p);

                playerBaseGuidList.Add(p.PlayerId);
                playerBaseFnameList.Add(p.Fname);
                playerBaseLnameList.Add(p.Lname);

                return true;
            }
            catch (Exception NullReferenceException){
                Console.WriteLine("Exception here?");
                return false; ///addds to list but also throws exception?????????
            }
        }
        public Player findPlayerByFNLN(string fname, string lname)
            {
            


                foreach(var player in playerBase){
                if(player.Fname==fname){
                    if(player.Lname==lname){
                        return player;
                    }
                }
            }
            return null;}


        public List<Guid> GetIDList()
            { return playerBaseGuidList; }
        public List<Player> GetPBList()
            { return playerBase; }

        public bool isFirstNLastNInSys(string fname, string lname){
                
            if(playerBaseFnameList!=null && playerBaseLnameList!=null){
                if (playerBaseFnameList.Contains(fname)){
                    if(playerBaseLnameList.Contains(lname)){
                        return true;
                    }
                }}return false;  

             
             
    }


}
}