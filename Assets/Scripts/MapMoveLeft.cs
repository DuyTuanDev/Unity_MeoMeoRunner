using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMoveLeft : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    public float speed;
    public bool isSpawn = false;
    private void Start()
    {
        // startPos = transform.position;
        // repeatWidth = GetComponent<BoxCollider2D>().size.x / 2;
    }

    private void LateUpdate()
    {
        if(PlayerMeoController.Instance.isAttack || !PlayerMeoController.Instance.isRuning || PlayerMeoController.Instance.isGameOver || GameManager.Instance.isWinGame) return;
        // if(GameManager.Instance.isGameOver || !GameManager.Instance.isGamePlay) return;
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        if(transform.position.x < -7f && !isSpawn){
            // SpawnBg.Instance.SpawnBackground();
            isSpawn = true;
            // Destroy(gameObject, 7f);
        }
        // if (transform.position.x < startPos.x - repeatWidth)
        // {
        //     transform.position = startPos;
        // }
    }
}
