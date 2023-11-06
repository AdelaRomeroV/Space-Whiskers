using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.SceneManagement;
using System.Threading;

public class PlayerLife : MonoBehaviour
{
    [Header("Life")]
    public float life;
    public float energy;
    public float timer;
    private Player player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    private void Update()
    {
        Regeneracion();
    }
    public void Regeneracion()
    {

        if (energy >= 30 && Input.GetKey(KeyCode.Q) && life < 3)
        {
            if (timer < Time.time)
            {
                energy -= 15;
                life += 1f;
                timer = 1.5f + Time.time;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            if (collision.gameObject.CompareTag("Enemy"))
            {
                life -= collision.gameObject.GetComponent<Damage>().damage;

                if (life <= 0)
                {
                    //Destroy(gameObject);
                    //GetComponent<UI_Escena>();
                    //SceneManager.LoadScene(6);
                }
            }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            life -= collision.gameObject.GetComponent<Damage>().damage;

            if (life <= 0)
            {
                //Destroy(gameObject);
                //GetComponent<UI_Escena>();
                //SceneManager.LoadScene(6);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.CompareTag("Energy"))
        {
            Destroy(collision.gameObject);

            energy += collision.gameObject.GetComponent<Items>().enegyMax;

            if (energy >= 30)
            {
                energy = 30;
            }

        }
    }
}
