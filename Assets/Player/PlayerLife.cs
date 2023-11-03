using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.SceneManagement;
using System.Threading;

public class PlayerLife : MonoBehaviour
{
    [Header("Life")]
    public float life;
    public float Energy;
   

    private Player player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    public void Regeneracion()
    {

        if (Energy >= 30 && Input.GetKeyDown(KeyCode.Q) && life < 3)
        {
                Energy -= 15;
                life += 1f;
        }
    }


    
}
