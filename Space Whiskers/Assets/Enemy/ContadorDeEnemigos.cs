using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorDeEnemigos : MonoBehaviour
{
    public int enemigosMuertos;

    public int enemigosMin;

    public GameObject puerta;
    public GameObject sueloZonaB;

    private void Update()
    {
        if(enemigosMuertos >= enemigosMin)
        {
            if(puerta != null)
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
