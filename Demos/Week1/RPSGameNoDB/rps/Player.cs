using System;
namespace rps
{
    public class Player
    {
        private int numWins;
        private int numLosses;
        
        private  int playerID;
        public int PlayerID { 
            get{return playerID;} 
            set{if (value>0){
                playerID=value;
            } else{ throw new Exception("Bad value");}
            
            } }

        private string fName;
        public string Fname
        {
            get { return fName; }
            set {
                if (value is string &&  value.Length<20 && value.Length>0){
                    fName=value;
                } else
                {
                    throw new Exception("Player name doesn't meet requirements");
                } }
        }
        






        public void AddWin(){numWins++;}
        public void AddLoss(){numLosses++;}

        public int [] GetWinLossRecord(){
            int [] winsandlosses= new int[2];
            winsandlosses[0]=numWins;
            winsandlosses[1]=numLosses;

            return winsandlosses;
        }



    }
}