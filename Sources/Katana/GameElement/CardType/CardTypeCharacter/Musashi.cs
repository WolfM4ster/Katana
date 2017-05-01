using Katana.GameElement.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using Katana.GameElement.Game;
using Katana.GameElement.CardType.CardTypeWeapon;
using Windows.UI.Xaml.Media.Imaging;
using System.Diagnostics;

namespace Katana.GameElement.CardType.CardTypeCharacter
{
    public class Musashi : CharacterCard
    {
        public Musashi() : base(){
            _description = "Vos armes causent un dégât supplémentaire";
            _name = "Musashi";
            _healthPoint = 5;
        }

        public Musashi(BitmapImage imageFront, BitmapImage imageBack) : base(imageFront, imageBack) {
            _description = "Vos armes causent un dégât supplémentaire";
            _name = "Musashi";
        }

        public override void activate(GameBoard b)
        {
            Player currentPlayer = b.getCurrentPlayer();

            foreach (Card c in currentPlayer.getCardsHand().ToList())
            {
                if (c is WeaponCard)
                {
                    WeaponCard weapon = (WeaponCard)c;
                    weapon.setDamage(weapon.getDamage() + 1);
                    currentPlayer.getCardsHand().Remove(c);
                    currentPlayer.getCardsHand().Add(weapon);
                    Debug.WriteLine("Carte Musashi activé");
                }
            }
        }
      
    }
}
