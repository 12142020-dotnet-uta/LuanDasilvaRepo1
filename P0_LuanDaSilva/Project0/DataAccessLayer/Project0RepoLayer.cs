using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using Models;
using DataAccessLayer;

namespace DataAccessLayer
{
    public class Project0RepoLayer
    {
        
        //set db repo vars
        Project0DbContext DbContext;
        DbSet<User> users;
        DbSet<Painting> paintings;
        DbSet<Tour> tours;
        DbSet<BaseFloor> floors;

        DbSet<FloorTourUsrLine> floorTourUsrLines;


          public Project0RepoLayer()
        {
            this.DbContext = new Project0DbContext();
            this.users = DbContext.Users;
            this.paintings = DbContext.Paintings;
            this.tours = DbContext.Tours;
            this.floors=DbContext.Floors;
            this.floorTourUsrLines=DbContext.FloorTourUsrLines;
        }
        public Project0RepoLayer(Project0DbContext context)
        {
       this.DbContext = context;
            this.users = DbContext.Users;
            this.paintings = DbContext.Paintings;
            this.tours = DbContext.Tours;
            this.floors=DbContext.Floors;
            this.floorTourUsrLines=DbContext.FloorTourUsrLines;
        }


        //repo methods

#nullable enable

    public Painting? FindPainting(string locName, int rowChoice, int colChoice){

                Painting p = new Painting();
                try
                {
                    p = (paintings.Where(x => x.LocationCodeName== locName && x.X==rowChoice && x.Y==colChoice).FirstOrDefault()!);
                    return p;
   
                }
                catch (NullReferenceException)
                {
                    return null;
                }


        }


    public IEnumerable<FloorTourUsrLine>? GetUsersPastTour(User u){
        try{
        var usersTour = floorTourUsrLines
                            .Where(x =>  x.UserID ==u.UserID );
                            
        return ((IEnumerable<FloorTourUsrLine>) usersTour);
        }

        catch(NullReferenceException){
            return null;
        }
    }







        /// <summary>
        /// Finds User given unique name
        /// </summary>
        /// <param name="uname"></param>
        /// <returns></returns>
        public User? FindUser(string uname){

                User u = new User();
                try
                {
                    u = (users.Where(x => x.Username== uname ).FirstOrDefault()!);
                    return u;
   
                }
                catch (NullReferenceException)
                {
                    return null;
                }


        }



/// <summary>
/// Finds whether there is a tour with a guid
/// </summary>
/// <param name="locCodeName"></param>
/// <param name="rowNum"></param>
/// <returns></returns>

        public Tour? FindTour(string locCodeName, int rowNum){

                Tour u = new Tour();
                try
                {
                    u = (tours.Where(x => (x.LocationCodeName==locCodeName && x.RowNum==rowNum)).FirstOrDefault())!;
                    if(u!=null ){
                         return u;  
                    }
   
                }
                catch (System.Exception)
                {
                    
                    throw new Exception("No tour found.");
                }
            return null;

        }



/// <summary>
/// Find tour using name and row number
/// </summary>
/// <param name="locName"></param>
/// <param name="row"></param>
/// <returns></returns>


        public Tour? FindTour(Guid id){

                Tour u = new Tour();
                try
                {
                    u = tours.Where(x => (x.TourID==id)).FirstOrDefault()!;
                    return u;  
                    
   
                }
                catch (NullReferenceException)
                {
                    
                   return null;
                }
            

        }




/// <summary>
/// Retrieve all floor as a set of strings
/// </summary>
/// <returns></returns>
        public List<string> FindAllFloors(){

                try
                {
                List<string> lst=new List<string>();
                lst=floors.Select(item => item.LocationCodeName).ToList();
                return lst;
                }
    
                catch (System.Exception)
                {
                    
                    throw new Exception("Nothing found.");
                }
        
        }






/// <summary>
/// Retrieve all floor as a set of strings
/// </summary>
/// <returns></returns>
        public List<string> FindAllPaintings(string floorName){

                try
                {
                List<string> lst=new List<string>();
                lst=paintings.Where(item => item.LocationCodeName==floorName).Select(item=> item.PaintingName).ToList();
                return lst;
                }
    
                catch (System.Exception)
                {
                    
                    throw new Exception("Nothing found.");
                }
            

        }

/// <summary>
/// Get a list of all paintings
/// </summary>
/// <returns></returns>





        public BaseFloor? GetFloor(string name){
             BaseFloor f = new BaseFloor();

            f = floors.Where(f => f.LocationCodeName==name ).FirstOrDefault()!;

            if (f == null)
            {
               Console.WriteLine("That floor does not exist!");
            }
                
                return f;
            }          
#nullable disable

        //doesnt need to be nullable no way for it to go wrong
        /// <summary>
        /// Persists painting object to the database. For now this is technically a point on a 2x2 matrix
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="cost"></param>
        /// <param name="paingtingName"></param>
        /// <param name="locCodeName"></param>
        /// <returns></returns>
        public Painting CreatePainting(int x, int y, int cost, string paingtingName, string locCodeName){
                Painting p = new Painting();
                p=paintings.Where( x => x.PaintingName==paingtingName && x.LocationCodeName==locCodeName).FirstOrDefault();

                if(p==null)
                {
                    p=new Painting()
                    {
                        X=x,
                        Y=y,
                        Cost=cost,
                        PaintingName=paingtingName,
                        LocationCodeName=locCodeName
                    };
                    paintings.Add(p);
                    DbContext.SaveChanges();
                }
                return p;
        }
        /// <summary>
        /// Persist a User to the database
        /// </summary>
        /// <param name="uName"></param>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <returns></returns>
        public User CreateUser(string uName="null", string fName = "null", string lName = "null")
       
        {
            User u = new User();

            u = users.Where(x => x.Username== uName ).FirstOrDefault();

            if (u == null)
            {
                u = new User()
                {
                    Username=uName,
                    Fname = fName,
                    Lname = lName
                };
                users.Add(u);
                DbContext.SaveChanges();
            }
            return u;
        }
        /// <summary>
        /// Persist a Tour to the databse.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="locCodeName"></param>
        /// <returns></returns>
        /// 
        
        public Tour CreateTour(int number, string locCodeName)
       
        {
            Tour t = new Tour();

            t = tours.Where(t => t.LocationCodeName== locCodeName && t.RowNum==number).FirstOrDefault();

            if (t == null)
            {
                t = new Tour()
                {
                    LocationCodeName=locCodeName,
                    RowNum=number
                };
                tours.Add(t);
                DbContext.SaveChanges();
            }
            return t;
        }

        /// <summary>
        /// Add FloorTourLine entry. Row here defines a row of paintings in database.
        /// /// </summary>
        /// <param name="locCodeName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        /// 
        /// 
        /// 
 /// Adds FloorTourUsrLine entry. A row here signifies a user visit to the museum.
        /// </summary>
        /// <param name="locCodeName"></param>
        /// <param name="tId"></param>
        /// <param name="uId"></param>
        /// <returns></returns>        
        public FloorTourUsrLine CreateFloorTourUsrLine(string locCodeName, Guid tId, Guid uId )

       
        {
            FloorTourUsrLine t = new FloorTourUsrLine();


            t = floorTourUsrLines.Where(t =>  t.UserID==uId && t.LocationCodeName==locCodeName && t.TourID==tId).FirstOrDefault();

            if (t == null)
            {
                t = new FloorTourUsrLine()
                {
                    UserID=uId,
                    TourID=tId,
                    LocationCodeName=locCodeName
                };
                floorTourUsrLines.Add(t);
                DbContext.SaveChanges();
            }
            return t;
        }

    /// <summary>
    /// Checks if a floor has tours remaining
    /// </summary>
    /// <param name="locCodeName"></param>
    /// <param name="locSize"></param>
    /// <param name="remTours"></param>
    /// <returns></returns>


    public bool FloorHasTours(string locCodeName){    
             BaseFloor t = new BaseFloor();


            t = floors.Where(t =>  t.LocationCodeName==locCodeName).FirstOrDefault();

            if (t != null)
            {
                if(t.LocationRemainingTours==0){
                    return false;

                }
            
    }return true;}



    /// <summary>
    /// Reduces remaining tours on the tour Floor taken, consequently create a new FloorTourUsrLine entry.
    /// </summary>
    /// <param name="locCodeName"></param>
    /// <returns></returns>
    
    public void RemoveTourFromFloor(string locCodeName){

    
            BaseFloor t = new BaseFloor();


            t = floors.Where(t =>  t.LocationCodeName==locCodeName).FirstOrDefault();

            if (t != null)
            {
                if(t.LocationRemainingTours!=0){

                    --t.LocationRemainingTours;    
                    DbContext.SaveChanges();
                    
                }
            }
            


        
    }



    public BaseFloor DBCreateBaseFloor(string locCodeName, int locSize, int remTours){

    

    BaseFloor t = new BaseFloor();


            t = floors.Where(t =>  t.LocationCodeName==locCodeName).FirstOrDefault();

            if (t == null)
            {
                List<LinkedList<Painting>> tmpfloor = new List<LinkedList<Painting>>();
                t = new BaseFloor()
                {
                    LocationCodeName=locCodeName,
                    LocationSize=locSize,
                    LocationRemainingTours=remTours
                };

                tmpfloor=t.CreateBaseTours(locSize,locCodeName);
                floors.Add(t);
                DbContext.SaveChanges();
            }
            return t;

    }





}
}







