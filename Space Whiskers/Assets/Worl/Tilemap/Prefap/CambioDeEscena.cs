using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{
    public string escena;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            int nivelActual = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(escena);
        }
    }
}
