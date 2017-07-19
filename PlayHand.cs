using System;
using System.Collections.Generic;
using System.Text;

namespace Card_Game
{
    class PlayHand : Dealing
    {
        private static bool dealing = true;

        //The actual game play portion of the program
        public static void Play()
    {
        //A loop that continues unless the user specifies not to
        while (dealing)
        {

            //Reorders the users hand to place any aces in the last indexed space
            ReorderUserHand();

            userHandValue = 0;

            // gets the value of cards in the userHand List
            Value.UserValue();

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
                //Reorders the dealers hand to place any aces in the last indexed space
                ReorderDealerHand();

                // will assign the dealers hand a value
                dealerHandValue = 0;
                Value.DealerValue();

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
                        Value.DealerValue();
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
                            Console.WriteLine("Press Enter to deal again!");

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


    // This reorders the user hand to place aces in the last positions of the indexed List
    // this solved an issue of aces in the showing before other cards and causing the calue method to count
    //the ace as an 11 and make the user or dealer bust

    private static void ReorderUserHand()
    {
        string tempHolder;
        for (int i = 0; i < userHand.Count; i++)
        {
            if (userHand[i].ToLower().StartsWith("ace"))
            {
                // places the ace in a temp variable
                tempHolder = userHand[i];

                //takes the last item in the list and puts it where the ace was
                userHand[i] = userHand[userHand.Count - 1];

                //places the ace in the last position
                userHand[userHand.Count - 1] = tempHolder;

            }
        }

    }


    // This reorders the user hand to place aces in the last positions of the indexed List
    // this solved an issue of aces in the showing before other cards and causing the calue method to count
    //the ace as an 11 and make the user or dealer bust

    private static void ReorderDealerHand()
    {
        string tempHolder;
        for (int i = 0; i < dealerHand.Count; i++)
        {
            if (dealerHand[i].ToLower().StartsWith("ace"))
            {
                // places the ace in a temp variable
                tempHolder = dealerHand[i];

                //takes the last item in the list and puts it where the ace was
                dealerHand[i] = dealerHand[dealerHand.Count - 1];

                //places the ace in the last position
                dealerHand[dealerHand.Count - 1] = tempHolder;

            }
        }

    }
}
}
