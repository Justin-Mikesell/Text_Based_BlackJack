using System;
using System.Collections.Generic;
using System.Windows;

namespace Card_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Dealing.Deal(deck);

        }
    }
}