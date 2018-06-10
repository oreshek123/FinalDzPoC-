using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ClassLib.Module
{
    public class Game
    {
        public Random rnd = new Random();
        public List<Player> players = new List<Player>();
        public Coloda col = new Coloda();
        public List<Card> Cards = new List<Card>();
        public void Start()
        {
            Cards = col.SetRandomColoda();
            SetRandomPlayers();
            Console.WriteLine($"Count of players: {players.Count}\n");
            GameSimulation();
        }

        public void SetRandomPlayers()
        {
            int randomMast = rnd.Next(1, 5);
            int randomPlayer = rnd.Next(2, 6);
            Cards.Where(w => w.Mast == (Mast)randomMast).ToList().ForEach(f => { f.IsKozyr = true; });
            Console.WriteLine("Козырь : " + (Mast)randomMast);
            for (int i = 0; i < randomPlayer; i++)
            {
                Thread.Sleep(40);

                Player player = new Player()
                {
                    Name = (i+1).ToString()
                };

                for (int j = 0; j < 6; j++)
                {
                    int k = rnd.Next(0, Cards.Count);
                    player.PlayerCards.Add(Cards[k]);
                    Cards.RemoveAt(k);
                }
                players.Add(player);
            }
        }

        public void GameSimulation()
        {
            Dictionary<Player, Card> playersCard = null;
            bool isOver = false;
            while (isOver != true)
            {
                int k = 0;
                playersCard = new Dictionary<Player, Card>();
                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i].PlayerCards.Count != 0)
                    {
                        k = rnd.Next(0, players[i].PlayerCards.Count);
                        playersCard.Add(players[i], players[i].PlayerCards[k]);
                        Console.WriteLine(
                            $"Player №{players[i].Name} throws card {players[i].PlayerCards[k].CardType} {players[i].PlayerCards[k].Mast}\n");
                        players[i].PlayerCards.RemoveAt(k);
                    }
                }

                Console.WriteLine("\n");
                if (playersCard.Count != 0)
                {
                    Player pl = playersCard.FirstOrDefault(pla =>
                        pla.Value == playersCard.Values.OrderBy(o => (int)o.CardType).Last()).Key;


                    foreach (KeyValuePair<Player, Card> item in playersCard)
                    {
                        players[players.IndexOf(pl)].PlayerCards.Add(item.Value);
                    }
                }

                if (Cards.Count != 0)
                {
                    for (int i = 0; i < players.Count; i++)
                    {
                        k = rnd.Next(0, Cards.Count);
                        if (players[i].PlayerCards.Count < 6 && Cards.Count != 0)
                        {
                            players[i].PlayerCards.Add(Cards[k]);
                            Cards.RemoveAt(k);
                        }
                    }
                }

                foreach (Player item in players)
                {
                    if (item.PlayerCards.Count == 36)
                        isOver = true;
                }
                Console.WriteLine("Game process..");
            }

            foreach (Player item in players)
            {
                if (item.PlayerCards.Count == 36)
                {
                    Console.WriteLine("Player № " + item.Name + " is WINNER");
                }
            }
        }
    }
}
