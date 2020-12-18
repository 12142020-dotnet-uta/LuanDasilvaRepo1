using System;
using System.Collections.Generic;

namespace rps

{
    public class Match
{
    //variables
    int p1Choice;
    int p2Choice;
    int numRounds;
    int userChoice;

    //utility constructors
    public string quickMatchComputer(){
    ValidationOptions vo= new ValidationOptions();
    do{
           Console.WriteLine("Place choose r, p, or s \n\t1, 2, 3 respectively");
           string uR= Console.ReadLine();
           
           userChoice=vo.ValidateRPSOptionsToInt(uR);
           


        if (userChoice==0 ){
            return ("Your response is invalid");
        }}   while(userChoice==0);

    
           
        Console.WriteLine($"You entered: {userChoice}");

        Random randomNum =new Random();
        int computerChoice = randomNum.Next(1, 4);

        Console.WriteLine(computerChoice);

        if (userChoice==computerChoice){
           return ("Tie");
        }
        else if 
            ((userChoice==2 && computerChoice==1)||
            (userChoice==3 && computerChoice==2)||
            (userChoice==1 && computerChoice==3)){
                return("LETS GO");
        }

        else{
            return ("The computer won");
        }


        }



}

}