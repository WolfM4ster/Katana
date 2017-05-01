using Katana.GameElement.Game;
using Katana.GameElement.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Katana.GameElement.CardType.CardTypeWeapon
{
    public class Kanabo : WeaponCard, ActivateOnePlayer
    {
        public Kanabo() : base()
        {
            _range = 3;
            _damage = 2;
            _name = "Kanabo";
        }

        public Kanabo(BitmapImage imageFront, BitmapImage imageBack, int range, int damage) : base(imageFront, imageBack, range, damage)
        {
            _name = "Kanabo";
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
