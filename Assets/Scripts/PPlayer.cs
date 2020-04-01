using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using UnityEngine;

public class PPlayer : MonoBehaviour
{
    private PhotonView _pv;
    private int _spawnPicker;
    public GameObject myAvatar;

    private void Awake()
    {
        _pv = GetComponent<PhotonView>();
    }

    private void Start()
    {
        _spawnPicker = PhotonNetwork.PlayerList.Length - 1;

        if (_pv.IsMine)
        {
            myAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerAvatar"), GameSetup.GameSetupInstance.spawnPoints[_spawnPicker].transform.position, GameSetup.GameSetupInstance.spawnPoints[_spawnPicker].transform.rotation, 0);
        }
    }
}
