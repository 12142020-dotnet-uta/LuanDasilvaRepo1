using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Models
{

    public class FloorTourUsrLine
    {
        private Guid floorTourLineID;
        private Guid userID;
        private Guid tourIDGuid;
        private string locationCodeName;
        private DateTime tourTakenAt = DateTime.Now;

        [Key]
        public  Guid FloorTourUsrLineID { get;set;} = Guid.NewGuid();
        

        
        public DateTime TourTakenAt{get{return tourTakenAt;}}
        public  Guid FloorTourLineID { get{return floorTourLineID;} set{floorTourLineID=value;} } 
        public  Guid TourID { get{return tourIDGuid;} set{tourIDGuid= value;} } 
        
        public Guid UserID {get{return userID;} set{userID=value;}}
     
        public string LocationCodeName { get{return locationCodeName;} set{locationCodeName= value;} } 

        //constructor
        public FloorTourUsrLine(){}
        public FloorTourUsrLine(
                     string locationCodeName = "0",
                     Guid tId = new Guid(),
                     Guid uID = new Guid())
                     
                {
                    this.LocationCodeName=locationCodeName;
                    this.TourID= tId;
                    this.UserID=uID;
                }
    }



    
}//endl namespace























