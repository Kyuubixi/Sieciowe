using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo PlayerInfoInstance;

    public int mySelectedCharacter;

    public List<GameObject> allCharacters;

    private void OnEnable()
    {
        if (PlayerInfoInstance == null)
        {
            PlayerInfoInstance = this;
        }
        else
        {
            if (PlayerInfoInstance != this)
            {
                Destroy(PlayerInfoInstance.gameObject);
                PlayerInfoInstance = this;
            }
        }
        
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("MyCharacter"))
        {
            mySelectedCharacter = PlayerPrefs.GetInt("MyCharacter");
        }
        else
        {
            mySelectedCharacter = 0;
            PlayerPrefs.SetInt("MyCharacter", mySelectedCharacter);
        }
    }
}
