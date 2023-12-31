using UnityEngine;

public class Rot : MonoBehaviour
{
    public Transform weapon;
    private Transform player;

    public LayerMask whatisPlayer;
    public float chekRaius;

    public float offet = 90f;

    private EnemyLife vi;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        vi = GetComponent<EnemyLife>();
    }
    private void Update()
    {
        if(detection() == true && !vi.muerto)
        {
            Rotate();
        }
        if(vi.muerto)
        {
            weapon.gameObject.SetActive(false);
        }
    }

    void Rotate()
    {
        Vector3 displacement = player.transform.position - weapon.position;
        float playerInput = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        weapon.rotation = Quaternion.Euler(0f, 0f, playerInput + offet);
        if (displacement.x < 0)
        {
            weapon.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
        }
        else
        {
            weapon.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
    }
    private bool detection()
    {
        return Physics2D.OverlapCircle(transform.position, chekRaius, whatisPlayer);
    }
}
