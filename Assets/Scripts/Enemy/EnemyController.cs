using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Enemy_SO stats;

    public void Attack(GameObject victim)
    {
        Debug.Log(gameObject.name + " has attacked " + victim.name);
    }
}
