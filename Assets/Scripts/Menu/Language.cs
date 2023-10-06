using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Language : MonoBehaviour
{
    public TextMeshProUGUI languageText;
    public string value;
    // Start is called before the first frame update
    void Start()
    {
        languageText.text = "Language : " + value;
    }

    public void OnClick(TextMeshProUGUI languageToChange)
    {
        value = languageToChange.text;
    }
    // Update is called once per frame
    void Update()
    {
        languageText.text = "Language : " + value;
    }
}
