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
//Player class to manage player state and scoring.
public class Player
{
    public string Name { get; }
    public int Score { get; private set; }
    public bool IsBust => Score > 21;

    public Player(string name)
    {
        Name = name;
        Score = 0;
    }

    public void ReceiveCard(Card card)
    {
        Score += card.Value;
    }

    public void Reset()
    {
        Score = 0;
    }
  }
//Game class to manage the game logic
public class Game
    {
        public void Play()
        {
            string playAgain = "y";

            while (playAgain == "y")
            {
                // Initialize deck, player, and dealer
                Deck deck = new Deck();
                deck.Shuffle();

                Player player = new Player("Player");
                Player dealer = new Player("Dealer");

                // Reset scores
                player.Reset();
                dealer.Reset();

                // Player's initial cards
                Console.WriteLine("\nDealing cards to Player...");
                Card card1 = deck.Deal();
                Card card2 = deck.Deal();
                Console.WriteLine($"Card dealt is the {card1}");
                Console.WriteLine($"Card dealt is the {card2}");

                player.ReceiveCard(card1);
                player.ReceiveCard(card2);

                Console.WriteLine($"Your score is {player.Score}");

                // Player's turn
                while (true)
                {
                    Console.Write("\nDo you want to stick or twist? (s/t): ");
                    string choice = Console.ReadLine()?.ToLower();

                    if (choice == "s")
                    {
                        Console.WriteLine("\nDealer plays\n");
                        break;
                    }
                    else if (choice == "t")
                    {
                        Card newCard = deck.Deal();
                        if (newCard == null)
                        {
                            Console.WriteLine("No more cards in the deck.");
                            break;
                        }

                        Console.WriteLine($"Card dealt is the {newCard}");
                        player.ReceiveCard(newCard);
                        Console.WriteLine($"Your score is {player.Score}");

                        if (player.IsBust)
                        {
                            Console.WriteLine("You are bust! Dealer wins.");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please enter 's' to stick or 't' to twist.");
                    }
                }

                // Dealer's turn
                if (!player.IsBust)
                {
                    while (dealer.Score < 17)
                    {
                        Card newCard = deck.Deal();
                        if (newCard == null)
                        {
                            Console.WriteLine("No more cards in the deck.");
                            break;
                        }

                        Console.WriteLine($"Card dealt is the {newCard}");
                        dealer.ReceiveCard(newCard);
                    }

                    Console.WriteLine($"Dealer score is {dealer.Score}");

                    // Determine winner
                    if (dealer.IsBust || player.Score > dealer.Score)
                    {
                        Console.WriteLine("Player wins");
                    }
                    else if (player.Score == dealer.Score)
                    {
                        Console.WriteLine("It's a tie!");
                    }
                    else
                    {
                        Console.WriteLine("Dealer wins");
                    }
                }

                // Replay option
                Console.Write("\nDo you want to play again? (y/n): ");
                playAgain = Console.ReadLine()?.ToLower();
            }
        }
    }
}

    
    

    