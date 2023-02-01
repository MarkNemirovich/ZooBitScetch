using System;
using System.Collections.Generic;
using ZooBitSketch.Enums;
using ZooBitSketch.Property.Actives;

namespace ZooBitSketch.Property.Galleries
{
    internal class Gallery<T> where T : Active
    {
        private Random rand = new Random();
        protected Dictionary<Rareness,T[]> allActives;
        protected Gallery()
        {
            allActives = new Dictionary<Rareness, T[]>();
        }

        protected States RandomStates(Rareness rareness)
        {
            return new States(rareness);
        }
        protected List<Active> UpCast(T[] array)
        {
            List<Active> list = new List<Active>(array.Length);
            foreach (T card in array)
                list.Add(card as Active);
            return list;
        }
        public T[] CurrentPack { get; protected set; }
        public List<Active> FullCardList()
        {
            List<Active> allCards = new List<Active>();
            foreach (var active in allActives)
            {
                allCards.AddRange(active.Value);
            }
            return allCards;
        }
        public T GetCharacter()
        {
            int number = rand.Next(0, CurrentPack.Length);
            return CurrentPack[number];
        }
        public T[] StartedPack()
        {
            allActives.TryGetValue(Rareness.Ordinary, out T[] pack);
            return pack;
        }
    }
}
