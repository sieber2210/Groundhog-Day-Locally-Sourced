using UnityEngine;

[CreateAssetMenu(fileName = "New Pickup Stats", menuName = ("Pickups/Pickup Stats"))]
public class Pickups_SO : ScriptableObject
{
    public PickupType pickupType;
    public int ammoAdditive;
    public int healthAdditive;
}
