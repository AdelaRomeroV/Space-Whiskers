using System.Collections;
using UnityEngine;

public class CambioDeAtaque : MonoBehaviour
{
    public ShootParameters[] parametros;
    public BossShooter metodos;

    public int numeroDeAtaque = 0;

    private EscenaBossCameraCollider camaras;

    private Animator animator;

    public bool isPrueba;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(Ataques());
        metodos.Play();
        Animation();
    }

    public void Animation()
    {
        
    }

    public IEnumerator Ataques()
    {
        numeroDeAtaque = Random.Range(0, parametros.Length);
        switch (numeroDeAtaque)
        { 
            case 0:
                if(isPrueba == false)
                {
                    if (camaras.camera2 == true)
                    {
                        metodos.datos = parametros[1];
                        yield return new WaitForSeconds(2f);
                        metodos.datos = parametros[0];
                        yield return new WaitForSeconds(5f);
                        metodos.datos = parametros[1];
                        yield return new WaitForSeconds(2f);
                    }
                    metodos.datos = parametros[4];
                }
                else
                {
                    metodos.datos = parametros[1];
                    yield return new WaitForSeconds(2f);
                    metodos.datos = parametros[0];
                    yield return new WaitForSeconds(5f);
                    metodos.datos = parametros[1];
                    yield return new WaitForSeconds(2f);
                }
                break;
            case 1:
                if (isPrueba == false)
                {
                    if (camaras.camera2 == true)
                    {
                        metodos.datos = parametros[1];
                        yield return new WaitForSeconds(2f);
                        metodos.datos = parametros[2];
                        yield return new WaitForSeconds(2f);
                        metodos.datos = parametros[1];
                        yield return new WaitForSeconds(2f);
                    }
                    metodos.datos = parametros[4];
                }
                else
                {
                    metodos.datos = parametros[1];
                    yield return new WaitForSeconds(2f);
                    metodos.datos = parametros[2];
                    yield return new WaitForSeconds(2f);
                    metodos.datos = parametros[1];
                    yield return new WaitForSeconds(2f);
                }
                break;
            case 2:
                if (isPrueba == false)
                {
                    if (camaras.camera2 == true)
                    {
                        metodos.datos = parametros[3];
                        yield return new WaitForSeconds(2f);
                    }
                    metodos.datos = parametros[4];
                }
                else
                {
                    metodos.datos = parametros[3];
                    yield return new WaitForSeconds(2f);
                }
                break;
            default:
                break;
        }
        yield return new WaitForSeconds(1f);

        StartCoroutine(Ataques());
    }
}
