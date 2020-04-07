using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PPlayerHealth : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField] private ScriptableFloat maxHp;
    [SerializeField] private float currentHp;
    private PhotonView _pv;

    private void Start()
    {
        _pv = GetComponent<PhotonView>();
        currentHp = maxHp.Value;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            TakeDamage(-10f);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10f);
        }
    }

    public void TakeDamage(float p_damageTaken)
    {
        _pv.RPC("RPC_TakeDamage", RpcTarget.All, p_damageTaken);
    }
    
    [PunRPC]
    public void RPC_TakeDamage(float p_damageTaken)
    {
        currentHp -= p_damageTaken;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(currentHp);
            
            Debug.Log("Client ID: " + _pv.ViewID + " my current hp is " + currentHp);
        }
    }
}
