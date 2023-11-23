using UnityEngine;

public class BalaRebota : MonoBehaviour
{
    public Rigidbody2D rgb;
    public Vector2 direccion;

    private void Awake() => direccion = -Vector2.one;

    private void FixedUpdate() => rgb.velocity = direccion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.GetContact(0).normal;
        Vector2 dir = Vector2.Reflect(direccion, normal);
        direccion = dir;
    }
}
