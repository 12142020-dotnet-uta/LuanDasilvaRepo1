using System;
using System.Collections.Generic;

namespace rps

{
    public class Match
        {
            Rounds matchRoundsReference= new Rounds();
            //variables

            private int winOrLose;
            public int WinOrLose
            {
                get { return winOrLose; }
                set {
                
                if(value==-1 ||value==1){ winOrLose = value;}
                else{Console.WriteLine("A match is determined to either be a loss (-1) or a win (+1)");
                } 
                
                }
            }
            


//different matches constructors

// not defining a second player defaults to playing the computer
            public Match (int min){
                matchRoundsReference.RoundsMin=min;
                GameTypes gameTypes=new GameTypes();
                gameTypes.defaultComputer(matchRoundsReference);
            
     
            



                }



        


}

}