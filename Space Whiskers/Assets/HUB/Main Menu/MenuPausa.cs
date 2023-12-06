using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    public GameObject botonPausa;
    public GameObject menuPausa;

    public void Pausa()
    {
            Time.timeScale = 0f;
            botonPausa.SetActive(false);
            menuPausa.SetActive(true);
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }
}
