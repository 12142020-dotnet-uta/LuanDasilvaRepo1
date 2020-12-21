using System;
using System.Collections.Generic;
namespace rps

{
    public class GameLogic
    {
        public bool DoesMatchContinue(Rounds rounds,int minNet){
            int otCheck= rounds.OtherPlayerStreakCheck;
            int pCheck=rounds.PlayerStreakCheck;
            Console.WriteLine("\n\n your score \t other player score");
            Console.WriteLine($"{pCheck}  \t\t  {otCheck}");
            
            if(otCheck ==minNet || pCheck ==minNet){
                return false;
            }return true;
        }
    }
}