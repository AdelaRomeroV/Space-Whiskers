using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet")]
    private Rigidbody2D rb2D;
    public float speedB;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.Translate(Vector3.up * speedB * Time.deltaTime);
        Destroy(gameObject, 3f);
    }

   
}
