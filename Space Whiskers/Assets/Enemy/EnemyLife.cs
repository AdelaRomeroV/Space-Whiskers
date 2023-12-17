using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyLife : MonoBehaviour
{
    public float life;
    public GameObject prefab;
    public ContadorDeEnemigos enemigosMt;

    private SpriteRenderer spriteRenderer;

    private Animator animador;
    private Explosion d;
    public bool muerto = false;
    private MovSeguimientoPlayerDis mov;

    public bool isBoss = false;

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
                if (mov != null) { mov.isAlert = true; }
                if (animador != null && d == null) { animador.SetTrigger("RecibeDaño"); }
                if (isBoss && life <= 50) { animador.SetBool("DemasiadoDaño", true); }
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
        muerto = true;
        Destroy(gameObject);
        if (isBoss == true)
        {
            SceneManager.LoadScene(5);
        }
    }
}
