using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{
    public string escenasiguiente;
    public KeyCode teclaparaavanzar = KeyCode.KeypadEnter;

    void Update()
    {
        if (Input.GetKeyDown(teclaparaavanzar))
        {
            CargarEscenaSiguiente();
        }
    }
    public void CargarEscenaSiguiente()
    {
        SceneManager.LoadScene(escenasiguiente);
    }
}
