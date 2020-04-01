using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera _camera;
    private PhotonView _pv;

    private void Awake()
    {
        _pv = GetComponent<PhotonView>();
        _camera = GetComponentInChildren<Camera>();

        if (_pv.IsMine)
        {
            _camera.enabled = true;
        }
    }
}
