using System;
using System.Collections.Generic;

namespace ZooBitSketch
{
    internal class Gallery<T> where T : Active
    {
        protected Random rand = new Random();
        protected T[] _ordinary;
        protected T[] _rare;
        protected T[] _elite;
        protected T[] _epic;
        protected T[] _legendary;

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
        public T[] CurrentList { get; protected set; }
        public List<Active> FullCardList()
        {
            List<Active> allCards = UpCast(_ordinary);
            allCards.AddRange(UpCast(_rare));
            allCards.AddRange(UpCast(_elite));
            allCards.AddRange(UpCast(_epic));
            allCards.AddRange(UpCast(_legendary));
            return allCards;
        }
        public T GetCharacter()
        {
            int number = rand.Next(0, CurrentList.Length);
            return CurrentList[number];
        }
        public T[] StartedPack(int size)
        {
            if (size == 0)
                return _ordinary;
            return null;
        }
    }
}
