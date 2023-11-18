using UnityEngine;

public class OndaExpansiva : MonoBehaviour
{
    public float velocidadCrecimiento = 2f;
    public float duracionExplosion = 2f;

    private float tiempoInicioExplosion;

    void Start()
    {
        tiempoInicioExplosion = Time.time;
    }

    void Update()
    {
        float tiempoTranscurrido = Time.time - tiempoInicioExplosion;
        float tamañoActual = tiempoTranscurrido * velocidadCrecimiento;

        transform.localScale = new Vector3(tamañoActual, tamañoActual, 1f);

        if (tiempoTranscurrido >= duracionExplosion)
        {
            Destroy(gameObject);
        }
    }
}
