using System;
using System.Collections.Generic;
namespace rps

{
    public class GameTypes
    {
        public void defaultComputer(Rounds rounds){
            Console.Clear();

            GameLogic gameLogic=new GameLogic();
            Console.Clear();
            ValidationOptions vo= new ValidationOptions();



            int p1Choice;
            
       

            int minroundsdif=(rounds.RoundsMin+1)/2;

            int roundNum=0;

            Random randomNum =new Random();
            int computerChoice;



            while(gameLogic.DoesMatchContinue(rounds, minroundsdif)) //game logic send in rounds reference so that you can ccheck rounds lis
            {
            roundNum+=1;


    
            do{
            
            computerChoice = randomNum.Next(1, 4);

                Console.WriteLine($"Current Round Num = {roundNum}\n\n"+ "----------------------");
                Console.WriteLine("Place choose r, p, or s \n\t1, 2, 3 respectively");
                string uR= Console.ReadLine();
                
                p1Choice=vo.ValidateRPSOptionsToInt(uR);
            
                if (p1Choice==0 ){
                    Console.WriteLine("Your response is invalid");
                }}   while(p1Choice==0);
                //end do

            
                
                Console.WriteLine($"You entered: {p1Choice}\n");

                Console.WriteLine($"The computer entered: {computerChoice}\n\n");

                Console.WriteLine("The result is: ");

                if (p1Choice==computerChoice){
                Console.WriteLine ("Tie");


                }
                else if 
                    ((p1Choice==2 && computerChoice==1)||
                    (p1Choice==3 && computerChoice==2)||
                    (p1Choice==1 && computerChoice==3)){
                        Console.WriteLine("You win!");
                        rounds.PlayerStreakCheck+=1;
                        rounds.OtherPlayerStreakCheck=0;
                }

                else{
                    Console.WriteLine ("The computer won");
                    rounds.PlayerStreakCheck=0;
                    rounds.OtherPlayerStreakCheck+=1;
                }


                







            }
        }
    }
}