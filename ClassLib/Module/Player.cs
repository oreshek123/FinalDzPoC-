using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Module
{
    public class Player
    {
        public List<Card> PlayerCards { get; set; }= new List<Card>();
        public string Name { get; set; }
    }
}
