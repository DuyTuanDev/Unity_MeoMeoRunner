using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeoAttack : MonoBehaviour
{
    static public PlayerMeoAttack Instance;
    private void Awake() {
        Instance = this;
    }
    
    private void Update() {
        
        // #if UNITY_ANDROID
        //     AttackJoy();

        // // #elif UNITY_STANDALONE_WIN
        //     // AttackPc();
        // #endif
        
        
    }
    
}
