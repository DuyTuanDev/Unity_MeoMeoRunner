using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomController : MonoBehaviour
{
    public GameObject fxBom;
    private Vector3 startPos;
    private float repeatWidth;
    public float speed;
    //private void LateUpdate()
    //{
    //    transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
    //}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "TaiNguyen") return;
        GameObject fx = Instantiate(fxBom, transform.position, transform.rotation);
        Destroy(fx, 2f);
        Destroy(gameObject);
    }
}
