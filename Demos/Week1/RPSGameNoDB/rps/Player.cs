using System;
namespace rps
{
    public class Player
    {

        //fields and props
        private int numWins;
        private int numLosses;

        private string fName;
        public string Fname
        {
            get { return fName; }
            set
            {
                if (value is string && value.Length < 20 && value.Length > 0)
                {
                    fName = value;
                }
                else
                {
                    throw new Exception("The player name you sent is not valid");
                }
            }
        }

        private string lName;
        public string Lname
        {
            get { return lName; }
            set
            {
                if (value is string && value.Length < 20 && value.Length > 0)
                {
                    lName = value;
                }
                else
                {
                    throw new Exception("The player name you sent is not valid!");
                }
            }
        }


    private Guid playerId = Guid.NewGuid();
        public Guid PlayerId
        {
            get
            {
                return playerId;
            }
        }





//constructors
        
        public Player(string fname = "null", string lname = "null")
        {
            this.Fname = fname;
            this.Lname = lname;
        }


//methods

        public void AddWin(){numWins++;}
        public void AddLoss(){numLosses++;}

        public int [] GetWinLossRecord(){
            int [] winsandlosses= new int[2];
            winsandlosses[0]=numWins;
            winsandlosses[1]=numLosses;

            return winsandlosses;}
    }
}