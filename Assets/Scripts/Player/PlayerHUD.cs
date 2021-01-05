using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    public Image healthBar;
    public TextMeshProUGUI ammoCount;
    public GameObject player;

    PlayerHealth health;
    WeaponSwitcher switcher;
    List<Gun> guns = new List<Gun>();

    private void Start()
    {
        health = player.GetComponent<PlayerHealth>();
        switcher = player.GetComponentInChildren<WeaponSwitcher>();
        for (int i = 0; i < switcher.weapons.Length; i++)
        {
            guns.Add(switcher.weapons[i].GetComponent<Gun>());
        }
    }

    private void Update()
    {
        HealthCheck();
        AmmoCheck();
    }

    void HealthCheck()
    {
        float mHealth = health.MaxHealth() + 0.1f;
        healthBar.fillAmount = Mathf.Abs(health.CurrentHealth() / mHealth);
    }

    void AmmoCheck()
    {
        int curWeapon = switcher.curWeapon;
        ammoCount.SetText(guns[curWeapon].CurrentAmmo().ToString());
    }
}
