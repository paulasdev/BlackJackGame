﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackGame
{
  class Program
  {
    static void Main(string[] args)
    {
   Console.WriteLine("Welcome to BlackJack Game!");
  Game game = new Game();
  game.Play();
       
    }
  }
}
