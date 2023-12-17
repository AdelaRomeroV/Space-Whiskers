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

    private Vector2 giro;
    private Vector2 playerInput;
    bool isgiro;

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
        if (Input.GetMouseButton(0))
        {
            Vector2 direccionDisparo = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position)).normalized;
            if (direccionDisparo.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (direccionDisparo.x > 0)
            {
                spriteRenderer.flipX = false;
            }
        }
        else
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
    }

    void ActualizarAnimacionCaminar(Vector2 direccion)
    {
        estaCaminando = direccion.magnitude > 0.1f;

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        playerInput = new Vector2(moveX, moveY).normalized;

        if ((playerInput != Vector2.zero))
        {
            animador.SetBool("Caminando", true);
        }
        else
        {
            animador.SetBool("Caminando", false);
        }
    }

    void ManejarDanio()
    {
        if (vidaJugador.seQuitoVida == true && vidaJugador.life > 0)
        {
            animador.SetTrigger("RecibeDaño");
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
