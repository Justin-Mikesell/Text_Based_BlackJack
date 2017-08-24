using System;

using System.Collections.Generic;

using System.Text;



namespace Card_Game

{

    class Dealing : Deck

    {

        // Lists for dealer and user hands. Throw away is a list which contains all cards

        //that have been used during a hand so no duplicates will be pulled

        protected static List<string> throwAway = new List<string>();

        protected static List<string> userHand = new List<string>();

        protected static List<string> dealerHand = new List<string>();



        protected static string newCard;



        // the points for the 21 scoring system

        protected static int dealerHandValue = 0;

        protected static int userHandValue = 0;



        // type will pull the cards type eg. Club, spade. ect

        protected readonly static Random type = new Random();



        // pulls the actual card value eg. 9, 10, Jack

        protected readonly static Random card = new Random();







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

            PlayHand.Play();



        }





    }



}