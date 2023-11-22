using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public float maxHealth = 4f;

    public PlayerLife vi;

    public int ene;
    public int numbofEnergy;

    public Image[] energy;

    void Start()
    {
        vi = GetComponentInChildren<PlayerLife>();
        vi.life = maxHealth;
        UpdateHealthBar();
    }

    private void Update()
    {
        if (vi.energy <= 0) { ene = 0; }
        else if (vi.energy <= 15) { ene = 1; }
        else if (vi.energy <= 30) { ene = 2; }
        else if (vi.energy <= 45) { ene = 3; }
        else if (vi.energy <= 60) { ene = 4; }

        for (int i = 0; i < numbofEnergy; i++)
        {
            energy[i].enabled = i < numbofEnergy && i < ene;
        }
    }

    public void UpdateHealthBar()
    {
        float fillAmount = vi.life / maxHealth;
        healthBarImage.fillAmount = fillAmount;
    }
}

