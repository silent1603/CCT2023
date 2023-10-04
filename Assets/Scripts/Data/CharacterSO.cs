///Phap Nguyen
///Description:
///Created date: 04/10/2023
///Last edit: 05/10/2023

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Data", menuName = "New Data/New Character Data")]
public class CharacterSO : ScriptableObject
{

    public string charName;
    public int health;
    public int armor;
    public float baseSpeed;
    public float maxSpeed;
    public float acceleration;

}
