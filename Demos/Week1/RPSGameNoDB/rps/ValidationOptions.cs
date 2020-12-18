using System;
using System.Collections; 
using System.Collections.Generic; 
  
namespace rps
{
    public class ValidationOptions

    //initialize 
        {
    
    
    static List<string> rock = new List<string>
            { "1","rock","rck","rkc", "rk", "rc", "r"};
    static List<string> paper = new List<string>
            {"2","paper", "papre","pape", "papr", "pap", "pp", "p"};
    static List<string> scissor = new List<string>
            {"3","scissor", "scissr","sciss","s"};

            public int ValidateRPSOptionsToInt(string arg){

                    if(rock.Contains(arg)){
                            return 1;
                    }
                    if(paper.Contains(arg)){
                            return 2;
                    }
                    if(scissor.Contains(arg)){
                            return 3;
                    }
                    else{
                            Console.WriteLine("Sorry, you've entered an incorrect format. Please try again. ");
                            return 0;

                    }


            }
        
    



        







    }
}