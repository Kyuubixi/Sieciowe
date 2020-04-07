using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    private static GameSetup _gameSetupInstance;

    public static GameSetup GameSetupInstance
    {
        get
        {
            if (!_gameSetupInstance)
            {
                Debug.LogError("GameSetup instance not found");
            }

            return _gameSetupInstance;
        }
    }

    public List<GameObject> spawnPoints;

    public Joystick movementJoystick;
    public Joystick rotationJoystick;

    private void Awake()
    {
        if (_gameSetupInstance == null)
        {
            _gameSetupInstance = this;
        }
        else
        {
            if (_gameSetupInstance == this) return;
            
            Destroy(_gameSetupInstance.gameObject);
            _gameSetupInstance = this;
        }
    }

}