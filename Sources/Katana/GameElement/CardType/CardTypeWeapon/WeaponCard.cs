using Katana.GameElement.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Katana.GameElement.Game;
using Windows.UI.Xaml.Media.Imaging;

namespace Katana.GameElement.CardType.CardTypeWeapon
{
    public abstract class WeaponCard : Card
    {
        protected int _range;
        protected int _damage;

        public WeaponCard() 
        {
           
        }

        public WeaponCard(BitmapImage imageFront,BitmapImage imageBack,int range, int damage) : base(imageFront,imageBack)
        {
            _range = range;
            _damage = damage;

        }


        public int getRange()
        {
            return _range;
        }

        public int getDamage()
        {
            return _damage;
        }

        public void setDamage(int damage)
        {
            _damage = damage;
        }

        public void activateCard(GameBoard b)
        {
            throw new NotImplementedException();
        }

     
    }
}
