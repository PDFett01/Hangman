using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Hangman;

namespace Hangman
{
    class Program
    {
        public static void Main(string[] args)
        {
            HangmanGamePlay StartGame = new HangmanGamePlay();
            StartGame.GamePlay();
        }


    }

}
