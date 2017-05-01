using Katana.GameElement.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Katana.GameElement.Game;
using Windows.UI.Xaml.Media.Imaging;
using System.Diagnostics;

namespace Katana.GameElement.CardType.CardTypeWeapon
{
    public class Bokken : WeaponCard, ActivateOnePlayer
    {
        public Bokken() : base()
        {
            _range = 1;
            _damage = 1;
            _name = "Bokken";
        }

        public Bokken(BitmapImage imageFront, BitmapImage imageBack, int range, int damage) : base(imageFront, imageBack, range, damage)
        {
            _name = "Bokken";
        }

        public override void activate(GameBoard b)
        {
            Debug.WriteLine("Selectionner le joueur à attaquer : ");
            String p = "" /*Debug.ReadLine()*/;

            Debug.WriteLine("Attaque avec arme " + _name + " sur joueur " + p);

        }

        public void activateCard(Player player)
        {
            int OldHealthPoint = player.getHealthPoint();

            int newHealthPoint = OldHealthPoint - _damage;

            player.setHealthPoint(newHealthPoint);
        }

       
    }
}
