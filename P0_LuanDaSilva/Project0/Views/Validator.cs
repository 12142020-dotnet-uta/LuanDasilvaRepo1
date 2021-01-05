using System;
using System.Collections.Generic;


using Models;
using DataAccessLayer;



namespace Views
{
    public class Validator
    {
        
// //helper class to validate inputs
#nullable enable
 
    public int? ValidateStringToInt (string? arg)
            {
                try
                {
                    int result;
                    int.TryParse(arg, out result);
                    return result;   
                }
                catch (System.Exception)
                {
                    return null;
                }
                

            }

    public string InputConstraints(string arg)
     {
            try         
            { 
                   arg = string.Join("", arg.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
                   if((arg.Length>2 && arg.Length<20)) 
                    { return arg; 
                    } else{return "0";}
            }catch (System.Exception)

                { return "0";}
    }
#nullable disable



    }//end validation helper
}