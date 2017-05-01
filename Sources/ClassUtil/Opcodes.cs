using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassUtil
{
    public enum Opcodes
    {
        CS_CONNEXION,
        SC_CONNEXION_OK,

        CS_REGISTRATION,
        SC_REGISTRATION_OK,

        CS_REFRESH,
        SC_REFRESH_OK,

        CS_EXIT,
        SC_EXIT_OK,

        CS_MESSAGE,
        SC_MESSAGE_OK,

        CS_RECEIVE_MESSAGE,
        SC_RECEIVE_MESSAGE_OK,

        CS_PLAYER_LIST,
        SC_PLAYER_LIST_OK,
        
        CS_UPDATE_DATA,
        SC_UPDATE_DATA_OK,

        SEPARATOR_DATA,

        SC_QUERY_OK,
        
        SC_ERROR_SERVER,
        SC_ERROR_SAME_MAIL,
        SC_ERROR_SAME_PSEUDO,
        SC_ERROR_SAME_ELEMENT,
        SC_ERROR_EMPTY,
        SC_ERROR_BANNED,

        CS_FORGOT_PASSWORD,
        SC_FORGOT_PASSWORD_OK,

        NULL

        /*CONNEXION,
        INSCRIPTION,
        REFRESH,
        NEWS,
        EXIT,
        MESSAGE,
        RECEIVE_MESSAGE,
        CREATE_GAME,
        REJOIN_GAME*/
    }
}

