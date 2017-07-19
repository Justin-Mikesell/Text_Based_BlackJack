using System;
using System.Collections.Generic;
using System.Text;

namespace Card_Game
{
    class Dealing : Deck
    {
        // Lists for dealer and user hands. Throw away is a list which contains all cards
        //that have been used during a hand so no duplicates will be pulled
        private static List<string> throwAway = new List<string>();
        private static List<string> userHand = new List<string>();
        private static List<string> dealerHand = new List<string>();

        private static string newCard;

        // the points for the 21 scoring system
        private static int dealerHandValue = 0;
        private static int userHandValue = 0;

        // type will pull the cards type eg. Club, spade. ect
        private static Random type = new Random();

        // pulls the actual card value eg. 9, 10, Jack
        private static Random card = new Random();

        private static bool dealing = true;

        public static void Deal(Deck someDeck)
        {
            //Clears the throwAway list so cards dealt in the previous hand will be able to 
            //be dealt again
            throwAway.Clear();

            // will  deal 2 cards to each player
            Console.WriteLine("Dealing... Please Wait...");

            //Deals 2 cards to the user
            for (int i = 0; userHand.Count < 2; i++)
            {
                
                //Generates a new card from the deck
                newCard = (deck[type.Next(0, 4), card.Next(0, 13)]);

                // checks to see if it has been dealt in the current hand already
                if (throwAway.Contains(newCard))
                {
                    continue;
                }

                //if it hasnt then adds it to the users hand and throw away deck
                userHand.Add(newCard);
                throwAway.Add(newCard);
                System.Threading.Thread.Sleep(1000);
            }

            //Deals 2 cards to the dealer
            for (int i = 0; dealerHand.Count < 2; i++)
            {

                //Generates a new card from the deck
                newCard = (deck[type.Next(0, 4), card.Next(0, 13)]);

                // checks to see if it has been dealt in the current hand already
                if (throwAway.Contains(newCard))
                {
                    continue;
                }

                //if it hasnt then adds it to the users hand and throw away deck
                dealerHand.Add(newCard);
                throwAway.Add(newCard);
                System.Threading.Thread.Sleep(1000);
            }



            // calls the Play method automatically
            Console.Clear();
            Play();
            
        }

        //The actual game play portion of the program
        public static void Play()
        { 
            //A loop that continues unless the user specifies not to
            while (dealing)
            {
                userHandValue = 0;

                // gets the value of cards in the userHand List
                UserValue();
                
                //Displays the users Hand and value
                Console.WriteLine("Your hand is: \n");
                foreach (string card in userHand)
                {
                    Console.WriteLine(card);
                }
                Console.WriteLine("\n");
                Console.WriteLine("Your hand value is: {0} \n", userHandValue);

                // Shows the card at index 0 in the dealersHand
                Console.WriteLine("The Dealer shows: {0}\n", dealerHand[0]);


                // will trigger if the user "busts" (users hand value goes over 21)
                if (userHandValue > 21)
                {
                    Console.WriteLine("****BUST!****");
                    Console.WriteLine("Press Enter to deal again");
                    Console.ReadLine();
                    Console.Clear();

                    //resets all hands to empty and values to 0
                    userHand.Clear();
                    dealerHand.Clear();
                    dealerHandValue = 0;
                    userHandValue = 0;

                    //creates a new deck and calls the Deal method
                    Deck newDeck = new Deck();
                    Deal(newDeck);
                }

                //User controls for hit, stay and quit
                Console.WriteLine("To hit type \"hit\" to stay type \"stay\" or type \"quit\" to exit.");
                string userInput = Console.ReadLine();
                Console.WriteLine("\n");

                //will end the program
                if (userInput.ToLower() == "quit") 
                {
                    dealing = false;
                }

                // will call the hit method
                if (userInput.ToLower() == "hit")
                {
                    Hit();
                    Console.Clear();

                    // will add the card to the users hand and total the values
                    continue;
                }
                // if the user inputs stay it will begin the dealers play
                else if (userInput.ToLower() == "stay")
                {
                    // will assign the dealers hand a value
                    dealerHandValue = 0;
                    DealerValue();

                    while (dealing)
                    {
                        //dealer will call the hit method if dealer has a hand
                        //value of less than or equal to 15
                        if (dealerHandValue <= 15)
                        {
                            Console.WriteLine("Dealer hits \n");
                            DealerHit();
                            
                            //resets the dealers hand value to 0 to prevent the value
                            // of his hand from being stacked
                            dealerHandValue = 0;

                            // will assign the dealers hand a new value including
                            //the card the dealer dealt himself
                            DealerValue();
                        }
                        
                        // if the dealers hand  has a value greater than 15 he will stay...
                        else if (dealerHandValue > 15)
                        {

                            //The following IF statements determine the outcome of the current hand

                            //if the user hand is less than or equal to 21 and it is also
                            //higher than the value of the dealers hand the user wins
                            if (userHandValue > dealerHandValue && userHandValue <= 21)
                            {
                                Console.WriteLine("The dealer stays \n");
                                Console.WriteLine("The Dealers hand was: \n");

                                // Displays the cards in the dealers hand and its value
                                foreach (string card in dealerHand)
                                {
                                    Console.WriteLine(card);
                                }
                                Console.WriteLine("\nfor a total of: {0}\n", dealerHandValue);
                                Console.WriteLine("You win! Press Enter to redeal!");

                                //resets all values to 0 and empties the cards from the
                                //dealer and users hands
                                userHandValue = 0;
                                
                                userHand.Clear();
                                dealerHand.Clear();

                                // starts a new deck and calls the Deal method
                                Console.ReadLine();
                                Console.Clear();
                                Deck newDeck = new Deck();
                                Deal(newDeck);
                            }

                            // if the user and dealers hand value match the hand is declared
                            // a draw.
                            else if (userHandValue == dealerHandValue)
                            {
                                Console.WriteLine("The dealer stays \n");
                                Console.WriteLine("Draw!\n");
                                Console.WriteLine("The Dealers hand was: \n");

                                // Displays the cards in the dealers hand
                                foreach (string card in dealerHand)
                                {
                                    Console.WriteLine(card);
                                }
                                Console.WriteLine("\nfor a total of: {0}\n", dealerHandValue);
                                Console.WriteLine("You lose! Press Enter to deal again!");

                                //resets hand values to 0 and removes cards from hands
                                userHand.Clear();
                                dealerHand.Clear();
                                
                                userHandValue = 0;
                                Console.ReadLine();
                                Console.Clear();

                                //creates a new deck and calls the deal method
                                Deck newDeck = new Deck();
                                Deal(newDeck);
                            }

                            // if the other 2 conditions are not met that means the dealers hand is
                            //higher than the users but less than or equal to 21
                            // and the dealer is declared the winner
                            else
                            {

                                Console.WriteLine("The dealer stays \n");
                                Console.WriteLine("The Dealers hand was: \n");

                                // displays dealers hand
                                foreach (string card in dealerHand)
                                {
                                    Console.WriteLine(card);
                                }
                                Console.WriteLine("\nfor a total of: {0}\n", dealerHandValue);
                                Console.WriteLine("You lose! Press Enter to deal again!");

                                //resets all hand values to 0 and removes cards from the player and
                                //dealers hands
                                userHand.Clear();
                                dealerHand.Clear();
                                
                                Console.ReadLine();
                                Console.Clear();

                                //declares a new deck and calls the deal method on it
                                Deck newDeck = new Deck();
                                Deal(newDeck);
                            }
                        }

                        // if the dealers hand value is over 21 the dealer busts
                        if (dealerHandValue > 21)
                        {
                            Console.WriteLine("Dealer BUST!");
                            Console.WriteLine("The Dealers hand was: \n");

                            // displays dealers hand
                            foreach (string card in dealerHand)
                            {
                                Console.WriteLine(card);
                            }
                            Console.WriteLine("\nfor a total of: {0}\n", dealerHandValue);
                            Console.WriteLine("You win! Press Enter to redeal!");

                            //resets all hand values to 0 and removes cards from user
                            // and dealers hand
                            userHandValue = 0;
                            dealerHandValue = 0;
                            userHand.Clear();
                            dealerHand.Clear();
                            Console.ReadLine();
                            Console.Clear();

                            //Declares a new deck and calls the deal method
                            Deck newDeck = new Deck();
                            Deal(newDeck);
                        }

                    }
                }

            }

        }

        //This method will check the cards in the users hand and assign them a value
        //based on the card
        private static void UserValue()
        {


            foreach (string card in userHand)
            {
                // assigns all face cards and the "10" card a value of 10.
                if (card.ToLower().StartsWith("jack") || card.ToLower().StartsWith("queen") || card.ToLower().StartsWith("king") || card.StartsWith("10"))
                {
                    userHandValue += 10;
                }

                //assigns number cards the value associated with the card
                else if (card.StartsWith("9"))
                {
                    userHandValue += 9;
                }
                else if (card.StartsWith("8"))
                {
                    userHandValue += 8;
                }
                else if (card.StartsWith("7"))
                {
                    userHandValue += 7;
                }
                else if (card.StartsWith("6"))
                {
                    userHandValue += 6;
                }
                else if (card.StartsWith("5"))
                {
                    userHandValue += 5;
                }
                else if (card.StartsWith("4"))
                {
                    userHandValue += 4;
                }
                else if (card.StartsWith("3"))
                {
                    userHandValue += 3;
                }
                else if (card.StartsWith("2"))
                {
                    userHandValue += 2;
                }

                // when the user value method is called this will check the users
                //total hand value and assign the "Ace" a value dependant on whether the 
                //the user will bust or not if the ace is worth 11. 

                else if (card.ToLower().StartsWith("ace"))
                {

                    //if the ace being given the value of 11 will cause
                    // the user to bust then the ace will be assigned the 
                    // value of 1
                    if (userHandValue + 11 <= 21)
                    {
                        userHandValue += 11;
                    }
                    else if (userHandValue + 11 > 21)
                    {
                        userHandValue += 1;
                    }
                }
            }
        }

        //This method will check the cards in the dealers hand and assign them a value
        //based on the card
        private static void DealerValue()
        {
            foreach (string card in dealerHand)
            {

                // assigns all face cards and the "10" card a value of 10.
                if (card.ToLower().StartsWith("jack") || card.ToLower().StartsWith("queen") || card.ToLower().StartsWith("king") || card.StartsWith("10"))
                {
                    dealerHandValue += 10;
                }

                //assigns number cards the value associated with the card
                else if (card.StartsWith("9"))
                {
                    dealerHandValue += 9;
                }
                else if (card.StartsWith("8"))
                {
                    dealerHandValue += 8;
                }
                else if (card.StartsWith("7"))
                {
                    dealerHandValue += 7;
                }
                else if (card.StartsWith("6"))
                {
                    dealerHandValue += 6;
                }
                else if (card.StartsWith("5"))
                {
                    dealerHandValue += 5;
                }
                else if (card.StartsWith("4"))
                {
                    dealerHandValue += 4;
                }
                else if (card.StartsWith("3"))
                {
                    dealerHandValue += 3;
                }
                else if (card.StartsWith("2"))
                {
                    dealerHandValue += 2;
                }

                // when the user value method is called this will check the users
                //total hand value and assign the "Ace" a value dependant on whether the 
                //the user will bust or not if the ace is worth 11.

                else if (card.ToLower().StartsWith("ace"))
                {

                    //if the ace being given the value of 11 will cause
                    // the dealer to bust then the ace will be assigned the 
                    // value of 1
                    if (dealerHandValue + 11 <= 21)
                    {
                        dealerHandValue += 11;
                    }
                    else if (dealerHandValue + 11 > 21)
                    {
                        dealerHandValue += 1;
                    }
                }

            }
        }
        




        // This method will deal the user a new card 

        public static void Hit()
        {
            while (dealing)
            {
                // pulls a random card from the deck
                string newCard = (deck[type.Next(0, 4), card.Next(0, 13)]);

                //checks to see if its already been dealt in the current hand
                if (throwAway.Contains(newCard))
                {
                    continue;
                }

                //adds it to the throw away list and to the users hand
                userHand.Add(newCard);
                throwAway.Add(newCard);


                break;

            }

        }

        //This method deals the dealer a new card

        public static void DealerHit()
        {
            while (dealing)
            {
                // pulls a random card from the deck
                string newCard = (deck[type.Next(0, 4), card.Next(0, 13)]);

                //checks to see if it has been dealt in the current hand
                if (throwAway.Contains(newCard))
                {
                    continue;
                }

                // adds it to the throw away list and to the dealers hand
                dealerHand.Add(newCard);
                throwAway.Add(newCard);


                break;

            }

        }
      }

    }

