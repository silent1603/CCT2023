using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MusicVolume : MonoBehaviour
{
    public TextMeshProUGUI musicVolume;
    public int value;
    

    void Start()
    {
        musicVolume.text = "Music Volume : " + value + "%";
    }

    public void onClick()
    {
        if (value == 100) value = 0;
        else value += 25;
    }

    void Update()
    {
        musicVolume.text = "Music Volume : " + value + "%";
    }
}
