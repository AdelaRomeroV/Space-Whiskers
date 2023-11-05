using UnityEngine;

public class Rot : MonoBehaviour
{
    public Transform weapon;
    private Transform player;

    public LayerMask whatisPlayer;
    public float chekRaius;

    public float offet = 90f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if(detection() == true)
        {
            Rotate();
        }
    }

    void Rotate()
    {
        Vector3 displacement = player.transform.position - weapon.position;
        float playerInput = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        weapon.rotation = Quaternion.Euler(0f, 0f, playerInput + offet);
    }
    private bool detection()
    {
        return Physics2D.OverlapCircle(transform.position, chekRaius, whatisPlayer);
    }
}
