using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Katana.GameElement.Game;
using Windows.UI.Xaml.Media.Imaging;
using System.Diagnostics;

namespace Katana.GameElement.CardType
{
    public class RoleCard : Card
    {

        public RoleCard(String name) : base()
        {
            _name = name;
        }

        public RoleCard(BitmapImage imageFront, BitmapImage imageBack) : base(imageFront,imageBack)
        {
        

        }



        public override void activate(GameBoard b)
        {
            Debug.WriteLine("Une carte de rôle ne peut être activé");
        }
    }
}
