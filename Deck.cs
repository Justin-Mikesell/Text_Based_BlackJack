using System;

using System.Collections.Generic;

using System.Text;



namespace Card_Game

{

    // This class is simply for the creation of the deck of cards

    class Deck
    {
        // creates a multi dimensional array to hold the card types(Club, spade, ect.)

        //and the card value (Jack, king, 10, ect.)

        protected static string[,] deck = new string[4, 13];



        protected static string cardType;

        public static string cardValue;



        public Deck()

        {

            // a nested for loop that will generate 52 unique cards that when

            //combined make a completed deck of cards.



            for (int i = 0; i < 4; i++)

            {

                for (int j = 0; j < 13; j++)

                {

                    switch (i)

                    {

                        case 0:

                            cardType = " of Spades";

                            break;

                        case 1:

                            cardType = " of Clubs";

                            break;

                        case 2:

                            cardType = " of Diamonds";

                            break;

                        case 3:

                            cardType = " of Hearts";

                            break;

                        default:

                            continue;

                    }

                    switch (j)

                    {

                        case 0:

                            cardValue = "Ace";

                            break;

                        case 1:

                            cardValue = "2";

                            break;

                        case 2:

                            cardValue = "3";

                            break;

                        case 3:

                            cardValue = "4";

                            break;

                        case 4:

                            cardValue = "5";

                            break;

                        case 5:

                            cardValue = "6";

                            break;

                        case 6:

                            cardValue = "7";

                            break;

                        case 7:

                            cardValue = "8";

                            break;

                        case 8:

                            cardValue = "9";

                            break;

                        case 9:

                            cardValue = "10";

                            break;

                        case 10:

                            cardValue = "Jack";

                            break;

                        case 11:

                            cardValue = "Queen";

                            break;

                        case 12:

                            cardValue = "King";

                            break;

                        default:

                            continue;

                    }

                    deck[i, j] = cardValue + cardType;

                }

            }







        }

    }

}