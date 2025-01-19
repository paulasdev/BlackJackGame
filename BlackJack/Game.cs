using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackGame
{

  //Card class to represent individual cards
  public class Card
  {
   //proprerties
    public string Suit { get; set; }
    public string Rank { get; set; }
    public int Value { get; set; }

    //constructor
    public Card(string suit, string rank)
    {
      Suit = suit;
      Rank = rank;
    }

   //Methods
    public override string ToString()
    {
        return string.Format($"{Rank} of {Suit}, value {Value}");
    }
  }
}