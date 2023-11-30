using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public float maxHealth = 4f;

    public PlayerLife vi;

    public int ene;
    public int numbofEnergy;

    public Image[] energy;
    public Image fullUlti;

    void Start()
    {
        vi = GetComponentInChildren<PlayerLife>();
        maxHealth = vi.energy;
    }

    private void Update()
    {
        if (vi.life <= 0) { ene = 0; }
        else if (vi.life <= 1) { ene = 1; }
        else if (vi.life <= 2) { ene = 2; }
        else if (vi.life <= 3) { ene = 3; }
        else if (vi.life <= 4) { ene = 4; }

        for (int i = 0; i < numbofEnergy; i++)
        {
            energy[i].enabled = i < numbofEnergy && i < ene;
        }
        UpdateHealthBar();
        UpdateUlti();
    }

    public void UpdateHealthBar()
    {
        float fillAmount = vi.energy / maxHealth;
        healthBarImage.fillAmount = fillAmount;
    }
    public void UpdateUlti()
    {
        Player jugador = GetComponent<Player>();
        PlayerLife life = GetComponent<PlayerLife>();
        if (!jugador.metra && life.energy >= 60 && Input.GetKeyUp(KeyCode.Q) && !life.seCuro)
        {
            fullUlti.gameObject.SetActive(true);
        }
        else if (vi.energy <= 0)
        {
            fullUlti.gameObject.SetActive(false);
        }
    }
}

