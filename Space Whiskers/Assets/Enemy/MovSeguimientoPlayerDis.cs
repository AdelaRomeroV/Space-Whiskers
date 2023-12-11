using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovSeguimientoPlayerDis : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed;
    public float stoppingDistancia;
    public float retreatDistancie;

    private Transform Player;
    private Vector2 lastPosition;

    public float detectionRadius; 
    public LayerMask playerLayer;

    public Animator animador;
    private SpriteRenderer spriteRenderer;

    public bool isAlert = false;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animador = GetComponent<Animator>();
    }

    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, playerLayer);

        if (colliders.Length > 0 || isAlert == true)
        {
            lastPosition = transform.position;

            if (Vector2.Distance(transform.position, Player.position) > stoppingDistancia)
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
                if(animador!= null)
                {
                    animador.SetBool("IsCaminar", true);
                    Flip();
                }
            }

            else if (Vector2.Distance(transform.position, Player.position) < stoppingDistancia && Vector2.Distance(transform.position, Player.position) > retreatDistancie)
            {
                transform.position = this.transform.position;
                if (animador != null)
                {
                    isAlert = false;
                    animador.SetBool("IsCaminar", false);
                }
            }

            else if (Vector2.Distance(transform.position, Player.position) < retreatDistancie)
            {
                if (animador != null)
                {
                    animador.SetBool("IsCaminar", true);
                    Flip();
                }
                transform.position = Vector2.MoveTowards(transform.position, Player.position, -speed * Time.deltaTime); ;
            }
        }
        else
        {
            if (animador != null)
            {
                animador.SetBool("IsCaminar", false);
            }
        }
    }

    private void Flip()
    {
        if (transform.position.x > lastPosition.x)
        {
            spriteRenderer.flipX = false;
        }
        else if (transform.position.x < lastPosition.x)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
