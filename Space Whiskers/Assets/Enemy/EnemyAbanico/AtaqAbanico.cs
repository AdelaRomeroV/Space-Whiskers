using System.Collections;
using UnityEngine;

public class AtaqAbanico : MonoBehaviour
{
    public Transform direction, target;
    public GameObject bullet;

    public ShootParameters datos;
    private int orientacion = 1;

    public LayerMask whatisPlayer;
    public float chekRaius;

    private bool isPlayerInRange = false;
    private float updateInterval = 1f;

    private void Awake()
    {
        target = GameObject.FindWithTag("Player").transform;
    }
    private void Start()
    {
        InvokeRepeating("PersonalizedUpdate", 0f, updateInterval);
    }

    private void PersonalizedUpdate()
    {
        isPlayerInRange = detectionAtaq();
    }

    private bool detectionAtaq()
    {
        isPlayerInRange = Physics2D.OverlapCircle(transform.position, chekRaius, whatisPlayer);
        if (isPlayerInRange)
        {
            Play();
        }
        else
        {
            Stop();
        }
        return isPlayerInRange;
    }

    public void Play() { StartCoroutine(Begin()); }
    public void Stop() { StopAllCoroutines(); }

    private IEnumerator Begin()
    {
        //resetea la direccion
        direction.up = datos.focusTarget && direction != null && target != null ? target.position - direction.position : Vector3.up;

        //centra las rafagas de disparo
        float angle = datos.burstAngle / datos.proyectilPerBurst;
        direction.Rotate(Vector3.forward, orientacion * angle);

        yield return StartCoroutine(Shoot(angle));
        yield return new WaitForSeconds(datos.timeBetweenBurst);
    }
    private IEnumerator Shoot(float angle)
    {
        direction.up = target.position - transform.position;
        //spawnea todas las balas en un angulo
        for (int i = 0; i < datos.proyectilPerBurst; i++)
        {
            Vector3 pos = direction.position + (direction.up * datos.startingDistance);
            Instantiate(bullet, pos, Quaternion.identity).GetComponent<BulletF>().dir = direction.up;

            //rota el objeto un poco cada instancia
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