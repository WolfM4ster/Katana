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
    public class CeremonieDuThe : ActionCard , PiocherCarte
    {
        public CeremonieDuThe() : base()
        {
            _description = "Piochez 3 cartes. Les autres joueurs piochent une carte";
            _name = "Cérémonie du Thé";
        }

        public CeremonieDuThe(BitmapImage imageFront, BitmapImage imageBack) : base(imageFront, imageBack)
        {
            _description = "Piochez 3 cartes. Les autres joueurs piochent une carte";
            _name = "Cérémonie du Thé";
        }

        public override void activate(GameBoard b)
        {
            activateCard(b.getCurrentPlayer());
            Debug.WriteLine("3 cartes ont été ajoutées pour " + b.getCurrentPlayer().getPseudo());
            List<Card> cards = piocherCarte(b.getPlayers().Count);
            int i = 0;
            foreach (Player player in b.getPlayers().ToList()){
                player.addCard(cards[i]);
                i++;
            }
            Debug.WriteLine("une carte a été ajoutée pour tous les autres joueurs");

        }

        public void activateCard(Player player)
        {
            List<Card> newCardsHand = new List<Card>();
            newCardsHand = player.getCardsHand();

            foreach (Card card in piocherCarte(3))
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


            for (int i = 0; i <= n - 1; i++)
            {
                cartePioches.Add(pioche[i]);
                pioche.Remove(pioche[i]);

            }

            return cartePioches;
        }
    }
}
