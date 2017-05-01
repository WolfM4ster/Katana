using Katana.GameElement.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Katana.GameElement.Game;
using Windows.UI.Xaml.Media.Imaging;

namespace Katana.GameElement.CardType
{
    public abstract class Card 
    {
        protected BitmapImage _imageFront { get; set; }
        protected BitmapImage _imageBack {get;set;}
        protected String _name;

        public Card()
        {
            
        }

        public Card(BitmapImage imageFront, BitmapImage imageBack)
        {
            _imageFront = imageFront;
            _imageBack = imageBack;

        }

        public String getName()
        {
            return _name;
        }

        public abstract void activate(GameBoard b);
        
    }
}
