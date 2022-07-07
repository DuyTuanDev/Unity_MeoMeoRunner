using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesController : MonoBehaviour
{
    public int gold;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            PlayerData.Instance.gold += gold;
            PlayerData.Instance.SaveDataGame();
            Destroy(gameObject);
        }
    }
}
