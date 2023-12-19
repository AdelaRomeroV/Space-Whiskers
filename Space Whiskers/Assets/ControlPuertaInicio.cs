using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPuertaInicio : MonoBehaviour
{
    private ContadorDeEnemigos enemy;

    public Puerta[] puertasDeNivel;

    void Awake()
    {
        enemy = GameObject.FindGameObjectWithTag("Player").GetComponent<ContadorDeEnemigos>();
    }
    private void Update()
    {
        AbrirPuertas();
    }

    void AbrirPuertas()
    {
        switch (enemy.enemigosMuertos)
        {
            case >=0:
                puertasDeNivel[0].bloqueo = false;
                break;

        }
    }
}
