using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDis : MonoBehaviour
{
    private float timeBtwShots;
    public float startTimeBtwShots;

    public LayerMask whatisPlayer;
    public float chekRaius;

    public GameObject BulletEnemy;
    private Transform player;

    public float cooldown = 0f;
    public float cooldownTime = 0f;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        DetectionPlayer();
        detection();

    }
    void DetectionPlayer ()
    {
        if (player != null)
        {

            if (detection() == true) 
            {
                StartCoroutine(Shoot());
            }
            else
            {
                cooldownTime = 0.5f;
                timeBtwShots = startTimeBtwShots;
            }
        }
    }
    private IEnumerator Shoot()
    {
        if (timeBtwShots <= 0 && cooldownTime <= 0)
        {
            Instantiate(BulletEnemy, transform.position, transform.rotation);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            cooldownTime -= Time.deltaTime;
            timeBtwShots -= Time.deltaTime;
        }
        if (cooldownTime <= 0)
        {
            yield return new WaitForSeconds(cooldown);
            cooldownTime = 0.5f;
        }
    }

    private bool detection()
    {
        return Physics2D.OverlapCircle(transform.position, chekRaius, whatisPlayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chekRaius);
    }
}
