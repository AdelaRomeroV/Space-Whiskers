using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [Header("Ataque")]
    public float chekRaius;
    public float attackRadius;
    private float timer = 0;

    public LayerMask whatisPlayer;
    private PlayerLife player;


    [Header("Pre Animacion")]
    public SpriteRenderer spriteRenderer;
    public float cambioDeColorIntervalo;
    public GameObject fxExplosion;

    private void Awake()
    {
         player = GameObject.FindWithTag("Player").GetComponent<PlayerLife>();
    }

    public void Update()
    {
        Explo();
    }

    public void Explo()
    {
        if(detection() == true)
        {
            timer -= Time.deltaTime;
            StartCoroutine(CambiarColorRepetidamente());
            if (timer <= 0)
            {
                player.life = player.life - GetComponent<Damage>().damage;
                Instantiate(fxExplosion, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
        else
        {
            StopAllCoroutines();
            timer = 1.5f;
            spriteRenderer.material.SetColor("_Color", Color.red);
        }
    }

    private IEnumerator CambiarColorRepetidamente()
    {
        while (true)
        {
            spriteRenderer.material.SetColor("_Color", Color.white);
            yield return new WaitForSeconds(cambioDeColorIntervalo);

            spriteRenderer.material.SetColor("_Color", Color.red);
            yield return new WaitForSeconds(cambioDeColorIntervalo);
        }
    }

    private bool detection()
    {
        return Physics2D.OverlapCircle(transform.position, chekRaius, whatisPlayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chekRaius); 
    }
}
