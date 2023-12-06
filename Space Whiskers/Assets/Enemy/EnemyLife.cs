using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float life;
    public GameObject prefab;
    public ContadorDeEnemigos enemigosMt;

    private SpriteRenderer spriteRenderer;

    private Animator animador;
    private Explosion d;
    private bool muerto = false;
    private MovSeguimientoPlayerDis mov;

    private void Awake()
    {
        enemigosMt = GameObject.FindGameObjectWithTag("Player").GetComponent<ContadorDeEnemigos>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animador = GetComponent<Animator>();
        d = GetComponent<Explosion>();
        mov = GetComponent<MovSeguimientoPlayerDis>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {          
            if (life <= 0 && !muerto)
            {
                if (prefab != null) { Instantiate(prefab, transform.position, Quaternion.identity); }
                if (animador != null && d == null) { animador.SetTrigger("Muerto"); }
                else if (d != null || animador == null) { Muerto(); }
                muerto = true;
                enemigosMt.enemigosMuertos++;
            }
            else if (life >= 1) 
            {
                life -= collision.gameObject.GetComponent<DamagePlayer>().damageplayer;
                mov.isAlert = true;
                if (animador != null && d == null) { animador.SetTrigger("RecibeDaño"); }
                StartCoroutine(CambiarColorTemporalmente(0.1f));
                Destroy(collision.gameObject);
            }
        }
    }

    private IEnumerator CambiarColorTemporalmente(float duracion)
    {
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(duracion);

        spriteRenderer.color = Color.white;
    }

    public void Muerto()
    {
        Destroy(gameObject);
    }
}
