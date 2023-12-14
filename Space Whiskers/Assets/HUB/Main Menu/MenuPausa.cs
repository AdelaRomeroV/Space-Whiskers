using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject botonPausa;
    public GameObject menuPausa;

    public bool pausa;
    int sceneNum;
    private void Start()
    {
        sceneNum = SceneManager.sceneCount;
    }

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

    public void ResetLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneNum);
    }


}
