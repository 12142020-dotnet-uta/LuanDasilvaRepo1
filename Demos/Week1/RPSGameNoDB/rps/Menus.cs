using System;
namespace rps
{
    public class Menus
    {
    PlayerBase pb = new PlayerBase();
    ValidationOptions vo= new ValidationOptions();
    GameLogic gameLogic=new GameLogic();


    bool firsttimecheck;
            bool fnamecheck;
            bool lnamecheck;

            string lname;
            string fname;

        public bool IntroMenu(){

    

            Console.WriteLine("Welcome to the Rock, Paper, Scissor hub! What would you like to do?\n\n");
            Console.WriteLine
            ("1. Log In/Create user with unique name\n"+ 
            "2. Get Player-Base Lis\n"+
             "*. Quit"     
                    );
            string res=Console.ReadLine();
             if(res=="2"){
                pb.GetAllPlayer();
                return true;
            }
            if(res=="1"){
                //get user input

                do{
                  Console.WriteLine("\nUse a name that was used prior to log back in or a unique name to create a user:"+
                  "\nEnter first name: "); 
                  string tmpfname=Console.ReadLine();
                  fnamecheck=vo.ValidateUsername(tmpfname);
                
                  Console.WriteLine("\nEnter last name: "); 
                  string tmplname=Console.ReadLine();
                  lnamecheck=vo.ValidateUsername(tmplname);
                 if (fnamecheck ==true && lnamecheck==true) {
                      lname=tmplname;
                      fname=tmpfname;
                  }
                else if (fnamecheck ==false  || lnamecheck==false) {
                      Console.Clear();
                      Console.WriteLine("Invalid input. Please try again.");
                  }

                } while(fnamecheck!=true && lnamecheck!=true);

                
                    if (pb.IsFirstNLastNInSys(lname,fname)){
                        Player player = pb.FindPlayerByFNLN(fname,lname);
                        firsttimecheck=false;
                        SignedInMenu(player,firsttimecheck);
                        return true;
                    }

                    else{
                        Player player = new Player(fname,lname);
                        pb.AddPlayer(player);
                        firsttimecheck=true;
                        SignedInMenu(player, firsttimecheck);
                        return true;
                    }
            
            

            }
            
           
            
            
             return false;
        }
            



            
        

        public bool SignedInMenu(Player p, bool onetimecheck){

        bool ContinueLogin=true;
               
        
        if (onetimecheck==false){
            Console.WriteLine($"\n\nWelcome back, {p.Fname}! Your ID is {p.PlayerId}");
        }
        else{
            Console.WriteLine($"\n\nWe're happy to have you, {p.Fname}! Your ID is {p.PlayerId}");
        }
    
               
               
               
               
               
               
        do{



        Console.WriteLine("What would you like to do?");

                Console.WriteLine(" \n1. Play Against Computer"+
                "\n2. Play Against 2nd Player"+
                "\n3. Log Out");
                string res=Console.ReadLine();



                        
                if (res=="1"){
                    Console.Clear();

                    Console.WriteLine("How many consecutive rounds determine the match?\n\n"+
                    "3\n5\n7\n"
                    );
                    int minNumOfRounds= vo.ValidateOptionsToInt(Console.ReadLine());

                    if(minNumOfRounds== 3 || minNumOfRounds == 5 || minNumOfRounds==7){
                        Match match=new Match(minNumOfRounds);

                    p.AddMatch(match);

                    }


                        
                }
                if (res=="2"){
                    Console.WriteLine("This function has not been implemented!\n");
                }
                if(res=="3"){
                    ContinueLogin= false;
                    //back to login
                }






        }while(ContinueLogin);
        return false;


        }
        


           


        

 
        






    }    
}