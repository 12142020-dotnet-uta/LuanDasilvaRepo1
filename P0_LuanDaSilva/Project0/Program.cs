using System;
using System.Collections.Generic;
using System.Linq;


using DataAccessLayer;
using Models;
using Views;

namespace Project0
{
    class Program
    {      
        static void Main(string[] args)

        
        {

        
            // Project0RepoLayer p0Context = new Project0RepoLayer();3
            //     Console.WriteLine("About to populate db");
            //     Console.ReadLine();
            //     p0Context.DBCreateBaseFloor("ChristenA Exhibit", 4, 19);
            //     p0Context.DBCreateBaseFloor("Picasso Exhibit", 6, 34);
            //     p0Context.DBCreateBaseFloor("Pollock Exhibit", 2, 15);
            //create our tour guide
            
            TourGuide tourGuide = new TourGuide();

        do {//enter program

            Console.Clear();
            //introduce app and get user input on first. have helper return the tour guide after giving him correct things to say
            
            tourGuide.Speak(tourGuide.Words);
            tourGuide.Speak(tourGuide.Options);

            tourGuide.Result=Console.ReadLine();

            if(!((tourGuide.AcceptableResponses).Contains(tourGuide.Result))){
                Console.WriteLine("This input isn't listed!\nIf you're trying to potentially skip a menu, your tour guide has a list of acceptable answers that are given above!\n Press enter to continue...");
                tourGuide.Result="0";
                Console.ReadLine();
            }
            tourGuide=PrintToScreenHelper.TourGuideHelper(tourGuide);



         }while(tourGuide.Result!="-1");


        tourGuide.Speak(tourGuide.Words); //say goodbye

        }//end main

    }//end program
}//end namespace