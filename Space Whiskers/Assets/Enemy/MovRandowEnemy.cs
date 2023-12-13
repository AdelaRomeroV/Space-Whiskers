using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovRandowEnemy : MonoBehaviour
{
    public float speedE;
    public float range; // Lo cerca que debe estar del punto inicial
    public GameObject movementArea; // Objeto tiene el Sprite y el Collider donde se mueve

    private Vector2 wayPoint;
    public Collider2D movSprite; // Collider del área de movimiento

    public EnemyLife vi;

    void Start()
    {
        LimitSprite();
    }

    void Update()
    {
        if (vi.muerto != true)
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPoint, speedE * Time.deltaTime);
            if (Vector2.Distance(transform.position, wayPoint) < range)
            {
                LimitSprite();
            }
        }
    }

    void LimitSprite()
    {
        wayPoint = new Vector2(Random.Range(movSprite.bounds.min.x, movSprite.bounds.max.x), Random.Range(movSprite.bounds.min.y, movSprite.bounds.max.y));
    }

    void OnDrawGizmos()
    {
        if (movementArea != null)
        {
            //UnityEditor.Handles.color = Color.yellow;
            // UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, range);

            Gizmos.color = new Color(1f, 1f, 1f, 0.3f);
            Gizmos.DrawIcon(transform.position, "Limit", true);
        }
    }
}
