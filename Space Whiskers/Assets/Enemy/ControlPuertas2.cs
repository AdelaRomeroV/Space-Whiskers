using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPuertas2 : MonoBehaviour
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
            case >= 12:
                puertasDeNivel[2].bloqueo = false;
                break;
            case >= 8:
                puertasDeNivel[1].bloqueo = false;
                break;
            case >= 5:
                puertasDeNivel[0].bloqueo = false;
                break;
        }
    }
}
