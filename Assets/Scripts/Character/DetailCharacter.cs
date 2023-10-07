using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetailCharacter : MonoBehaviour
{
    public void changeCharacter(CharacterSO newCharacter)
    {
        GameObject.Find("NameCharacter").GetComponent<TextMeshProUGUI>().text = newCharacter.charName;
        GameObject.Find("HPValue").GetComponent<TextMeshProUGUI>().text = "" + newCharacter.health;
    }
}
