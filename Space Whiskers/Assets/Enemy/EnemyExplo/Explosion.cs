using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [Header("Ataque")]
    public float checkRadius;
    public LayerMask whatIsPlayer;

    [Header("Animacion")]
    private Animator animador;
    public GameObject fxExplosion;


    private float timer = 0.5f;

    public ContadorDeEnemigos enemigosMt;

    public bool explotando = false;

    Collider2D miCollider;

    private void Awake()
    {
        miCollider = GetComponent<Collider2D>();
        animador = GetComponent<Animator>();
        enemigosMt = GameObject.FindGameObjectWithTag("Player").GetComponent<ContadorDeEnemigos>();
    }

    private void Update()
    {
        if (detection())
        {
            HandleExplosion();
        }
        else
        {
            timer = 1f;
            animador.SetBool("IsActivar", false);
        }
    }

    private void HandleExplosion()
    {
        animador.SetBool("IsActivar", true);

        if (explotando == false)
        {
            animador.SetBool("Explota", true);
            explotando = true;
            miCollider.isTrigger = true;
            transform.localScale = new Vector3(2f, 2f, 2f);
            Instantiate(fxExplosion, transform.position, transform.rotation);
            enemigosMt.enemigosMuertos++;
        }
    }

    private bool detection()
    {
        return Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }

}
