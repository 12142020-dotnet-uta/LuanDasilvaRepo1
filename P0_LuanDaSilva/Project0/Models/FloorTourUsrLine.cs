using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Models
{

    public class FloorTourUsrLine
    {
        [Key]
        public  Guid FloorTourUsrLineID { get;set;} = Guid.NewGuid();
        private Guid floorTourLineID;
        private Guid userID;
        private Guid tourIDGuid;
        private string locationCodeName;
        private DateTime tourTakenAt;


        

        
        public DateTime TourTakenAt{get{return tourTakenAt;} set{tourTakenAt=DateTime.Now;}}
        public  Guid FloorTourLineID { get{return floorTourLineID;} set{floorTourLineID=value;} } 
        public  Guid TourID { get{return tourIDGuid;} set{tourIDGuid= value;} } 
        
        public Guid UserID {get{return userID;} set{userID=value;}}
     
        public string LocationCodeName { get{return locationCodeName;} set{locationCodeName= value;} } 

        //constructor
        public FloorTourUsrLine(){}
        public FloorTourUsrLine(
                     string locationCodeName = "0",
                     Guid tId = new Guid(),
                     Guid uID = new Guid(),
                     DateTime date= new DateTime())
                     
                {
                    this.LocationCodeName=locationCodeName;
                    this.TourID= tId;
                    this.UserID=uID;
                    this.TourTakenAt= DateTime.Now;
                }
    }



    
}//endl namespace























