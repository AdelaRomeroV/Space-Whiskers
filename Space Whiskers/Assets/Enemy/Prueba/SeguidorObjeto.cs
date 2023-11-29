using UnityEngine;

public class SeguidorObjeto : MonoBehaviour
{
    public Transform personaje;
    public float velocidad = 5f;
    public float distanciaUmbral = 0.1f;

    private void Awake()
    {
        personaje = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (personaje != null)
        {
            Vector3 direccion = personaje.position - transform.position;
            direccion.y = 0;
            direccion.Normalize();

            if (Mathf.Abs(transform.position.x - personaje.position.x) < distanciaUmbral)
            {
                transform.position = new Vector3(personaje.position.x, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position += direccion * velocidad * Time.deltaTime;
            }
        }
    }

}

