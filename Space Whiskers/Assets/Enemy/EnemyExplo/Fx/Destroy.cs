using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float time = 0.25f;
    void Update()
    {
        Destroy(gameObject, time);
    }
}
