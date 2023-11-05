using System.Collections;
using UnityEngine;

public class AreaShooter : MonoBehaviour
{
    public Transform direction, target;
    public GameObject bullet;

    public ShootParameters datos;
    private int orientacion = 1;

    private void Start() { Play(); }
    public void Play() { StartCoroutine(Begin()); }
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
        for (int i = 0; i < datos.proyectilPerBurst; i++)
        {
            Vector3 pos = direction.position + (direction.up * datos.startingDistance);
            Instantiate(bullet, pos, Quaternion.identity).GetComponent<BulletF>().dir = direction.up;

            direction.Rotate(Vector3.back, angle * orientacion);
            if (datos.timeDelay != 0) yield return new WaitForSeconds(datos.timeDelay);
        }
    }
}