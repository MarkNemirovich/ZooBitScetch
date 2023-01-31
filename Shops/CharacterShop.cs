using System;
using System.Collections.Generic;

namespace ZooBitSketch
{
    internal class CharacterShop : Shop<Active>
    {
        public CharacterShop() : base()
        {
            var eliteCharacters = new CharactersGallery(Rareness.Elite);
            var epicCharacters = new CharactersGallery(Rareness.Epic);
            var elite1 = eliteCharacters.CurrentPack[0];
            var elite2 = eliteCharacters.CurrentPack[1];
            var epic1 = epicCharacters.CurrentPack[0];
            var epic2 = epicCharacters.CurrentPack[1];
            Actives = new List<(Active active, int price, Currency currency)>() {
            new (elite1, 10, Currency.DNA),
            new (elite2, 10, Currency.DNA),
            new (epic1, 100, Currency.DNA),
            new (epic2, 100, Currency.DNA),
            };
        }
    }
}
