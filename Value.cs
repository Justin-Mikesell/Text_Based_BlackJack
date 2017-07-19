using System;
using System.Collections.Generic;
using System.Text;

namespace Card_Game
{
    class Value : Dealing
    {
        //This method will check the cards in the users hand and assign them a value
        //based on the card
        public static void UserValue()
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
        public static void DealerValue()
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
    }
}
