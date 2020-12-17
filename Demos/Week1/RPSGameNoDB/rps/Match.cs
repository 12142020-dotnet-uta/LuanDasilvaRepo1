using System.Collections.Generic;

namespace rps

{
    public class Match
    {

        public int MatchID{get;set;}
        public Player Player1{get;set;}//always computer for now
        public Player Player2{get;set;}//always player for now
        List<Rounds> Rounds=new List<Rounds>();

        private int p1wins{get; set;}
    private int p2wins{get; set;}
    public void RoundWinner(Player p=null){
        if(p==Player1){
            p1wins++;
        }
        else if(p==Player2) {
            
        }

    }
    }

}