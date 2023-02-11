using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ZooBitSketch.Property.Decks;

namespace ZooBitSketch.Battle
{
    internal class BattleCards
    {
        public Action<Deck> Combo;

        private Random rand = new Random();
        private const int HAND_SIZE = 3;
        private const int TABLE_SIZE = 3;
        private Deck deck;
        private Deck hand;
        private Deck table;
        private Deck dumping;
        private Deck destroyed;

        public BattleCards(Deck startDeck)
        {
            int maxSize = startDeck.Pack.Count;
            deck = startDeck;
            hand = new Deck(HAND_SIZE);
            table= new Deck(TABLE_SIZE);
            dumping = new Deck(maxSize);
            destroyed = new Deck(maxSize);
        }

        public Deck ProvideHand()
        {
            for (int i = 0; i < HAND_SIZE; i++)
            {
                if (deck.Pack.Count > 0)
                {
                    var index = rand.Next(deck.Pack.Count);
                    hand.Pack[i] = deck.Pack[index];
                    deck.Pack.RemoveAt(index);
                }
                else
                {
                    deck.Pack.AddRange(dumping.Pack);
                    dumping.Pack.Clear();
                }
            }
            return hand;
        }

        public bool ChooseFromHand(int selectedIndex)
        {
            if (selectedIndex >= 0 && selectedIndex < HAND_SIZE)
            {
                table.Add(hand.Pack[selectedIndex]);
                hand.Pack.RemoveAt(selectedIndex);
                dumping.Pack.AddRange(hand.Pack);
                hand.Pack.Clear();
                if (table.Pack.Count == TABLE_SIZE)
                {
                    PlayCombo();
                }
                return true;
            }
            return false;
        }

        private void PlayCombo()
        {
            Combo.Invoke(table);
            destroyed.Pack.AddRange(table.Pack);
            table.Pack.Clear();
        }

        public void EndBattle()
        {
            deck.Pack.AddRange(dumping.Pack);
            deck.Pack.AddRange(destroyed.Pack);
        }
    }
}
