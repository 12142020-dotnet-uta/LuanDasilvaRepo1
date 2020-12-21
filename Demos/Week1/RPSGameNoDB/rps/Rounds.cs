
using System.Collections.Generic;
using System;
namespace rps
{
    public class Rounds
    {
    private int otherPlayerStreakCheck;
    public int OtherPlayerStreakCheck{
        get {return otherPlayerStreakCheck;}
        set{otherPlayerStreakCheck=value;}
    }

    private int playerStreakCheck;
    public int PlayerStreakCheck{
        get {return playerStreakCheck;}
        set{playerStreakCheck=value;}
    }
    private Guid matchroundsid= new Guid();
    
    public Guid MatchRoundsID
    {
        get { return matchroundsid; }
    }


    private int roundsMin;
    public int RoundsMin
    {
        get{return roundsMin;}
        set { roundsMin = value; }
    }
    


 
}} 