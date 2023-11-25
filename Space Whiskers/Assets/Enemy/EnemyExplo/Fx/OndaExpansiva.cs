using UnityEngine;

public class OndaExpansiva : MonoBehaviour
{
    public float velocidadCrecimiento = 5f;
    public float duracionExplosion = 1f;

    private float tiempoInicioExplosion;

    void Start()
    {
        tiempoInicioExplosion = Time.time;
    }

    void Update()
    {
        float tiempoTranscurrido = Time.time - tiempoInicioExplosion;
        float tama�oActual = tiempoTranscurrido * velocidadCrecimiento;

        transform.localScale = new Vector3(tama�oActual, tama�oActual, 1f);

        if (tiempoTranscurrido >= duracionExplosion)
        {
            Destroy(gameObject);
        }
    }
}
