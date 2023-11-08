using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float life;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            life -= collision.gameObject.GetComponent<DamagePlayer>().damageplayer;
            Destroy(collision.gameObject);

            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
