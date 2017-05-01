using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Katana.GameElement.CardType;
using Katana.GameElement.CardType.CardTypeCharacter;

namespace Katana.GameElement.Game
{
    public class GameBoard
    {
        private PlayerEquip winner;
        private Bin bin;
        private Picker picker;
        private List<Player> playerList = new List<Player>();
        private List<PlayerEquip> groupPlayerList;
        private Player _currentPlayer;

        public GameBoard()
        {
        }

        public void startGame() {
           



            
        }

       
        public void attribuerCarteRole(int nbJoueurs) {
            switch (nbJoueurs)
            {
                case 3:
                    List<Card> rolesCard = new List<Card>();
                    rolesCard = getRoleCard(3);
                    for (int i = 0; i <= getPlayers().Count - 1; i++){

                        int randomNum = new Random().Next(0,rolesCard.Count);
                        playerList[i].setRole((RoleCard)rolesCard.ElementAt(randomNum));
                        rolesCard.Remove(rolesCard.ElementAt(randomNum));
                    }
                    break;
                case 4:
                    List<Card> rolesCard1 = getRoleCard(4);
                    for(int i=0;i<= getPlayers().Count-1;i++){ 
                        int randomNum = new Random().Next(0,rolesCard1.Count);
                        playerList[i].setRole((RoleCard)rolesCard1.ElementAt(randomNum));
                        rolesCard1.Remove(rolesCard1.ElementAt(randomNum));
                        
                    }
                    break;
                case 5:
                    List<Card> rolesCard2 = getRoleCard(5);
                    for (int i = 0; i <= getPlayers().Count - 1; i++){

                        int randomNum = new Random().Next(0,rolesCard2.Count);
                        playerList[i].setRole((RoleCard)rolesCard2.ElementAt(randomNum));    
                        rolesCard2.Remove(rolesCard2.ElementAt(randomNum));

                    }
                    break;
                case 6:
                    List<Card> rolesCard3 = getRoleCard(6);
                    for (int i = 0; i <= getPlayers().Count - 1; i++) {

                        int randomNum = new Random().Next(0,rolesCard3.Count);
                        playerList[i].setRole((RoleCard)rolesCard3.ElementAt(randomNum));
                        rolesCard3.Remove(rolesCard3.ElementAt(randomNum));

                    }
                    break;
                case 7:
                    List<Card> rolesCard4 = getRoleCard(7);
                    for (int i = 0; i <= getPlayers().Count - 1; i++){
                        int randomNum = new Random().Next(0,rolesCard4.Count);
                        playerList[i].setRole((RoleCard)rolesCard4.ElementAt(randomNum));
                        rolesCard4.Remove(rolesCard4.ElementAt(randomNum));
                    }
                    break;
            }
            
            
        }

        // On récupère le nb de cartes de rôle nécessaire
        private List<Card> getRoleCard(int nbJoueurs)
        {
            List<Card> roleCardNecessary = new List<Card>();
            switch (nbJoueurs)
            {
                case 3:
                    addRoleCard("SHOGUN", roleCardNecessary);
                    addRoleCard("NINJA", roleCardNecessary);
                    addRoleCard("NINJA", roleCardNecessary);
                    break;
                case 4:
                    addRoleCard("SHOGUN", roleCardNecessary );
                    addRoleCard("SAMOURAI", roleCardNecessary);
                    addRoleCard("NINJA", roleCardNecessary);
                    addRoleCard("NINJA", roleCardNecessary);
                    break;
                case 5:
                    addRoleCard("SHOGUN", roleCardNecessary);
                    addRoleCard("SAMOURAI", roleCardNecessary);
                    addRoleCard("RONIN", roleCardNecessary);
                    addRoleCard("NINJA", roleCardNecessary);
                    addRoleCard("NINJA", roleCardNecessary);
                    break;
                case 6:
                    addRoleCard("SHOGUN", roleCardNecessary);
                    addRoleCard("SAMOURAI", roleCardNecessary);
                    addRoleCard("RONIN", roleCardNecessary);
                    addRoleCard("NINJA", roleCardNecessary);
                    addRoleCard("NINJA", roleCardNecessary);
                    addRoleCard("NINJA", roleCardNecessary);
                    break;
                case 7:
                    addRoleCard("SHOGUN", roleCardNecessary);
                    addRoleCard("SAMOURAI", roleCardNecessary);
                    addRoleCard("SAMOURAI", roleCardNecessary);
                    addRoleCard("RONIN", roleCardNecessary);
                    addRoleCard("NINJA", roleCardNecessary);
                    addRoleCard("NINJA", roleCardNecessary);
                    addRoleCard("NINJA", roleCardNecessary);
                    break;


            }

            return roleCardNecessary;

        }

        public void attribuerPersonnage(){

        }

        private void addRoleCard(String roleCard, List<Card> list)
        {
            list.Add(new RoleCard(roleCard));
        }


        public void setCurrentPlayer() {
           foreach(Player player in playerList.ToList()) {
                if (player.getRole().getName().Equals("SHOGUN"))
                {
                    _currentPlayer = player;
                    _currentPlayer.setTurn(true);
                }
            }
        }

        public void distributeFirstCard(){

        }

        public Player getCurrentPlayer()
        {
            return _currentPlayer;
        }

        public void activatePlayerCard(Player player,Card playerCard)
        {
            if (player.turn()){
                if (playerCard is CharacterCard)
                {
                    playerCard.activate(this);

                }
                else {
                    playerCard.activate(this);
                    _currentPlayer.getCardsHand().Remove(playerCard);
    
                }
            }
            
        }

        public void addPlayer(Player p)
        {
            playerList.Add(p);
        }

        public List<Player> getPlayers()
        {
            return playerList;
        }

        public void nextPlayer(){

        }

        public void giveCard(){

        }
    }
}
