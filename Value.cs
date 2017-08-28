using System;

using System.Collections.Generic;

using System.Text;



namespace Card_Game

{

    class Value : Dealing

    {
        // the points for the 21 scoring system
        protected static int dealerHandValue = 0;
        protected static int userHandValue = 0;

        private static int value;
        //This method will check the cards in the users hand and assign them a value
        //based on the card

        public static int UserValue(List<string> userHand)
        {
            userHandValue = 0;

            foreach (string card in userHand)
            {            

                //assigns number cards the value associated with the card by parsing the first 2 char 
                //of the cards name and adding that value to the hand
                if (int.TryParse(card.Substring(0, 2), out value))
                {
                    userHandValue += value;
                }
                // assigns all face cards and the "10" card a value of 10.

                if (card.ToLower().StartsWith("jack") || card.ToLower().StartsWith("queen") || card.ToLower().StartsWith("king"))
                {
                    userHandValue += 10;
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

            return userHandValue;
        }
        
        //This method will check the cards in the dealers hand and assign them a value
        //based on the card

        public static int DealerValue(List<string> dealerHand)
        {
            dealerHandValue = 0;

            foreach (string card in dealerHand)
            {
                //assigns number cards the value associated with the card by parsing the first 2 char 
                //of the cards name and adding that value to the hand
                if (int.TryParse(card.Substring(0, 2), out value))
                {
                    dealerHandValue += value;
                }

                // assigns all face cards and the "10" card a value of 10.
                if (card.ToLower().StartsWith("jack") || card.ToLower().StartsWith("queen") || card.ToLower().StartsWith("king"))
                {
                    dealerHandValue += 10;
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

            return dealerHandValue;
        }

        public static void PrintUserValue()
        {
            Console.WriteLine("Your hand value is: {0} \n", userHandValue);
        }
    }

}