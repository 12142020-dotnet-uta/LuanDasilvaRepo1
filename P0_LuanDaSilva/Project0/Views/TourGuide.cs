using System;
using System.Collections.Generic;


using Models;
using DataAccessLayer;

namespace Views
{
  //this is your companion   
    public class TourGuide
    {
        
        private string words;
        private string options;
        private string result;
        private User user;
        private List<string> acceptableResponses;



        public List<string> AcceptableResponses {get{return acceptableResponses;} set{acceptableResponses=value;}}
        public string  Words{get{return words;} set{words=value;}}
        public string  Options{get{return options;} set{options=value;}}
        public string  Result{get;set;}
        public User User {get{return user;} set{user=value;}}

        //methods
        public void Speak(string s){
            Console.WriteLine(s);
        }

        //cosntructors
        public TourGuide(){
            Words="Welcome to the Abstract Museum, where we abstract out abstract art! What would you like to do?\n";
            Options="1. Create User \n2. Login\n-1. Quit";
            Result="-1";
            AcceptableResponses= new List<string> { "1","2","-1" };
            
            
        }

        public TourGuide(string tospeak="DontSpeak", string tolist="I know what you're listing", string res="-1", List<string> acceptThis= null ){
            Words=tospeak;
            Options=tolist;
            Result=res;
            AcceptableResponses=acceptThis;

        }
        public TourGuide(string tospeak="DontSpeak", string tolist="I know what you're listing", string res="-1", List<string> acceptThis=null, User u=null){
            Words=tospeak;
            Options=tolist;
            Result=res;
            User=u;
            AcceptableResponses=acceptThis;

        }
        public override string ToString()
        {
            return this.Result+" "+ this.Words;
        }
    }

}