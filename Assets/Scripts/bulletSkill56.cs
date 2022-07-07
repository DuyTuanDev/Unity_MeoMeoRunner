using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSkill56 : MonoBehaviour
{
    public float speedBullet;
    public GameObject exPf;
    public bool isTrigger = false;
    public bool isBullet;
    void Update()
    {
        if(isTrigger) return;
        transform.Translate(Vector3.left * speedBullet * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "TaiNguyen") return;
        if(isBullet){
            //AudioManager.Instance.SoundTriggerBullet();
        }
        isTrigger = true;
        Destroy(gameObject);
        Vector2 pos = new Vector2(transform.position.x, transform.position.y - 0.5f);
        GameObject fx = Instantiate(exPf, pos, transform.rotation);
        Destroy(fx, 2f);
    }
}
