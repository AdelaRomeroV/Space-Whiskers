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
    public Sprite fullEnergy;
    public Sprite emptyEnergy;

    void Start()
    {
        vi = GetComponentInChildren<PlayerLife>();
        vi.life = maxHealth;
        UpdateHealthBar();
    }

    private void Update()
    {
        if(vi.energy <= 0) { ene = 0; }
        else if (vi.energy <= 15) { ene = 1; }
        else if (vi.energy <= 30) { ene = 2; }

        for (int i = 0; i < energy.Length; i++)
        {
            if (i < ene) { energy[i].sprite = fullEnergy; }
            else { energy[i].sprite = emptyEnergy; }

            if (i < numbofEnergy) { energy[i].enabled = true; }
            else { energy[i].enabled = false; }
        }
    }

    public void UpdateHealthBar()
    {
        float fillAmount = vi.life / maxHealth;
        healthBarImage.fillAmount = fillAmount;
    }
}

