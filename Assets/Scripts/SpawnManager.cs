using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    void Start()
    {
        InvokeRepeating("SpawnEnemy",0f, 1f);
    }

    void SpawnEnemy(){
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
