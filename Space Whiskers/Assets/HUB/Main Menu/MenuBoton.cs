using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBoton : MonoBehaviour
{
    public void NextScena(string scene)
    {
        SceneManager.LoadScene(scene); 
    }

}
