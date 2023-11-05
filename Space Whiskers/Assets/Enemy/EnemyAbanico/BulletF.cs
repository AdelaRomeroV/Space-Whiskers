using UnityEngine;

public class BulletF : MonoBehaviour
{
    public Vector2 dir;
    public float speed;

    private void Start()
    {
        Destroy(gameObject, 5);
    }
    private void Update()
    {
        transform.Translate(dir * Time.deltaTime * speed);
    }
}