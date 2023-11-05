using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AtaqCircular : MonoBehaviour
{
    public Transform direction, target;
    public GameObject bullet;
    public ShootParameters datos;
    private int orientacion = 1;

    public float speed;

    public LayerMask whatisPlayer;
    public float chekRaius;

    public bool isPlayerInRange = false;
    public float updateInterval = 1f;
    public float cooldown = 2f; // Tiempo de enfriamiento
    public float tiempoDisparo = 6f; // Duración del disparo

    private bool isShooting = false;

    private void Start()
    {
        InvokeRepeating("PersonalizedUpdate", 0f, updateInterval);
    }
    private void Update()
    {

    }

    private void PersonalizedUpdate()
    {
        isPlayerInRange = detection();

        if (cooldown > 0f)
        {
            if (isPlayerInRange && !isShooting)
            {
                StartCoroutine(ShootAndCooldown());
            }
            else
            {
                Stop();
            }
        }
    }

    private bool detection()
    {
        return Physics2D.OverlapCircle(transform.position, chekRaius, whatisPlayer);
    }

    private IEnumerator ShootAndCooldown()
    {
        while (true)
        {
            if (!isShooting)
            {
                isShooting = true;
                yield return StartCoroutine(Begin());
                isShooting = false;

                tiempoDisparo -= 1f;

                yield return new WaitForSeconds(cooldown);
                tiempoDisparo = 6f;
            }

            yield return null;
        }
    }

    public void Stop()
    {
        StopAllCoroutines();
        isShooting = false;
    }

    private IEnumerator Begin()
    {
        tiempoDisparo -= 1f;
        if(tiempoDisparo > 0f)
        {
            direction.up = datos.focusTarget ? target.position - direction.position : Vector3.up;

            float angle = datos.burstAngle / datos.proyectilPerBurst;
            direction.Rotate(Vector3.forward, orientacion * angle);

            yield return StartCoroutine(Shoot(angle));
            yield return new WaitForSeconds(datos.timeBetweenBurst);
        }
    }

    private IEnumerator Shoot(float angle)
    {
        for (int i = 0; i < datos.proyectilPerBurst; i++)
        {
            Vector3 pos = direction.position + (direction.up * datos.startingDistance);
            Instantiate(bullet, pos, Quaternion.identity).GetComponent<BulletF>().dir = direction.up * speed;

            direction.Rotate(Vector3.back, angle * orientacion);
            if (datos.timeDelay != 0) yield return new WaitForSeconds(datos.timeDelay);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chekRaius);
    }
}
