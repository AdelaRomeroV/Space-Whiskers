using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animador;
    private SpriteRenderer spriteRenderer;
    private bool estaCaminando = false;

    private PlayerLife vidaJugador;

    public GameObject prefabArma;
    private bool inicioDeAnimacionMuerte = false;

    void Start()
    {
        animador = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        vidaJugador = GetComponent<PlayerLife>();
    }

    void Update()
    {
        ManejarMovimiento();
        ManejarDanio();
        ManejarMuerte();
    }

    void ManejarMovimiento()
    {
        Vector2 direccion = ObtenerDireccion();
        ActualizarEscalaSprite(direccion);
        ActualizarAnimacionCaminar(direccion);
    }

    Vector2 ObtenerDireccion()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
    }

    void ActualizarEscalaSprite(Vector2 direccion)
    {
        if (direccion.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (direccion.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    void ActualizarAnimacionCaminar(Vector2 direccion)
    {
        estaCaminando = direccion.magnitude > 0.1f;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            animador.SetBool("Caminando", true);
        }
        else
        {
            animador.SetBool("Caminando", false);
        }
        animador.SetFloat("Velocidad", direccion.magnitude);
    }

    void ManejarDanio()
    {
        if (vidaJugador.seQuitoVida == true && vidaJugador.life > 0)
        {
            animador.SetTrigger("RecibirDanio");
            StartCoroutine(CambiarColorTemporalmente(Color.red, 0.1f));
        }
    }

    private IEnumerator CambiarColorTemporalmente(Color colorNuevo, float duracion)
    {
        spriteRenderer.color = colorNuevo;

        yield return new WaitForSeconds(duracion);

        spriteRenderer.color = Color.white;
    }

    void ManejarMuerte()
    {
        if (vidaJugador.life <= 0 && inicioDeAnimacionMuerte == false)
        {
            inicioDeAnimacionMuerte = true;
            prefabArma.SetActive(false);
            animador.SetBool("EstaVivo", false);
            animador.SetTrigger("Morir");
        }
    }
}
