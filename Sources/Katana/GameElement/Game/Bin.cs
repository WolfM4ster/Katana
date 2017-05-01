using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Katana.GameElement.CardType;

namespace Katana.GameElement.Game
{
    public class Bin 
    {
        private List<Card> CardList;
        private static Bin instance = new Bin();

        private Bin()
        {

        }

        public static Bin getInstance()
        {
            if(instance == null)
            {
                return instance = new Bin();
            }
            return instance;
        }

        public void addCard(Card card)
        {
            CardList.Add(card);
        }

        public void moveToPicker()
        {

        }

        public void update()
        {

        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Picker value)
        {
            throw new NotImplementedException();
        }
    }
}
