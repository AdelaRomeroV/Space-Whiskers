using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float life;
    public GameObject prefab;
    public ContadorDeEnemigos enemigosMt;

    private void Awake()
    {
        enemigosMt = GameObject.FindGameObjectWithTag("Player").GetComponent<ContadorDeEnemigos>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            life -= collision.gameObject.GetComponent<DamagePlayer>().damageplayer;
            Destroy(collision.gameObject);

            if (life <= 0)
            {
                if (prefab != null) { Instantiate(prefab, transform.position, Quaternion.identity); }
                Destroy(gameObject);
                enemigosMt.enemigosMuertos++;
            }
        }
    }
}
