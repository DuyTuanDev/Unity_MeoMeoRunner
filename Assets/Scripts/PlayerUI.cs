using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    static public PlayerUI Instance;
    private void Awake() {
        Instance = this;
    }
    public GameObject CanVasBtn;
    public GameObject CanVasInfoPlayer;
}
