using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNoAttack : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rBody;
    public GameObject fxDead;
    public List<GameObject> items = new List<GameObject>();
    public int indexIt;
    // public void Attack(Animator animator){
    //     animator.SetTrigger("Attack");
    // }
    public void Dead(){
        GameObject fx = Instantiate(fxDead, transform.position, transform.rotation);
        animator.SetBool("Dead", true);
        GetComponent<BoxCollider2D>().enabled = false;
        GameObject it = Instantiate(items[indexIt], transform.position, transform.rotation);
        GameObject cha = GameObject.Find("map1");
        it.transform.parent = cha.transform;
        Destroy(fx, 1.5f);
        Destroy(it, 5f);
        Destroy(gameObject, 1f);
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Weapon"){
            Dead();
        }
    }
}
