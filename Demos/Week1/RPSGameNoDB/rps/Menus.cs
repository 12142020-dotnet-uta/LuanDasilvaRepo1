using System;
namespace rps
{
    public class Menus
    {
    PlayerBase pb = new PlayerBase();

    Match match=new Match();


    bool firsttimecheck;

        public void IntroMenu(){

            Console.WriteLine("Welcome to the Rock, Paper, Scissor hub! What would you like to do?\n\n");
            Console.WriteLine
            ("1. Log In/Create user with unique name\n"+ 
             "*. Quit"     
                    );

            if(Console.ReadLine()=="1"){
                  Console.WriteLine("\nUse a name that was used prior to log back in or a unique name to create a user:"+
                  
                  "\nEnter first name: "); 

                  string tmpfname=Console.ReadLine();

                  Console.WriteLine("\nEnter last name: "); 
                  string tmplname=Console.ReadLine();

                if (pb.isFirstNLastNInSys(tmpfname,tmplname)){
                    Player p = pb.findPlayerByFNLN(tmpfname,tmplname);
                    firsttimecheck=false;
                    SignedInMenu(p,firsttimecheck);
                    
                }
                else{
                    Player player = new Player(tmpfname,tmplname);
                    pb.addPlayer(player);
                    firsttimecheck=true;
                    SignedInMenu(player, firsttimecheck);
                }
            }
        }

        public void SignedInMenu(Player p, bool onetime){
            if (onetime==false){
                Console.WriteLine($"\n\nWelcome back, {p.Fname}! Your ID is {p.PlayerId}");
            }
        else{
            Console.WriteLine($"\n\nWe're happy to have you, {p.Fname}! Your ID is {p.PlayerId}");
        }


        Console.WriteLine("What would you like to do?");

        Console.WriteLine(" \n1. Play Against Computer"+
        "\n2. Play Against 2nd Player"+
        "\n3. Log Out");
        string res=Console.ReadLine();



                 
        if (res=="1"){
                string winner=match.quickMatchComputer();
                Console.WriteLine(winner);
        }
        if (res=="2"){
            Console.WriteLine("This function has not been implemented!\n");
        }
        else{
            //back to login
        }




 
        }
    }
}