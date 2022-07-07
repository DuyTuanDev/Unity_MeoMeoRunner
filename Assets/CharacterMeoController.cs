using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMeoController : MonoBehaviour
{
    [SerializeField]
    protected Rigidbody2D mBody;
    [SerializeField]
    protected Animator mAni;
    public bool isGround;
    protected float speed = 4f;

    public bool isWork = false;
    public bool isRuning = false;
    public bool isGameOver = false;
    public bool isMoveLeft = false;
    public bool isJump = false;
    public bool isMoveRight = false;
    public float spJoy;
    public bool isAttackJoy = false;
    public List<GameObject> skills = new List<GameObject>();
    public int indexSkill;
    public bool isAttack = false;
    [SerializeField]
    protected GameObject tenThan;
    [SerializeField]
    protected GameObject bullet;
    [SerializeField]
    protected GameObject bom;
    [SerializeField]
    protected Transform posTen;
    [SerializeField]
    protected Transform posGun;
    [SerializeField]
    protected Transform posBom;

    public void AttackJoy()
    {
        if (isAttackJoy && !isAttack && indexSkill > 0)
        {
            switch (PlayerData.Instance.indexSkill)
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
    }
    public Transform pointAttack;
    public void FlipTrue()
    {
        for (int i = 0; i < skills.Count; i++)
        {
            skills[i].transform.eulerAngles = new Vector3(0, 0, 0);
        }
        pointAttack.eulerAngles = new Vector3(0, 0, 0);
    }
    public void FlipFalse()
    {
        for (int i = 0; i < skills.Count; i++)
        {
            skills[i].transform.eulerAngles = new Vector3(0, 180, 0);
        }
        pointAttack.eulerAngles = new Vector3(0, 180, 0);
    }
    IEnumerator AttackGan(float timeAt)
    {
        isAttack = true;
        skills[0].SetActive(false);
        skills[indexSkill].SetActive(true);
        yield return new WaitForSeconds(timeAt / 2);
        if (indexSkill != 4)
        {
            CheckAt();
        }
        yield return new WaitForSeconds(timeAt / 2);
        if (PlayerData.Instance.indexSkill == 4)
        {
            GameObject sp = Instantiate(bom, posBom.position, transform.rotation);
            if (PlayerMeoController.Instance.transform.eulerAngles.y == 180f)
            {
                sp.GetComponent<Rigidbody2D>().AddForce(new Vector2(300f, 300f));
            }
            else
            {
                sp.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300f, 300f));
            }

        }
        skills[0].SetActive(true);
        skills[indexSkill].SetActive(false);
        isAttack = false;
    }
    IEnumerator AttackXa(float timeAt, GameObject gun)
    {
        isAttack = true;
        skills[0].SetActive(false);
        skills[indexSkill].SetActive(true);
        float tm = timeAt;
        // SpawnBullet(gun);
        if (PlayerData.Instance.indexSkill == 6)
        {
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
        if (PlayerData.Instance.indexSkill == 5)
        {
            yield return new WaitForSeconds(timeAt);
            SpawnTen(gun);
        }
        skills[0].SetActive(true);
        skills[indexSkill].SetActive(false);
        isAttack = false;

    }
    public void SpawnTen(GameObject gun)
    {
        GameObject sp = Instantiate(gun, posTen.position, transform.rotation);
        // sp.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000f, 0f));
    }
    public void SpawnBullet(GameObject gun)
    {
        GameObject sp = Instantiate(gun, posGun.position, transform.rotation);
        // sp.GetComponent<Rigidbody2D>().AddForce(new Vector2(1500f, 0f));
    }
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public GameObject fx;
    void CheckAt()
    {
        RangeAttack();
    }
    void RangeAttack()
    {
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemys)
        {
            if (enemy.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
            {
                enemy.GetComponent<EnemyNoAttack>().Dead();
                GameObject fx1 = Instantiate(fx, enemy.gameObject.transform.position, enemy.gameObject.transform.rotation);
                Destroy(fx1, 2f);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
