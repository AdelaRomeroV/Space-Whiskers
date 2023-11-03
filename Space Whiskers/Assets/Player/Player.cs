using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movimiento")]
    private Rigidbody2D rb2D;
    private Vector2 playerInput;
    public float movSpeed;

    [Header("Dash")]
    public float dashSpeed;
    public float dashDuration;
    public float dashCoolDown;
    private bool isDah;
    private bool canDash;

    [Header("Weapon")]
    public Transform weapon;
    private float offset = 90f;

    [Header("Disparo")]
    public Transform shotPoint;
    public GameObject[] bullet;
    public float timerShots;
    private float nextShoop;
    private int bulletType;
    public float segundos;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        canDash = true;
    }
    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + playerInput * movSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        Mov();
        Rot();
        Shooting();
        activarDash();
        UltiShooting();
    }
    
    void Mov()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        playerInput = new Vector2(moveX, moveY).normalized;
    }

    void Rot()
    {
        Vector3 displacement = weapon.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float playerInput = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        weapon.rotation = Quaternion.Euler(0f, 0f, playerInput + offset);
    }

    void Shooting()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time > nextShoop)
            {
                nextShoop = Time.time + timerShots;
                Instantiate(bullet[bulletType], shotPoint.position, shotPoint.rotation);
            }
        }

    }

    void UltiShooting()
    {
        PlayerLife life = GetComponent<PlayerLife>();
        if (bulletType == 0 && life.Energy >= 30 && Input.GetKeyDown(KeyCode.E))
        {
            bulletType = 1;
            StartCoroutine(State(life));

            if (Time.time > nextShoop)
            {
                nextShoop = Time.time + timerShots;
            }
        }
    }
    private IEnumerator State(PlayerLife life)
    {
        yield return new WaitForSeconds(2);
        life.Energy -= 5;
        life.Energy = Mathf.Clamp(life.Energy, 0, int.MaxValue);
        if (life.Energy > 0)
        {
            StartCoroutine(State(life));
        }
        else
        {
            bulletType = 0;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDah = true;
        playerInput = new Vector2(playerInput.x * dashSpeed, playerInput.y * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDah = false;
        yield return new WaitForSeconds(dashCoolDown);
        canDash = true;
    }
   
    void activarDash()
    {
        if (isDah)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

}
