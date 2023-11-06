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
    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
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
