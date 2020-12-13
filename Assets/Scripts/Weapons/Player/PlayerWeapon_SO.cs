using UnityEngine;

[CreateAssetMenu(fileName = "New Player Weapon", menuName = "Player/Weapon Stats")]
public class PlayerWeapon_SO : ScriptableObject
{
    public int damage;
    public float range;
    public bool isAuto;
    public float fireRate;
}
