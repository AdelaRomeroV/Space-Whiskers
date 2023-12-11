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
    public MovSeguimientoPlayerDis mov;

    public bool explotando = false;

    private EnemyLife vi;

    Collider2D miCollider;

    private void Awake()
    {
        miCollider = GetComponent<Collider2D>();
        animador = GetComponent<Animator>();
        enemigosMt = GameObject.FindGameObjectWithTag("Player").GetComponent<ContadorDeEnemigos>();
        mov = GetComponent<MovSeguimientoPlayerDis>();
        vi = GetComponent<EnemyLife>();
    }

    private void Update()
    {
        if (detection() || vi.life <= 0)
        {
            HandleExplosion();
        }
    }

    private void HandleExplosion()
    {
        if (explotando == false)
        {
            animador.SetTrigger("Explota");
            explotando = true;
            mov. speed = 0;
            miCollider.isTrigger = true;
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

    public void Bomba()
    {
        Instantiate(fxExplosion, transform.position, transform.rotation);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

}
