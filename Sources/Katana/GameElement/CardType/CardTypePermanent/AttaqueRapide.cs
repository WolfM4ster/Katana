using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Katana.GameElement.Game;
using Katana.GameElement.CardType.CardTypeWeapon;
using Windows.UI.Xaml.Media.Imaging;
using System.Diagnostics;

namespace Katana.GameElement.CardType.CardTypePermanent
{
    public class AttaqueRapide : PermanentCard
    { 

        public AttaqueRapide() : base()
        {
            _description = "Vos armes causent un dégât supplémentaires";
            _name = "Attaque Rapide";
        }

        public AttaqueRapide(BitmapImage imageFront, BitmapImage imageBack) : base(imageFront, imageBack)
        {
            _description = "Vos armes causent un dégât supplémentaires";
            _name = "Attaque Rapide";
        }

        public override void activate(GameBoard b)
        {
            Player currentPlayer = b.getCurrentPlayer();

            foreach(Card c in currentPlayer.getCardsHand().ToList()){
                if(c is WeaponCard){
                    WeaponCard weapon = (WeaponCard)c;
                    weapon.setDamage(weapon.getDamage()+1);
                    currentPlayer.getCardsHand().Remove(c);
                    currentPlayer.getCardsHand().Add(weapon);
                    Debug.WriteLine("Carte Attaque Rapide activé");
                }
            }
        }

       
    }
}
