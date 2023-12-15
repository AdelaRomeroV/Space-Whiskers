using UnityEngine.UI;
using UnityEngine;

public class HealthBarBoss : MonoBehaviour
{
    public Image healthBarImage;
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
        healthBarImage.fillAmount = fillAmount;
    }

    public void Active()
    {
        if (camaras.camera2 == true)
        {
            healthBarImage.gameObject.SetActive(true);
        }
        else
        {
            healthBarImage.gameObject.SetActive(false);
        }
    }
}
