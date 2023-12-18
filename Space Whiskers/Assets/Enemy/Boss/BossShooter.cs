using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooter : MonoBehaviour
{
    public Transform direction, target;
    public GameObject bullet;

    public GameObject bullet1;

    public ShootParameters datos;
    private int orientacion = 1;

    public bool disparoRebote;
    public Transform shootPosition1;
    public Transform shootPosition2;

    public void Play()
    { 
        StartCoroutine(Begin());
    }
    public void Stop() { StopAllCoroutines(); }

    private IEnumerator Begin()
    {
        if (target != null)
        {
            direction.up = datos.focusTarget ? target.position - direction.position : Vector3.up;

            float angle = datos.burstAngle / datos.proyectilPerBurst;
            direction.Rotate(Vector3.forward, orientacion * angle * 5);

            yield return StartCoroutine(Shoot(angle));
            yield return new WaitForSeconds(datos.timeBetweenBurst);

            orientacion = orientacion > 0 ? -1 : 1;
            StartCoroutine(Begin());
        }
    }
    private IEnumerator Shoot(float angle)
    {
        if (disparoRebote)
        {
            Instantiate(bullet1, shootPosition1.position, Quaternion.identity);
            Instantiate(bullet1, shootPosition2.position, Quaternion.identity).GetComponent<BalaRebota>().direccion = Vector2.right + Vector2.down;


            if (datos.timeDelay != 0) yield return new WaitForSeconds(datos.timeDelay);
        }
        else 
        {
            for (int i = 0; i < datos.proyectilPerBurst; i++)
            {
                Vector3 pos = direction.position + (direction.up * datos.startingDistance);
                Instantiate(bullet, pos, Quaternion.identity).GetComponent<BulletF>().dir = direction.up;

                direction.Rotate(Vector3.back, angle * orientacion);
                if (datos.timeDelay != 0) yield return new WaitForSeconds(datos.timeDelay);
            }
        }
    }
}
