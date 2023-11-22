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
    public bool seQuitoVida = false;


    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
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

        if (energy >= 15 && Input.GetKey(KeyCode.Q) && life < 4)
        {
            if (timer < Time.time)
            {
                energy -= 15;
                life += 1f;
                timer = 1.5f + Time.time;
                if (healthBar != null) { healthBar.UpdateHealthBar(); }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            life -= collision.gameObject.GetComponent<Damage>().damage;
            seQuitoVida = true;
            if (healthBar != null) { healthBar.UpdateHealthBar(); }
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            life -= collision.gameObject.GetComponent<Damage>().damage;
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
            life -= collision.gameObject.GetComponent<Damage>().damage;
            seQuitoVida = true;
            if (healthBar != null) { healthBar.UpdateHealthBar(); }
        }
    }

    public void ManejorDeMuerte()
    {
        SceneManager.LoadScene(5);
    }
}
