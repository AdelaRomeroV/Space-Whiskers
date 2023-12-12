using System.Collections;
using UnityEngine;

public class CambioDeAtaque : MonoBehaviour
{
    public ShootParameters[] parametros;
    public BossShooter metodos;

    public int numeroDeAtaque = 0;

    private EscenaBossCameraCollider camaras;

    private Animator animator;

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
                if(camaras != null)
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
                }
                metodos.datos = parametros[4];
                break;
            case 1:
                if (camaras != null)
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
                }
                metodos.datos = parametros[4];
                break;
            case 2:
                if (camaras != null)
                {
                    if (camaras.camera2 == true)
                    {
                        metodos.datos = parametros[3];
                        yield return new WaitForSeconds(2f);
                    }
                }
                metodos.datos = parametros[4];
                break;
            default:
                break;
        }
        yield return new WaitForSeconds(1f);

        StartCoroutine(Ataques());
    }
}
