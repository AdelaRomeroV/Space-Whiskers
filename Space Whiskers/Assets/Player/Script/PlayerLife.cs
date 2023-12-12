using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
using Unity.VisualScripting;

public class PlayerLife : MonoBehaviour
{
    [Header("Life")]
    public float life;
    public float energy;
    public float timer;
    private Player player;
    public SpriteRenderer spriteRenderer;
    public bool seQuitoVida = false;

    public bool seCuro = false;

    public bool curo = false;


    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        Regeneracion();
    }

    private void FixedUpdate()
    {
        seQuitoVida = false;
    }
    public void Regeneracion()
    {
        Player jugador = GetComponent<Player>();
        if (energy >= 15 && Input.GetKey(KeyCode.Q) && life < 4 && jugador.bulletType != 1)
        {
            spriteRenderer.color = Color.blue;
            seCuro = true;
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                energy -= 15;
                life += 1f;
                timer = 1.5f;
                spriteRenderer.color = Color.white;
                seCuro = false;
                curo = true;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Q) || (Input.GetKey(KeyCode.Q) && life <= 4))
        {
            spriteRenderer.color = Color.white;
            seCuro = false;
            curo = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            if (collision.gameObject.GetComponent<Damage>() != null) { life -= collision.gameObject.GetComponent<Damage>().damage; }
            Destroy(collision.gameObject);
            seQuitoVida = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.GetComponent<Damage>() != null) { life -= collision.gameObject.GetComponent<Damage>().damage; }
            seQuitoVida = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.CompareTag("Energy"))
        {
            Destroy(collision.gameObject);

            energy += collision.gameObject.GetComponent<Items>().enegyMax;

            if (energy >= 60)
            {
                energy = 60;
            }
        }

        if(collision.gameObject.CompareTag("Pate"))
        {
            Destroy(collision.gameObject);
            life += collision.gameObject.GetComponent<Items>().lifeMax;

            if (life >= 5)
            {
                life = 5;
            }
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.GetComponent<Damage>() != null) { life -= collision.gameObject.GetComponent<Damage>().damage; }
            seQuitoVida = true;
        }
    }

    public void ManejorDeMuerte()
    {
        SceneManager.LoadScene("Game Over");
    }
}
