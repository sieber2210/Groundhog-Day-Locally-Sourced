using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Stats", menuName = "Enemy/Enemy Stats")]
public class Enemy_SO : ScriptableObject
{
    public int maxHealth;

    public float speed, chaseSpeed;
    public float minRoamRange, maxRoamRange;
    public float thoughtTime, wanderChancePercent;
    public float perceptionRadius, attackRange;
    public float animationSmoothDamp;
    public float castTime, spellRange, spellSpeed, chanceToCast, distFromPlayerToCast;
    public GameObject spellPrefab;
    public int damage, spellDamage;
}
