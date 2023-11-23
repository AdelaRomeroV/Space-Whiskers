using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorDeEnemigos : MonoBehaviour
{
    public int enemigosMuertos;

    private void Update()
    {
        if(enemigosMuertos >= 5)
        {
            Debug.Log("Abierto");
        }
    }
}
