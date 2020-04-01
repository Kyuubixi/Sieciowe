using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    private PhotonView _pv;
    private CharacterController _myCharacterController;
    [SerializeField] private float movementSpeed;
    private float _sprintingMovementSpeed;
    [SerializeField] private float rotationSpeed;
    private float _mouseX;
    private bool _isSprinting = false;

    private void Awake()
    {
        _pv = GetComponent<PhotonView>();
        _myCharacterController = GetComponent<CharacterController>();
        _sprintingMovementSpeed = movementSpeed * 2;
    }

    void Update()
    {
        if (!_pv.IsMine) return;
        if (Input.GetKey(KeyCode.LeftShift) ? _isSprinting = true : _isSprinting = false);
        Movement(!_isSprinting ? movementSpeed : _sprintingMovementSpeed);
        Rotation();
    }


    private void Movement(float pMovementSpeed)
    {
        if (Input.GetKey(KeyCode.W)) _myCharacterController.Move(pMovementSpeed * Time.deltaTime * transform.forward);
        if (Input.GetKey(KeyCode.A)) _myCharacterController.Move(pMovementSpeed * Time.deltaTime * -transform.right);
        if (Input.GetKey(KeyCode.S)) _myCharacterController.Move(pMovementSpeed * Time.deltaTime * -transform.forward);
        if (Input.GetKey(KeyCode.D)) _myCharacterController.Move(pMovementSpeed * Time.deltaTime * transform.right);
    }

    private void Rotation()
    {
        _mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed;
        transform.Rotate(new Vector3(0f, _mouseX, 0f));
    }
}
