using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorDeEnemigos : MonoBehaviour
{
    public int enemigosMuertos;

    public GameObject puerta; 

    private void Update()
    {
        if(enemigosMuertos >= 5)
        {
            if(puerta != null)
            {
                Destroy(puerta.gameObject);
            }
        }
    }
}
