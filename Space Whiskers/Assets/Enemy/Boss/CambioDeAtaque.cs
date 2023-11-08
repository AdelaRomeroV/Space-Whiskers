using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDeAtaque : MonoBehaviour
{
    public ShootParameters[] parametros;
    public BossShooter metodos;

    public int numeroDeAtaque = 0;

    private void Start()
    {
        StartCoroutine(Ataques());
        metodos.Play();
    }
    public IEnumerator Ataques()
    {
        numeroDeAtaque = Random.Range(0, 2);
        switch (numeroDeAtaque)
        { 
            case 0:
                metodos.datos =parametros[0];
                yield return new WaitForSeconds(10f);
                break;
            case 1:
                metodos.datos =parametros[1];
                yield return new WaitForSeconds(2f);
                metodos.datos = parametros[2];
                yield return new WaitForSeconds(2f);
                metodos.datos = parametros[1];
                yield return new WaitForSeconds(2f);
                break;
            default:
                break;
        }
        yield return new WaitForSeconds(1f);

        StartCoroutine(Ataques());
    }
}
