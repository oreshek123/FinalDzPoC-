using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLib.Module
{
    public class Coloda
    {
        private Random Rnd { get;} = new Random();
        public List<Card> Cards = new List<Card>();

        public List<Card> SetRandomColoda()
        {
            for (int i = 1; i < 5; i++)
            {
                for (int j = 6; j < 15; j++)
                {
                    Card card = new Card
                    {
                        Mast = (Mast)i,
                        CardType = (TypeOfCard)j
                    };
                    Cards.Add(card);
                }  
            }

            return Cards;
        }


    }
}
