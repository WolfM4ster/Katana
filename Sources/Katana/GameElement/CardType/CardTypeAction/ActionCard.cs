using Katana.GameElement.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Katana.GameElement.Game;
using Windows.UI.Xaml.Media.Imaging;

namespace Katana.GameElement.CardType.CardTypeAction
{
    public abstract class ActionCard : Card
    {
        protected String _description;

        public ActionCard()
        {
           
        }

        public ActionCard(BitmapImage imageFront, BitmapImage imageBack) : base(imageFront,imageBack)
        {
            
        }


        public String getDescription()
        {
            return _description;
        }

        
    }
}
