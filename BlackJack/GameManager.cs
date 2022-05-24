using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class GameManager
    {
        public Deck GameDeck { get; set; }
        public Player GamePlayer { get; set; }
        private bool gameOn; // Added field 
        private Random random; // Added field
        private int maxNum; // Added field 
        private int minNum; // Added field

        public GameManager()
        {
            this.gameOn = true;
            this.maxNum = 21;
            this.minNum = 10;
            this.random = new Random();
        }

        public void SetUpGame()
        {
            if (this.gameOn == false)
            {
                this.gameOn = true;
            }

            Console.Clear();
            Console.WriteLine("====== BLACKJACK GAME ======");
            this.GameDeck = new Deck();
            this.GamePlayer = new Player();
            this.GameDeck.Shuffle();
            this.GamePlayer.AddCard(this.GameDeck.DealCard());
            this.GamePlayer.AddCard(this.GameDeck.DealCard());
            Console.WriteLine("Your Hand: ");
            Console.WriteLine(this.GamePlayer.GetHand());
        }

        public void NewGamePrompt(string winOrLose)
        {
            if (winOrLose == "WIN")
            {
                Console.WriteLine("YOU WIN !");
            }else if (winOrLose == "LOSE")
            {
                Console.WriteLine("YOU LOST !");
            }
            
            Console.WriteLine("Play again? (y/n)");
            string yesOrNo = Console.ReadLine();
            if (yesOrNo == "n")
            {
                this.gameOn = false;
            }
            else if (yesOrNo == "y")
            {
                this.StartGame();
                this.minNum++;
            }
        }

        public void StartGame() // Changed name 
        {
            this.SetUpGame();
            while (this.gameOn)
            {
                Console.WriteLine("Hit or Finish? (h/f)");
                string hitOrFinish = Console.ReadLine();

                if (hitOrFinish == "h")
                {
                    this.GamePlayer.AddCard(this.GameDeck.DealCard());
                    Console.WriteLine("Your Hand: ");
                    Console.WriteLine(this.GamePlayer.GetHand());
                    if (this.GamePlayer.IsLost())
                    {
                        this.NewGamePrompt("LOSE");
                    }
                } else if (hitOrFinish == "f")
                {   
                    int pcValue = this.random.Next(this.minNum, this.maxNum);
                    if ((this.maxNum - pcValue) > (this.maxNum - this.GamePlayer.HandValue))
                    {
                        Console.WriteLine("PC HAND VALUE IS " + pcValue);
                        this.GamePlayer.WinCount++;
                        this.NewGamePrompt("WIN");
                    } else
                    {
                        Console.WriteLine("PC HAND VALUE IS " + pcValue);
                        this.NewGamePrompt("LOSE");
                    }
                    this.gameOn = false;
                }else
                {
                    Console.WriteLine("INVALID INPUT DETECTED !");
                }
            }
        }
    }
}
