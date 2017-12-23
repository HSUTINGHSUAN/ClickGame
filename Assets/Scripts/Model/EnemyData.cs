using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class EnemyData
{
    public int health;
    public int willDropItemId;
    public float dropProbability;
    public float defeatTimeLimit;
    public EnemyBehavior enemyPrefab;

}
