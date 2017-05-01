using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Katana.GameElement.Game;
using Windows.UI.Xaml.Media.Imaging;

namespace Katana.GameElement.CardType.CardTypeCharacter
{
    public abstract class CharacterCard : Card
    {
        protected String _description;
        protected int _healthPoint;

        public CharacterCard() 
        {

        }
        
        public CharacterCard(BitmapImage imageFront, BitmapImage imageBack) : base(imageFront,imageBack)
        {

        }
       
        public String getDescription()
        {
            return _description;
        }

        public int getHealthPoint() {
            return _healthPoint;
        }

    }
}
