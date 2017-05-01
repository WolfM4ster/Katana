using Katana.GameElement.CardType.CardTypeAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Katana.GameElement.CardType;
using Katana.GameElement.CardType.CardTypeWeapon;
using Katana.GameElement.CardType.CardTypePermanent;

namespace Katana.GameElement.Game
{
    public class Picker 
    {
        private static List<Card> _cards = new List<Card>();


        private static void init() {
            
          

        }


        public static List<Card> getPicker() {

            _cards.Add(new Bokken());
            _cards.Add(new Kanabo());
            _cards.Add(new Kusarigama());
            _cards.Add(new Kiseru());
            _cards.Add(new Nodachi());
            _cards.Add(new Daimyo());
            _cards.Add(new AttaqueRapide());
            return _cards;
        }

 
        public static void clear()
        {
            _cards.Clear();
        }

    
    }
}
