using System.Collections.Generic;
using ZooBitSketch.Property.Decks;

namespace ZooBitSketch.Battle
{
    internal class Battle
    {
        private BattleCards playerDeck;
        private BattleCards opponentDeck;

        public Battle(Deck playerDeck, Deck opponentDeck)
        {
            playerDeck = new BattleCards(playerDeck);
            opponentDeck = new BattleCards(opponentDeck);
        }



    }
}
