using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCameraPlayer : MonoBehaviour
{
    public GameObject cams;
    static public FindCameraPlayer Instance;
    private void Awake() {
        if(Instance != null){
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
