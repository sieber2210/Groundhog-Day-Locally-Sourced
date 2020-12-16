using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Enemy_SO stats;

    [HideInInspector]public Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void Attack(GameObject victim)
    {
        Debug.Log(gameObject.name + " has attacked " + victim.name);
    }
}
