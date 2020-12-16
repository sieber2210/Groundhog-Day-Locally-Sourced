using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Stats", menuName = "Enemy/Enemy Stats")]
public class Enemy_SO : ScriptableObject
{
    public int maxHealth;

    public float speed, chaseSpeed;
    public float minRoamRange, maxRoamRange;
    public float thoughtTime;
    public float animationSmoothDamp;
}
