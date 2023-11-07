using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBoton : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(2);
        Debug.Log("funciona");
    }

    public void Salir()
    {
        Debug.Log("Salir");
    }

}
