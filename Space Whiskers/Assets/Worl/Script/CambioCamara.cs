using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioCamara : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] CinemachineVirtualCamera Cam1;
    [SerializeField] CinemachineVirtualCamera Cam2;
    float timer;
    [SerializeField] float maxTime;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;
        //if (timer > maxTime)
        //{
        //    Cam1.Priority = 100;
        //    Cam2.Priority = 0;
        //}

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Cam1.Priority = 0;
            Cam2.Priority = 100;
            timer = 0;
            //gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Cam1.Priority = 100;
            Cam2.Priority = 0;
            timer = 0;
            //gameObject.SetActive(false);
        }
    }
}
