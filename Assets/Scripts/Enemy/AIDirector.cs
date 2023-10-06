using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDirector : Singleton<AIDirector>
{

    public Transform player;

    public EnemyToSpawn[] enemyToSpawn;

}

[System.Serializable]
public class EnemyToSpawn
{
    public EnemySO enemySO;

    public int vHP;
    public int vMaxSpawn;
    public int vNumberOfSpawn;
    public int vSpawnCD;
    public float vStartTime;
    public float vDuration; 
}