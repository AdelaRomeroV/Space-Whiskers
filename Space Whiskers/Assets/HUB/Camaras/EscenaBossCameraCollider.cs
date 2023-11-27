using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;

public class EscenaBossCameraCollider : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera Cam1;
    [SerializeField] CinemachineVirtualCamera Cam2;
    float timer;
    [SerializeField] float maxTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TemblorCamara.Instance.moverCamara(5, 5, 3f);
            Cam1.Priority = 0;
            Cam2.Priority = 100;
            timer = 0;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Cam1.Priority = 100;
            Cam2.Priority = 0;
            timer = 0;

        }
    }
 
}
