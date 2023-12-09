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
                Destroy(puerta.gameObject);
            }
        }
    }
}
