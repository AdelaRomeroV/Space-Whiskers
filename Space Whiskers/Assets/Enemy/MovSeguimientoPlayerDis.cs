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

    public float detectionRadius; 
    public LayerMask playerLayer;
    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, playerLayer);

        if (colliders.Length > 0)
        {
            if (Vector2.Distance(transform.position, Player.position) > stoppingDistancia)
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
            }

            else if (Vector2.Distance(transform.position, Player.position) < stoppingDistancia && Vector2.Distance(transform.position, Player.position) > retreatDistancie)
            {
                transform.position = this.transform.position;
            }

            else if (Vector2.Distance(transform.position, Player.position) < retreatDistancie)
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.position, -speed * Time.deltaTime); ;
            }
        }
    }
}
