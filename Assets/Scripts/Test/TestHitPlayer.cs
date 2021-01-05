using UnityEngine;

public class TestHitPlayer : MonoBehaviour
{
    PlayerHealth PH;

    private void Start()
    {
        PH = FindObjectOfType<PlayerHealth>();
    }

    public void TestHitToPlayer()
    {
        PH.TakeDamage(10);
    }
}
