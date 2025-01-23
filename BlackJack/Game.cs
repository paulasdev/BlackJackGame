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
    public Card(string suit, string rank, int value)
    {
      Suit = suit;
      Rank = rank;
      Value = value;
    }

   //Methods
    public override string ToString()
    {
        return string.Format($"{Rank} of {Suit}, value {Value}");
    }
  }
    //Deck class to manage a deck of cards
 public class Deck
{
    private Card[] cards;
    private int currentCard;

    private string[] suits = new string[4] { "Hearts", "Diamonds", "Clubs", "Spades" };
    private string[] ranks = new string[13] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
    private int[] values = new int[13] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 };

 public Deck()
{
    cards = new Card[52];
    currentCard = 0;
    int index = 0;
    int suit = 0;  

    
    while (index < cards.Length)
    {
        
        if (suit >= suits.Length)
        {
            break; 
        }

        for (int rank = 0; rank < ranks.Length; rank++)
        {
            cards[index++] = new Card(suits[suit], ranks[rank], values[rank]);
        }

        suit++; 
    }
}

    public void Shuffle()
    {
        Random randomGenerator = new Random(); 

        for (int i = cards.Length - 1; i > 0; i--)
        {
            int j = randomGenerator.Next(i + 1);
            Card temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }

    public Card Deal()
    {
        if (currentCard >= cards.Length)
        {
            Console.WriteLine("No more cards in the deck!");
            return null; 
        }

        return cards[currentCard++];
    }
}

}