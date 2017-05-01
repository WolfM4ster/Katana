using Katana.GameElement.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Katana.GameElement.Game;
using Windows.UI.Xaml.Media.Imaging;
using System.Diagnostics;

namespace Katana.GameElement.CardType.CardTypeAction
{
    public class Daimyo : ActionCard , PiocherCarte, ActivateOnePlayer
    {

        public Daimyo() : base()
        {
            _description = "Piochez 2 cartes. Si vous possédez cette carte à la fin de la partie, elle vous rapporte un point d'honneur.";
            _name = "Daimyo";
        }

        public Daimyo(BitmapImage imageFront, BitmapImage imageBack) : base(imageFront, imageBack)
        {
            _description = "Piochez 2 cartes. Si vous possédez cette carte à la fin de la partie, elle vous rapporte un point d'honneur.";
            _name = "Daimyo";
        }

        public override void activate(GameBoard b)
        {
                activateCard(b.getCurrentPlayer());
                Debug.WriteLine("2 cartes ont été ajoutées pour " + b.getCurrentPlayer().getPseudo());
         
        }


        // Permet d'activer l'action associé à la carte
        public void activateCard(Player player)
        {

            List<Card> newCardsHand= new List<Card>();
            newCardsHand = player.getCardsHand();

            foreach(Card card in piocherCarte(2))
            {
                newCardsHand.Add(card);
            }

            player.setCardsHand(newCardsHand);

        }


        // Action piocher carte/
        public List<Card> piocherCarte(int n)
        {
            
            List<Card> pioche = new List<Card>();
            pioche = Picker.getPicker();
            List<Card> cartePioches = new List<Card>();
          

            for(int i = 0; i <= n - 1; i++) {
                cartePioches.Add(pioche[i]);
                pioche.Remove(pioche[i]);

            }
           
            return cartePioches;
        }
    }
}
