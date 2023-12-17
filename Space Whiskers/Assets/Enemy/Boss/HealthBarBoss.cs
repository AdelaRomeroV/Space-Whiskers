using UnityEngine.UI;
using UnityEngine;

public class HealthBarBoss : MonoBehaviour
{
    public Image hubBoss;
    public Image barraDeVida;
    public EnemyLife vi;

    public EscenaBossCameraCollider camaras;

    public float maxHealth;

    private void Awake()
    {
        vi = GetComponent<EnemyLife>();
    }

    private void Start()
    {
        maxHealth = vi.life;        
    }

    void Update()
    {
        HealtBarBoss();
        Active();
    }

    public void HealtBarBoss()
    {      
        float fillAmount = vi.life / maxHealth;
        barraDeVida.fillAmount = fillAmount;
    }

    public void Active()
    {
        if (camaras.camera2 == true)
        {
            hubBoss.gameObject.SetActive(true);
        }
        else
        {
            hubBoss.gameObject.SetActive(false);
        }
    }
}
