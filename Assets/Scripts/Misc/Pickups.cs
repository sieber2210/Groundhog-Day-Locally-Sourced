using UnityEngine;

public enum PickupType { Ammo, Health};

public class Pickups : MonoBehaviour
{
    public Pickups_SO pickupStats;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SwitchStatement(other);
        }
    }

    void SwitchStatement(Collider other)
    {
        switch (pickupStats.pickupType)
        {
            case PickupType.Ammo:
                WeaponSwitcher switcher = other.GetComponentInChildren<WeaponSwitcher>();
                if (switcher != null)
                {
                    foreach (GameObject gun in switcher.weapons)
                    {
                        Gun _gun = gun.GetComponent<Gun>();
                        _gun.AddAmmo(pickupStats.ammoAdditive);
                    }
                }
                break;

            case PickupType.Health:
                PlayerHealth health = other.GetComponent<PlayerHealth>();
                if (health != null)
                {
                    health.AddHealth(pickupStats.healthAdditive);
                }
                break;
        }
    }
}
