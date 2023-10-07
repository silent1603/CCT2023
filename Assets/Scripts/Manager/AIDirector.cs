using UnityEngine;
using Utils.DesignPattern;
public class AIDirector : Singleton<AIDirector>
{

    public Transform player;

    public EnemySpawnData[] enemyToSpawn;

}

