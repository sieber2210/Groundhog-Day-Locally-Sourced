using UnityEngine;

public class PlayerShield : MonoBehaviour
{   
    PlayerMovementInput inputObj;
    PlayerMovement_SO stats;
    GameObject shieldObj;

    float coolDownTimer;
    float upTimeTimer;

    private void Start()
    {
        inputObj = GetComponent<PlayerMovementInput>();
        stats = inputObj.moveStats;
        shieldObj = inputObj.shield;
    }

    private void Update()
    {
        
    }
}
