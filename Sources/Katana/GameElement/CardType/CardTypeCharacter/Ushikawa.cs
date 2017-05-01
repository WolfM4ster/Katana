using Katana.GameElement.Game;
using Katana.GameElement.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Katana.GameElement.CardType.CardTypeCharacter
{
    public class Ushikawa : CharacterCard, PiocherCarte
    {
        private int temporaryHealthPoint;
        public Ushikawa() : base(){
            _description = "Chaque fois que vous perdez un point de vie à cause d'une arme,piochez une carte";
            _name = "Ushikawa";
            _healthPoint = 4;
            temporaryHealthPoint = _healthPoint;
        }

        public Ushikawa(BitmapImage imageFront, BitmapImage imageBack) : base(imageFront, imageBack) {
            _description = "Chaque fois que vous perdez un point de vie à cause d'une arme, piochez une carte";
            _name = "Ushikawa";
        }

        public override void activate(GameBoard b)
        {

            Player currentPlayer = b.getCurrentPlayer();
            if(b.getCurrentPlayer().getHealthPoint() < temporaryHealthPoint){
                int healthLose = temporaryHealthPoint - b.getCurrentPlayer().getHealthPoint();
                foreach(Card d in piocherCarte(healthLose)) {
                    currentPlayer.addCard(d);
                }
                temporaryHealthPoint = b.getCurrentPlayer().getHealthPoint();
            }
            else {
                Debug.WriteLine("Vous n'avez perdu aucun point de vie à cause d'une arme, vous ne pouvez pas jouer cette carte");
            }
            Debug.WriteLine("Carte Ushikawa activée !");
            
        }

      

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
