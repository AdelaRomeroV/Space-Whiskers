using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public GameObject puerta;
    public bool bloqueo = true;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E) && !bloqueo)
            {
                Animator puertaAnimator = GetComponent<Animator>();
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
