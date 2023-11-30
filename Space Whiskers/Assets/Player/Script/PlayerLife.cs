using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class PlayerLife : MonoBehaviour
{
    [Header("Life")]
    public float life;
    public float energy;
    public float timer;
    private Player player;
    public HealthBar healthBar;
    public SpriteRenderer spriteRenderer;
    public bool seQuitoVida = false;

    public bool seCuro = false;


    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthBar = GetComponentInChildren<HealthBar>();
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

        if (energy >= 15 && Input.GetKey(KeyCode.Q) && life < 3)
        {
            spriteRenderer.color = Color.green;
            seCuro = true;
            if (timer < Time.time)
            {
                energy -= 15;
                life += 1f;
                timer = 1.5f + Time.time;
                if (healthBar != null) { healthBar.UpdateHealthBar(); }
            }
        }
        else if (Input.GetKeyUp(KeyCode.Q) || (Input.GetKey(KeyCode.Q) && life <= 3))
        {
            spriteRenderer.color = Color.white;
            seCuro = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            if (collision.gameObject.GetComponent<Damage>() != null) { life -= collision.gameObject.GetComponent<Damage>().damage; }
            Destroy(collision.gameObject);
            seQuitoVida = true;
            if (healthBar != null) { healthBar.UpdateHealthBar(); }
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.GetComponent<Damage>() != null) { life -= collision.gameObject.GetComponent<Damage>().damage; }
            seQuitoVida = true;
            if (healthBar != null) { healthBar.UpdateHealthBar(); }
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
            if (healthBar != null) { healthBar.UpdateHealthBar(); }

            if (life >= 5)
            {
                life = 5;
            }
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.GetComponent<Damage>() != null) { life -= collision.gameObject.GetComponent<Damage>().damage; }
            seQuitoVida = true;
            if (healthBar != null) { healthBar.UpdateHealthBar(); }
        }
    }

    public void ManejorDeMuerte()
    {
        SceneManager.LoadScene(6);
    }
}
