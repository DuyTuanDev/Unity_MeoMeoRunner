using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGameController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            GameManager.Instance.isWinGame = true;
            GameManager.Instance.SetWinGame();
        }
    }
}
