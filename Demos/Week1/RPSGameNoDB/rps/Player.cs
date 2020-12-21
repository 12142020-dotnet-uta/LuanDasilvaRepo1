using System;
using System.Collections.Generic;
namespace rps
{
    public class Player
    {

        //fields and propsivate int numLosses;
        private List<Match> matchlist;
        public List<Match> MatchList
        {
            get{return matchlist;}
        }

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
        
        public void AddMatch(Match match){
            try{
                matchlist.Add(match);
            }catch(Exception NullReferenceExceptio){
                Console.WriteLine("Something went wrong adding your match to your player's history!");
            }

            }


}


}