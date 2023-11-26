using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    GameObject target;
    [SerializeField] float speed;
    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 movDir = (target.transform.position - transform.position).normalized * speed;
        rb2d.velocity = new Vector2 (movDir.x, movDir.y);
        Destroy(this.gameObject, 5f);
    }
}
