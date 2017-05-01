using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Katana.GameElement.Game;
using Windows.UI.Xaml.Media.Imaging;

namespace Katana.GameElement.CardType.CardTypePermanent
{
    public abstract class PermanentCard : Card
    {
        protected String _description;

        public PermanentCard()
        {

        }

        public PermanentCard(BitmapImage imageFront, BitmapImage imageBack) : base(imageFront,imageBack)
        {

        }

        public String getDescription()
        {
            return _description;
        }

    }
}
