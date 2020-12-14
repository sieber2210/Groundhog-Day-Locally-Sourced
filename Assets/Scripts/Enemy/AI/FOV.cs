using UnityEngine;

public class FOV : MonoBehaviour
{
    EnemyAI ai;

    private void Start()
    {
        ai = GetComponentInParent<EnemyAI>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerMovementInput player = col.gameObject.GetComponent<PlayerMovementInput>();
            if(player != null)
            {
                ai.SetTarget(col.transform);
            }
            else
            {
                return;
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerMovementInput player = col.gameObject.GetComponent<PlayerMovementInput>();
            if (player != null)
            {
                ai.RemoveTarget();
            }
            else
            {
                return;
            }
        }
    }
}
