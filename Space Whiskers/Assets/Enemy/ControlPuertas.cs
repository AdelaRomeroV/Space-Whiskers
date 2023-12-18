using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPuertas : MonoBehaviour
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
            case >= 16:
                puertasDeNivel[3].bloqueo = false;
                break;
            case >= 11:
                puertasDeNivel[2].bloqueo = false;
                break;
            case >= 6:
                puertasDeNivel[1].bloqueo = false;
                break;
            case >= 3:
                puertasDeNivel[0].bloqueo = false;
                break;
        }
    }    
}
