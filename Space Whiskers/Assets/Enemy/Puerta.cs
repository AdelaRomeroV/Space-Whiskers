using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public GameObject puerta;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("EstoyDentro");
            if(Input.GetKeyDown(KeyCode.E))
            {
                Animator puertaAnimator = GetComponent<Animator>();
                if (puertaAnimator != null)
                {
                    Debug.Log("Abriendo");
                    puertaAnimator.SetBool("Abriendo", true);
                }

                Collider2D puertaCollider = puerta.GetComponent<Collider2D>();

                if (puertaCollider != null)
                {
                    Debug.Log("Col");
                    puertaCollider.isTrigger = true;
                }
            }
        }
        
    }
}
