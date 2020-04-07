using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PPlayerShooting : MonoBehaviourPunCallbacks
{
    [SerializeField] private ScriptableFloat damageAmount;
    private PhotonView _pv;
    private Transform _rayOrigin;

    private void Awake()
    {
        _rayOrigin = transform;
        _pv = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (!_pv.IsMine) return;
        if (Input.GetMouseButtonDown(0))
        {
            _pv.RPC("RPC_Fire", RpcTarget.All);
        }
    }

    [PunRPC]
    private void RPC_Fire()
    {
        Debug.Log("Fire");
        RaycastHit hit;
        if (Physics.Raycast(transform.position, _rayOrigin.TransformDirection(Vector3.forward), out hit, 1000))
        {
            Debug.DrawRay(_rayOrigin.position, _rayOrigin.TransformDirection(Vector3.forward) * hit.distance, Color.cyan, 2f);
            if (hit.transform.CompareTag("Player"))
            {
                hit.transform.gameObject.GetComponent<PPlayerHealth>().TakeDamage(damageAmount.Value);
            }
        }
    }
}
