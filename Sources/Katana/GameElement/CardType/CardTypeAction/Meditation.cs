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
    public class Meditation : ActionCard
    {
        public Meditation() : base()
        {
            _description = "Récupérez tous vos points de vie, Un autre joueur de votre choix pioche une carte";
            _name = "Meditation";
        }

        public Meditation(BitmapImage imageFront, BitmapImage imageBack) : base(imageFront, imageBack)
        {
            _description = "Récupérez tous vos points de vie, Un autre joueur de votre choix pioche une carte";
            _name = "Meditation";
        }

        public override void activate(GameBoard b)
        {
            b.getCurrentPlayer().setHealthPoint(b.getCurrentPlayer().getCharacter().getHealthPoint());
            Debug.WriteLine("Vous avez récupérez tous vos points de vie !");

            Debug.WriteLine("Selectionnez le joueur qui doit piocher une carte : ");
            Debug.WriteLine("2 cartes ont été ajoutées pour " + b.getCurrentPlayer().getPseudo());
        }


        // Permet d'activer l'action associé à la carte
        public void activateCard(Player player)
        {

            List<Card> newCardsHand = new List<Card>();
            newCardsHand = player.getCardsHand();

            foreach (Card card in piocherCarte(2))
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
