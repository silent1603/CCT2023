///Phap Nguyen
///Description:
///Created date: 04/10/2023
///Last edit: 05/10/2023

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsvReader : MonoBehaviour
{
    public TextAsset textAssetData;

    [System.Serializable]
    public class Character
    {
        public string name;
        public int health;
        public int armor;
        public float baseSpeed;
        public float maxSpeed;
        public float acceleration;
    }

    [System.Serializable]
    public class CharacterList
    {
        public Character[] character;
    }

    public CharacterList characterList = new CharacterList();

    private void Start()
    {
        ReadCSV();
    }

    void ReadCSV()
    {
        string[] data = textAssetData.text.Split(new string[] {",", "\n"}, StringSplitOptions.None);

        int tableSize = data.Length / 8 - 1;
        characterList.character = new Character[tableSize];

        print(tableSize);

        for (int i = 0; i < tableSize; i++)
        {
            print("lmao");
            characterList.character[i] = new Character();
            characterList.character[i].name = data[8 * (i + 1)];
            characterList.character[i].health =         int.Parse(data[8 * (i + 1) + 1]);
            characterList.character[i].armor =          int.Parse(data[8 * (i + 1) + 2]);
            characterList.character[i].baseSpeed =      float.Parse(data[8 * (i + 1) + 3]);
            characterList.character[i].maxSpeed =       float.Parse(data[8 * (i + 1) + 4]);
            characterList.character[i].acceleration =   float.Parse(data[8 * (i + 1) + 5]);
        }
    }
}
