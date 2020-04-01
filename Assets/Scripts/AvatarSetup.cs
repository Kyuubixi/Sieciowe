using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class AvatarSetup : MonoBehaviour
{
    private PhotonView _pv;
    public GameObject myCharacter;
    public int characterValue;

    private void Awake()
    {
        _pv = GetComponent<PhotonView>();
    }

    private void Start()
    {
        if (_pv.IsMine)
        {
            _pv.RPC("RPC_AddCharacter", RpcTarget.AllBuffered, PlayerInfo.PlayerInfoInstance.mySelectedCharacter);
        }
    }

    [PunRPC]
    private void RPC_AddCharacter(int pCharacterIndex)
    {
        characterValue = pCharacterIndex;
        myCharacter = Instantiate(PlayerInfo.PlayerInfoInstance.allCharacters[pCharacterIndex], transform.position, transform.rotation, transform);
    }
}
