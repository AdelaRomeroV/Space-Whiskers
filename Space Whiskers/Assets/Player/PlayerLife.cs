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
    public float timer;
   

    private Player player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    private void Update()
    {
        Regeneracion();
    }
    public void Regeneracion()
    {

        if (Energy >= 30 && Input.GetKey(KeyCode.Q) && life <= 3)
        {
            if (timer < Time.time)
            {
                Energy -= 15;
                life += 1f;
                timer = 1.5f + Time.time;
            }
        }
    }


}
