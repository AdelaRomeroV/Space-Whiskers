using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeg : MonoBehaviour
{
    private float speed;
    public GameObject player;
    private float distance;

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direccion = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime); 
    }
}
