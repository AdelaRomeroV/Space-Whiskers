using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Movimiento")]
    private Rigidbody2D rb2D;
    private Vector2 playerInput;
    public float movSpeed;

    [Header("Dash")]
    public float activeMoveSpeed;
    public float dashSpeed;
    public float dashLeght = 0.5f, dashCooldown = 1f;
    private float dashCounter;
    private float dashCoolCounter;

    /*public float speed = 5f;
    public float dodgeRollDistance = 3f;
    public float dodgeRollDuration = 0.5f;
    public float dodgeRollSpeed = 10f;
    private bool isDodging = false;*/

    [Header("Weapon")]
    public Transform weapon;
    public Sprite[] weaponSprites;
    private float offset = 180f;

    [Header("Disparo")]
    public Transform shotPoint;
    public GameObject[] bullet;
    public float timerShots;
    private float nextShoop;
    public int bulletType;
    public float segundos;
    private bool isUltiActive = false;

    [Header("Metralleta")]
    private float dispersionMax = 20f;
    private int balas = 30;
    private float recuperacion = 10f;
    [SerializeField] public bool metra = false;
    public Image pata1;
    public Image pata2;

    private PlayerLife vidaJugador;

    private SpriteRenderer spriteRenderer;
    public TextMeshProUGUI textoHUD;

    public GameObject prevDash;

    public float dashRadius = 2f;
    public AudioClip[] sounds;
    private AudioSource audioSource;

    public GameObject npcDialogo;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        vidaJugador = GetComponent<PlayerLife>();
        rb2D = GetComponent<Rigidbody2D>();
        activeMoveSpeed = movSpeed;
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameObject textoHUDObject = GameObject.Find("Municion");
        if (textoHUDObject != null) { textoHUD = textoHUDObject.GetComponent<TextMeshProUGUI>(); }
    }
    void Update()
    {
        if (vidaJugador.life > 0 && !vidaJugador.seCuro && !npcDialogo.activeSelf)
        {
            Mov();
            Rot();
            ChangeWeaponSprite();
            Shooting();
            Metralleta();
            activarDash();
            UltiShooting();
            Hud();
        }
    }

    void Hud()
    {
        if (textoHUD != null)
        {
            switch (bulletType)
            {
                case 0:
                    textoHUD.text = balas.ToString();
                    if (!metra)
                    {
                        pata1.gameObject.SetActive(true);
                        pata2.gameObject.SetActive(false);
                    }
                    break;
                case 1:
                    textoHUD.text = balas.ToString();
                    break;
                case 2:
                    textoHUD.text = balas.ToString();
                    if (metra)
                    {
                        pata1.gameObject.SetActive(false);
                        pata2.gameObject.SetActive(true);
                    }
                    break;
            }
        }
    }

    void ChangeWeaponSprite()
    {
        weapon.GetComponent<SpriteRenderer>().sprite = weaponSprites[bulletType];
    }

    void Mov()
    {
        Vector2 playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        playerInput.Normalize();
        rb2D.velocity = playerInput.normalized * activeMoveSpeed;
    }

    void Rot()
    {
        Vector3 displacement = weapon.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float playerInput = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        weapon.rotation = Quaternion.Euler(0f, 0f, playerInput + offset);
        if (displacement.x < 0)
        {
            weapon.GetComponent<SpriteRenderer>().flipY = false;
        }
        else
        {
            weapon.GetComponent<SpriteRenderer>().flipY = true;
        }
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
                    audioSource.PlayOneShot(sounds[0]);
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
        audioSource.PlayOneShot(sounds[1]);
    }

    void Metralleta()
    {
        if (balas <= 0)
        {
            recuperacion -= Time.deltaTime;
            metra = false;
            if (recuperacion <= 0)
            {
                balas = 30;
                recuperacion = 10f;
            }
            if (!isUltiActive)
            {
                bulletType = 0;
            }
            else
            {
                bulletType = 1;
            }

        }

        if (Input.GetKeyDown(KeyCode.F) && !isUltiActive)
        {
            if (metra || balas <= 0)
            {
                metra = false;
                bulletType = 0;
            }
            else if (!metra)
            {
                metra = true;
                bulletType = 2;
            }
        }
    }

    void UltiShooting()
    {
        PlayerLife life = GetComponent<PlayerLife>();
        if (!metra && life.energy >= 40 && Input.GetKeyUp(KeyCode.Q))
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
        isUltiActive = true;
        yield return new WaitForSeconds(2);
        life.energy -= 10;
        life.energy = Mathf.Clamp(life.energy, 0, int.MaxValue);
        isUltiActive = false;
        if (life.energy > 0)
        {
            StartCoroutine(State(life));
        }
        else
        {
            bulletType = 0;
        }
    }


    void activarDash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //StartCoroutine(PerformDodgeRoll());
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                spriteRenderer.color = Color.green;
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLeght;
            }
        }
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeMoveSpeed = movSpeed;
                dashCoolCounter = dashCooldown;
                spriteRenderer.color = Color.white;
            }
        }
        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }

    /*IEnumerator PerformDodgeRoll()
    {
        isDodging = true;

        Vector3 dodgeDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f).normalized;
        Vector3 initialPosition = transform.position;

        float elapsedTime = 0f;
        while (elapsedTime < dodgeRollDuration)
        {
            transform.Translate(dodgeDirection * dodgeRollSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isDodging = false;
    }*/
}
