using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public GameObject puerta;
    public GameObject sueloZonaB;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(Input.GetKey(KeyCode.Return))
            {
                sueloZonaB.layer = LayerMask.NameToLayer("Suelo");

                Animator puertaAnimator = puerta.GetComponent<Animator>();
                if (puertaAnimator != null)
                {
                    puertaAnimator.SetBool("Abriendo", true);
                }

                Collider2D puertaCollider = puerta.GetComponent<Collider2D>();

                if (puertaCollider != null)
                {
                    puertaCollider.isTrigger = true;
                }
            }
        }
        
    }
}
