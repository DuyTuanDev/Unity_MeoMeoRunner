using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBg : MonoBehaviour
{
    static public SpawnBg Instance;
    public List<GameObject> grounds = new List<GameObject>();
    private void Awake() {
        Instance = this;
    }

    // Update is called once per frame
    public void SpawnBackground(){
        Instantiate(grounds[Random.Range(0, grounds.Count)], transform.position, Quaternion.identity);
        Debug.Log(grounds[Random.Range(0, grounds.Count)]);
    }
}
