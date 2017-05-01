using ClassUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Katana.GameElement.CardType;
using Katana.GameElement.CardType.CardTypeCharacter;

namespace Katana.GameElement.Game
{
    public class Player : User
    {
        private List<Card> _cardsHand = new List<Card>();
        private int _honorPoint;
        private int _healthPoint;
        private RoleCard _role;
        private CharacterCard _character;
        private Boolean _myTurn=false;
        private int index;
        
        public Player(String pseudo,String mail) : base(pseudo,mail)
        {
            
        }

    
        public List<Card> getCardsHand()
        {
            return _cardsHand;
        }

        public void setCardsHand(List<Card> cardsHand)
        {
            _cardsHand = cardsHand;
        }

        public void addCard(Card card) {
            _cardsHand.Add(card);
        }

        public int getHealthPoint()
        {
            return _healthPoint;
        }

        public void setHealthPoint(int healthPoint)
        {
            _healthPoint = healthPoint;
        }

        public RoleCard getRole() {
            return _role;
        }

       

        public void setRole(RoleCard role) {
            _role = role;
            if (_role.getName().Equals("SHOGUN")) {
                _honorPoint = 5;
            }else {
                _honorPoint = 4;
            }
        }

        public Boolean turn()
        {
            return _myTurn;
        }

        public void setTurn(Boolean b)
        {
            _myTurn = b;
        }

        public CharacterCard getCharacter()
        {
            return _character;
        }

        public void setCharacter(CharacterCard character)
        {
            _character = character;
            _healthPoint = _character.getHealthPoint();
        }

        public void finishTurn()
        {
            if (_myTurn == true) {
                _myTurn = false;
            }
           
        }

        public void piocher()
        {
            if (_myTurn == true){
                this.addCard(Picker.getPicker().ElementAt(0));
                this.addCard(Picker.getPicker().ElementAt(1));

                Picker.getPicker().Remove((Picker.getPicker().ElementAt(0)));
                Picker.getPicker().Remove((Picker.getPicker().ElementAt(1)));
            }
        }

    }
}
