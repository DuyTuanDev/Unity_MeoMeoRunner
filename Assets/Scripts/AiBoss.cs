using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBoss : MonoBehaviour
{
    public List<GameObject> listSkill = new List<GameObject>();
    public Rigidbody2D mBody;
    public Animator mAni;
    public float speed = 4f;
    public bool isEnemy;
    public int indexSkill;
    public bool isAttack;
    public GameObject tenThan;
    public GameObject bullet;
    public GameObject bomFx;
    public Transform posTen;
    public Transform posBullet;
    public Transform posBom;
    public enum Status{
        IDLE,
        WAlK,
        RUN,
        JUMP,
        ATTACK
    }
    private void Start() {
        transform.position = new Vector2(Random.Range(-8f, 8f), transform.position.y);
        Invoke("SetStatus", 1.5f);
        for (int i = 1; i < listSkill.Count; i++)
        {
            listSkill[i].SetActive(false);
        }
        StartCoroutine(RandomStatus());
    }
    public void SetStatus(){
        if(!isAttack){
            // StartCoroutine(RandomStatus());
        }
    }
    public Status status = Status.IDLE;
    public bool isGround = true;
    float h;
    int rand;
    void FixedUpdate()
    {
        switch (status)
        {
            case Status.IDLE:
                mAni.SetFloat("speed", 0f);
                break;
            case Status.WAlK:
                if (rand == 0){
                    h = -0.4f;
                }
                else{
                    h = 0.4f;
                }
                    mBody.velocity = new Vector3(h * speed, mBody.velocity.y);
                    mAni.SetFloat("speed", Mathf.Abs(h));
                if(h < 0f){
                    transform.eulerAngles = new Vector3(0,0,0);
                }
                else if(h > 0f){
                    transform.eulerAngles = new Vector3(0,180,0);
                }
                break;
            case Status.RUN:
                if (rand == 0){
                    h = -1f;
                }
                else{
                    h = 1f;
                }
                    mBody.velocity = new Vector3(h * speed, mBody.velocity.y);
                    mAni.SetFloat("speed", Mathf.Abs(h));
                if(h < 0f){
                    transform.eulerAngles = new Vector3(0,0,0);
                }
                else if(h > 0f){
                    transform.eulerAngles = new Vector3(0,180,0);
                }
                break;
            case Status.JUMP:
                if(isGround){
                    mBody.AddForce(new Vector2(0, 300f));
                    mAni.SetTrigger("Jump");
                    isGround = false;
                }
                break;
            case Status.ATTACK:
                if(!isAttack && indexSkill > 0){
                    switch (indexSkill)
                    {
                        case 1: 
                            StartCoroutine(AttackGan(0.5f));
                                break;
                        case 2: 
                            StartCoroutine(AttackGan(1f));
                            break;
                        case 3:
                            StartCoroutine(AttackGan(0.6f));
                            break;
                        case 4:
                            StartCoroutine(AttackGan(2f));
                            break;
                        case 5:
                            StartCoroutine(AttackXa(0.4f, tenThan));
                            break;
                        case 6:
                            StartCoroutine(AttackXa(0.6f, bullet));
                            break;
                        default:
                            break;
                    }
                }
                break;
            default:
                break;
        }
    }
    IEnumerator AttackGan(float timeAt){
        isAttack = true;
        listSkill[0].SetActive(false);
        listSkill[indexSkill].SetActive(true);
        yield return new WaitForSeconds(timeAt);
        if(indexSkill == 4){
            GameObject sp = Instantiate(bomFx, posBom.position, transform.rotation);
            if(transform.eulerAngles.y == 180f){
                sp.GetComponent<Rigidbody2D>().AddForce(new Vector2(300f, 300f));
            }
            else{
                sp.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300f, 300f));
            }
            
        }
        listSkill[0].SetActive(true);
        listSkill[indexSkill].SetActive(false);
        isAttack = false;
    }
    IEnumerator AttackXa(float timeAt, GameObject gun){
        isAttack = true;
        listSkill[0].SetActive(false);
        listSkill[indexSkill].SetActive(true);
        float tm = timeAt;
        // SpawnBullet(gun);
        if(indexSkill == 6){
            // AudioManager.Instance.SoundBullet();
            SpawnBullet(gun);
            yield return new WaitForSeconds(0.2f);
            // AudioManager.Instance.SoundBullet();
            SpawnBullet(gun);
            yield return new WaitForSeconds(0.2f);
            // AudioManager.Instance.SoundBullet();
            SpawnBullet(gun);
            yield return new WaitForSeconds(0.2f);
        }
        if(indexSkill == 5){
            yield return new WaitForSeconds(timeAt);
            SpawnTen(gun);
        }
        listSkill[0].SetActive(true);
        listSkill[indexSkill].SetActive(false);
        isAttack = false;
        
    }
    public void SpawnTen(GameObject gun){
        GameObject sp = Instantiate(gun , posTen.position, transform.rotation);
        // sp.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000f, 0f));
    }
    public void SpawnBullet(GameObject gun){
        GameObject sp = Instantiate(gun , posBullet.position, transform.rotation);
        // sp.GetComponent<Rigidbody2D>().AddForce(new Vector2(1500f, 0f));
    }
    IEnumerator RandomStatus(){
        status = (Status)Random.Range(0, 5);
        rand = Random.Range(0,2);
        yield return new WaitForSeconds(2f);
        StartCoroutine(RandomStatus());
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Ground"){
            isGround = true;
        }
        else{
            h *= -1;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            status = Status.ATTACK;
        }
        else{
            status = Status.IDLE;
        }
    }
}
