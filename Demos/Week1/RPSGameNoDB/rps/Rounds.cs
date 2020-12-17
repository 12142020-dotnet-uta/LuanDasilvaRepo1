using System;
using rps;

public class Rounds
    {
        int userChoice=0;





    ValidationOptions vo= new ValidationOptions();
    public string quickMatchComputer(){
    do{
           Console.WriteLine("Place choose r, p, or s \n\t1, 2, 3 respectively");
           string uR= Console.ReadLine();
           
           userChoice=vo.ValidateToInt(uR);
           


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
