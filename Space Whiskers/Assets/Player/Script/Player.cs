using System.Collections;
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
    public float ignoreCollisionDuration = 5f;
    private float ignoreCollisionTimer = 0f;

    [Header("Weapon")]
    public Transform weapon;
    private float offset = 180f;

    [Header("Disparo")]
    public Transform shotPoint;
    public GameObject[] bullet;
    public float timerShots;
    private float nextShoop;
    private int bulletType;
    public float segundos;

    [Header("Metralleta")]
    private float dispersionMax = 20f;
    private int balas = 30;
    private float recuperacion = 10f;
    private bool metra = false;

    private PlayerLife vidaJugador;

    void Awake()
    {
        vidaJugador = GetComponent<PlayerLife>();
        rb2D = GetComponent<Rigidbody2D>();
        canDash = true;
    }
    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + playerInput * movSpeed * Time.deltaTime);
    }

    void Update()
    {
        if(vidaJugador.life > 0)
        {
            Mov();
            Rot();
            Shooting();
            Metralleta();
            activarDash();
            UltiShooting();
            Timer();
        }
    }

    void Timer()
    {
        if (ignoreCollisionTimer > 0)
        {
            ignoreCollisionTimer -= Time.deltaTime;
            if (ignoreCollisionTimer <= 0)
            {
                Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("BulletEnemy"), false);
            }
        }
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
                if (metra == true && balas >= 1 && bulletType != 1)
                {
                    Balas();
                }
                else
                {
                    nextShoop = Time.time + timerShots;
                    Instantiate(bullet[bulletType], shotPoint.position, shotPoint.rotation);
                }
            }
        }

    }

    void Balas()
    {
        float dispersionActual = Random.Range(-dispersionMax, dispersionMax);

        Quaternion dispersion = Quaternion.Euler(0, 0, dispersionActual);

        balas--;
        nextShoop = Time.time + 0.1f;
        Instantiate(bullet[2], shotPoint.position, shotPoint.rotation * dispersion);
    }

    void Metralleta()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            metra = true;
        }
        if (balas <= 0)
        {
            recuperacion -= Time.deltaTime;
            if (recuperacion <= 0 && bulletType != 0)
            {
                balas = 30;
                recuperacion = 10f;
            }
            bulletType = 0;
        }
    }

    void UltiShooting()
    {
        PlayerLife life = GetComponent<PlayerLife>();
        if (bulletType == 0 && life.energy >= 30 && Input.GetKeyDown(KeyCode.E))
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
        life.energy -= 5;
        life.energy = Mathf.Clamp(life.energy, 0, int.MaxValue);
        if (life.energy > 0)
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
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("BulletEnemy"), true);
        playerInput = new Vector2(playerInput.x * dashSpeed, playerInput.y * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        ignoreCollisionTimer = ignoreCollisionDuration;
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
