using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    private PhotonView _pv;
    private Rigidbody _rb;
    private CharacterController _myCharacterController;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;

    private void Awake()
    {
        _pv = GetComponent<PhotonView>();
        _rb = GetComponent<Rigidbody>();
        _myCharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!_pv.IsMine) return;
        Movement();
        Rotation();
    }


    private void Movement()
    {
        var movementJoystick = GameSetup.GameSetupInstance.movementJoystick;
        _rb.AddRelativeForce(Time.deltaTime * movementSpeed * new Vector3(movementJoystick.Horizontal, 0, movementJoystick.Vertical));
    }

    private void Rotation()
    {
        transform.Rotate(new Vector3(0f, GameSetup.GameSetupInstance.rotationJoystick.Horizontal, 0f) * rotationSpeed);
    }
}
