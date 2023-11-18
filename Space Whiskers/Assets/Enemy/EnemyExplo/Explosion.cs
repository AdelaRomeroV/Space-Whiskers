using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [Header("Ataque")]
    public float checkRadius;
    public LayerMask whatIsPlayer;

    [Header("Pre Animacion")]
    public SpriteRenderer spriteRenderer;
    public float colorChangeInterval;
    public GameObject fxExplosion;

    private float timer = 1.5f;

    private void Update()
    {
        if (detection())
        {
            HandleExplosion();
        }
        else
        {
            StopAllCoroutines();
            timer = Mathf.Max(0, timer + Time.deltaTime);
            spriteRenderer.material.SetColor("_Color", Color.red);
        }
    }

    private void HandleExplosion()
    {
        timer -= Time.deltaTime;
        StartCoroutine(ChangeColorRepeatedly());

        if (timer <= 0)
        {
            Instantiate(fxExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private IEnumerator ChangeColorRepeatedly()
    {
        while (true)
        {
            spriteRenderer.material.SetColor("_Color", Color.white);
            yield return new WaitForSeconds(colorChangeInterval);

            spriteRenderer.material.SetColor("_Color", Color.red);
            yield return new WaitForSeconds(colorChangeInterval);
        }
    }

    private bool detection()
    {
        return Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }

}
