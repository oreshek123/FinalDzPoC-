using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLib.Module;

namespace ClassLib.Module
{
    public enum Mast
    {
        Piki = 1, Chervi = 2, Bubi = 3, Kresti = 4
    }

    public enum TypeOfCard
    {
        Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10, Valet = 11, Queen = 12, King = 13, Tuz = 14
    }
    public class Card
    {
        public Mast Mast { get; set; }
        public bool IsKozyr { get; set; } = false;
        public TypeOfCard CardType { get; set; }
    }
}
