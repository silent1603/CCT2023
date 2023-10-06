using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SFXVolume : MonoBehaviour
{
    public TextMeshProUGUI sfxVolume;
    public int value;
    

    void Start()
    {
        sfxVolume.text = "SFX Volume : " + value + "%";
    }

    public void onClick()
    {
        if (value == 100) value = 0;
        else value += 25;
    }

    void Update()
    {
        sfxVolume.text = "SFX Volume : " + value + "%";
    }
}
