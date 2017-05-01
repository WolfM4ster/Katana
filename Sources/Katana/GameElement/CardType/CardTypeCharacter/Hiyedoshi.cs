using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Katana.GameElement.Game;
using Katana.GameElement.Interface;
using Windows.UI.Xaml.Media.Imaging;
using System.Diagnostics;

namespace Katana.GameElement.CardType.CardTypeCharacter
{
    public class Hiyedoshi : CharacterCard, PiocherCarte, ActivateOnePlayer
    {

        public Hiyedoshi() : base(){
            _description = "Durant votre phase de pioche, piochez une carte supplémentaire";
            _name = "Hiyedoshi";
            _healthPoint = 4;
        }

        public Hiyedoshi(BitmapImage imageFront, BitmapImage imageBack) : base(imageFront, imageBack) {
            _description = "Durant votre phase de pioche, piochez une carte supplémentaire";
            _name = "Hiyedoshi";
        }

        public override void activate(GameBoard b) {
            activateCard(b.getCurrentPlayer());
            Debug.WriteLine("Carte Hiyedoshi activée !");
        }

        public void activateCard(Player player) {
            List<Card> newCardsHand = new List<Card>();
            newCardsHand = player.getCardsHand();

            foreach (Card card in piocherCarte(1))
            {
                newCardsHand.Add(card);
            }

            player.setCardsHand(newCardsHand);
        }

        public List<Card> piocherCarte(int n) {
            List<Card> pioche = new List<Card>();
            pioche = Picker.getPicker();
            List<Card> cartePioches = new List<Card>();

            for (int i = 0; i <= n - 1; i++){
                cartePioches.Add(pioche[i]);
                pioche.Remove(pioche[i]);
            }

            return cartePioches;
        }
    }
}
