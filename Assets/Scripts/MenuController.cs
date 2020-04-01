using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private List<Button> characterButtons;

    private void Start()
    {
        for (int i = 0; i < characterButtons.Count; i++)
        {
            int number = i;
            characterButtons[i].onClick.AddListener(delegate { OnClickCharacterPick(number); });
        }
    }

    private void OnClickCharacterPick(int pCharacterIndex)
    {
        if (PlayerInfo.PlayerInfoInstance != null)
        {
            PlayerInfo.PlayerInfoInstance.mySelectedCharacter = pCharacterIndex;
            PlayerPrefs.SetInt("MyCharacter", pCharacterIndex);
        }
    }
}
