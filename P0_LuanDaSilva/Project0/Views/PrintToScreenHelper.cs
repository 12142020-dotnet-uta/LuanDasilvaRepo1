using System;
using System.Collections.Generic;


using Models;
using DataAccessLayer;
using System.Threading.Tasks;

namespace Views
{
        //we need a helper to decide how our tour guide speaks 
        //depeneding on tg.Result which the user inputs
    public class PrintToScreenHelper
    {

    public static TourGuide TourGuideHelper(TourGuide tg){
         Project0RepoLayer p0Context = new Project0RepoLayer(); // create the context here to acceess it in all methods of this class 
                switch (tg.Result)
                {
                    case "-1": 
                        Console.Clear(); tg.Words="Thank you for your stay at the abstract museum!";
                        break;
                    case "-2":
                    Console.Clear();
                    Console.WriteLine("Logging you out and taking you back to the main screen. Press enter to continue");
                    Console.ReadLine();
                    tg=new TourGuide();
                    tg.Result="0";
                    return tg;

                    case "1":
                        tg=InitLogin(tg);
                        break;
                    case "2":
                        tg=LogIn(tg);
                        break;
                    case "3":
                        ViewFloor();
                        break;
                    case "4":
                        ViewFloorTour(tg.User);
                        break;
                    #nullable enable
                    case "5":
                        IEnumerable<FloorTourUsrLine>? usrTours= p0Context.GetUsersPastTour(tg.User);
                        if (usrTours!=null){
                            Console.Clear();
                            IEnumerable<FloorTourUsrLine> uT = (IEnumerable<FloorTourUsrLine>) usrTours;
                            int count=0;
                            foreach (var ut in uT){
                                Tour? t = p0Context.FindTour(ut.TourID);
                                if(t!=null){
                                Tour tour= (Tour) t;
                                Console.WriteLine($"\n{++count}. Floor name: {t.LocationCodeName} - At row number:{t.RowNum}\tOn Date: {ut.TourTakenAt}");
                            }}
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                        }
                        break;
                    #nullable disable


                    case "6":
                    ViewAllPaintingsHelper();
                    break;






                    
                    case "Admin":

 
                    Validator validator=new Validator();
                    Console.Write("Enter floor name: "); string floorName=Console.ReadLine();
                    Console.Write("Enter floor size (max 7):"); int? floorSize = validator.ValidateStringToInt(Console.ReadLine())!;
                    Console.Write("Enter floor size: "); int? totalTours = validator.ValidateStringToInt(Console.ReadLine())!;

                    if(floorSize!=null && totalTours!=null){
                        int x=(int) floorSize;
                        int y =(int) totalTours;
                        p0Context.DBCreateBaseFloor(floorName, x, y);
                    }
                    break;



                }
                return tg;
            
            }  

   //login helper methods
    public static TourGuide InitLogin(TourGuide tg){

                Project0RepoLayer p0Context = new Project0RepoLayer(); // create the context here to acceess it in all methods of this class                Console.Clear();
                Validator validator=new Validator();
                string tmpCheckString;
                bool tmpCheck=true;
                
                        string un="0";
                        string fn="0";
                        string ln="0"; //usr/first/last name

                        Console.WriteLine("We need some information before we start:");
                        while(tg.Result!="-2"){
                            //prompt for input 
                            Console.Write("\nEnter a unique name: ");
                            un= validator.InputConstraints(Console.ReadLine()); 
                            Console.Write("\nEnter your first name: ");
                            fn=(Console.ReadLine()); 
                            Console.Write("\nEnter your last name: ");
                            ln=validator.InputConstraints(Console.ReadLine()); 
                           
                            if(un=="0" || fn=="0"||ln=="0"){
                                Console.WriteLine("Looks like you've inputted an incorrect format. We will take you back to the main menu. Press enter to continue.");
                                Console.ReadLine();
                                return tg;

                            }

                                //confirm user create
                                do{
                                    Console.Clear();
                                    Console.WriteLine($"Creating user with: \nUsername - {un}\tFirst Name - {fn}\tLast Nmae - {ln}");
                                    Console.Write("\n\n\nEnter y to create this user and log in. Enter n to go back to the main menu: ");
                                    tmpCheckString = Console.ReadLine();
                                    if(tmpCheckString=="y"){
                                        User user=p0Context.CreateUser(un,fn,ln);
                                        List<string> acceptable =new List<string> {"-1","-2","3","4","5","6","7"};
                                        tg = new TourGuide($"Welcome {user.Username}!", "What would you like to do?\n\n3. View Floor\n4. Book a tour\n5. View All Paintings\n6. View Past Tours\n\n\n-2. Logout\n-1. Quit Out", "-2", acceptable, user);
                                        tmpCheck=true;    
                                    }
                                    else if(tmpCheckString=="n"){
                                        tg= new TourGuide();
                                        tg.Result="-2";
                                        tmpCheck=true;
                                    }
                                    else{
                                        tmpCheck=false; 
                                    }
                                

                                }while(!tmpCheck);
                       
                           
                        }return tg;
                        
    }
    public static TourGuide LogIn(TourGuide tg){
            
            Project0RepoLayer p0Context = new Project0RepoLayer(); // create the context here to acceess it in all methods of this class                Console.Clear();
            Validator validator=new Validator();

            Console.Clear();
            Console.Write("Great to see you again! You can quit to the main menu by entering '-2'. Enter your unique username: ");
            tg.Result = Console.ReadLine(); 
               if(tg.Result!="-2"){
                   
                        tg.Result=validator.InputConstraints(tg.Result); 
                        User user = p0Context.FindUser(tg.Result);
                        if(user==null){
                            Console.Clear();
                            Console.WriteLine("We were not able to locate that user.\nWe will return you to the previous screen. Press enter to continue: ");
                            Console.ReadLine();
                            tg.Result="0";
                        }
                        else{
                            List<string> acceptable =new List<string> {"-1", "-2","3","4","5","6"};
                            tg = new TourGuide($"Welcome {user.Username}!\n", "What would you like to do?\n\n3. View Floor\n4. Book a tour\n5. View Past Tours\n6. View Paintings\n\n\n-2. Logout\n-1. Quit Out", "0", acceptable, user);
                            return tg;
                        }
               
                    
                }
                
                return tg;
                

    }
    
    


        public static void ViewAllPaintingsHelper(){
            Console.Clear();
        Project0RepoLayer p0Context = new Project0RepoLayer(); // create the context here to acceess it in all methods of this class                Console.Clear();
        Validator validator=new Validator();
        Console.WriteLine("\n\nPlease choose a floor to view:\n*Note: if input is an incorrect number or other characters, we will take you back to the previous menu!\n");
        List<string> lst= p0Context.FindAllFloors();
        int count=0;
        foreach(string str in lst){
            Console.WriteLine($"{++count}. {str}");
        }
        string userInput = Console.ReadLine();
    #nullable enable
        int? floorNumberChoice= validator.ValidateStringToInt(userInput);
       
        if(floorNumberChoice.HasValue){
            int fNC=(int) floorNumberChoice;
            --fNC;
            string floorName = lst[fNC];

            if(fNC<lst.Count){
                int countt=0;
                    List<string> paintings= p0Context.FindAllPaintings(floorName);
                    foreach (string item in paintings)
                    {
                        Console.WriteLine($"{++countt}. {item}");
                    }
                    Console.WriteLine("Press enter to continue: ");
                    Console.ReadLine();
            }
        }
        }
    
    public static void ViewFloor(){
        Console.Clear();
        Project0RepoLayer p0Context = new Project0RepoLayer(); // create the context here to acceess it in all methods of this class                Console.Clear();
        Validator validator=new Validator();
        Console.WriteLine("\n\nPlease choose a floor to view:\n*Note: if input is an incorrect number or other characters, we will take you back to the previous menu!\n");
        List<string> lst= p0Context.FindAllFloors();
        int count=0;
        foreach(string str in lst){
            Console.WriteLine($"{++count}. {str}");
        }
        string userInput = Console.ReadLine();
    #nullable enable
        int? floorNumberChoice= validator.ValidateStringToInt(userInput);
       
        if(floorNumberChoice.HasValue){
            int fNC=(int) floorNumberChoice;
            --fNC;

            if(fNC<lst.Count){
                    
                    string floorName=lst[fNC];
                    BaseFloor? chosenFloor = new BaseFloor();
                    chosenFloor= p0Context.GetFloor(floorName);

                    Console.Clear();

                    if (chosenFloor!=null){
                        BaseFloor cF= (BaseFloor) chosenFloor;
                    
                    Console.WriteLine($"Currently viewing the {cF.LocationCodeName} exhibit, with {cF.LocationSize} rows. \nThere are {cF.LocationRemainingTours} tours left to take.\n");
                    MatrixHelper.Print2DArray(MatrixHelper.generateMatrix(cF.LocationSize));
                    Console.WriteLine("\nPress enter to continue...");
                    Console.ReadLine();}
            }}
#nullable disable

        

        

    }




public static int GoOnFloorTour(string floorName, int locationSize, int rowChoice){
        Project0RepoLayer p0Context = new Project0RepoLayer(); // create the context here to acceess it in all methods of this class                Console.Clear();
        Validator validator=new Validator();
        int totalCost = 0;
            int rc = rowChoice-1;
            int [,] matrix= MatrixHelper.generateMatrix(locationSize);
                for (int i =0; i<locationSize; i++){
                matrix[rc, i] = 1;
                   
                    Console.Clear();
                    MatrixHelper.Print2DArray(matrix);
                     matrix[rc, i] = 1;
                    Painting p =p0Context.FindPainting(floorName, rowChoice, i+1);
                    

                    Console.WriteLine($"You're in room number  {i} on this tour.The cost so far is {totalCost}\n\n The painting of this room is called {p.PaintingName} with id: {p.PaintingID}\n\nPress enter to proceed: ");
                    Console.ReadLine();
                totalCost += p.Cost;

        } 
  
        
        
        return totalCost;

}

public static void ViewFloorTour(User u)
{
        Console.Clear();
        Project0RepoLayer p0Context = new Project0RepoLayer(); // create the context here to acceess it in all methods of this class                Console.Clear();
        Validator validator=new Validator();
        Console.WriteLine("\n\nPlease choose a floor to view:\n*Note: if input is an incorrect number or other characters, we will take you back to the previous menu!\n");
        List<string> lst= p0Context.FindAllFloors();
        int count=0;
        foreach(string str in lst){
            Console.WriteLine($"{++count}. {str}");
        }
        string userInput = Console.ReadLine();
    #nullable enable
        int? floorNumberChoice= validator.ValidateStringToInt(userInput);
       
        if(floorNumberChoice.HasValue){
            int fNC=(int) floorNumberChoice;
            --fNC;
            string floorName = lst[fNC];

            if(fNC<lst.Count){
                BaseFloor floor = p0Context.GetFloor(floorName)!;
                Console.WriteLine($"What row would you like to tour? Your options are 1-{floor.LocationSize}:");

                int? uRC=validator.ValidateStringToInt(Console.ReadLine());
                
                if (uRC!=null){
                    int usrRowChoice=(int) uRC;
                    int n = floor.LocationSize+1;
            

                    if(floor.LocationRemainingTours!=0){
                            bool tbool=p0Context.RemoveTourFromFloor(floorName);

                        if(tbool && usrRowChoice <n){
                            Tour tour=p0Context.FindTour(floorName, usrRowChoice)!;
                            Console.Clear();
                            p0Context.CreateFloorTourUsrLine(floorName, tour.TourID ,u.UserID);

                            int priceOfTour= GoOnFloorTour(floorName, floor.LocationSize, usrRowChoice);


                            Console.WriteLine("Tour completed!");
                        }

                    }else{
                        Console.WriteLine($"We are sorry but the {floorName} does not have any remaining tours! Please check another time!");
                    }

                    
                    Console.WriteLine("\n\nPress enter to continue");
                    Console.ReadLine();
                }}

    
#nullable disable


    }



}






    }
    
}


