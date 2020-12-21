using System;

namespace rps
{
    internal class NewBaseType
    {
        static void Main(string[] args)
        {

        

            Menus menus = new Menus();

            bool gameIsRunning=true;
            while(gameIsRunning){
                gameIsRunning=menus.IntroMenu();
            }
        }
    }
}