using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeg : MonoBehaviour
{
    public float speed;
    public Transform player;
    private float distance;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direccion = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime); 
    }
}
