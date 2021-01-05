using UnityEngine;

[CreateAssetMenu(fileName = "New Player Stats", menuName = "Player/Player Stats")]
public class PlayerMovement_SO : ScriptableObject
{
    [Header("Lock and Hide Mouse")]
    public bool lockMouse;

    [Header("Boolean checks")]
    [Tooltip("While false the player object will use the Character Controller movement system. - While true the player object will use the Rigidbody movement system")]
    public bool isRigidbody;
    public bool canSprint;
    public bool canJump;

    [Header("Movement Speed Variables")]
    public float moveSpeed;
    public float sprintSpeed;
    
    [Header("Look Around Variables")]
    public float lookSpeed;
    public float lookRange;

    [Header("Jump Variables")]
    public float jumpForce;

    [Header("Gravity Variable")]
    [Tooltip("This variable is only used when the player object is using the character controller movement system")]
    public float gravity;

    [Header("Ground Check Variables")]
    [Tooltip("Variable used to determine how far out from the ground check GameObject the system will look")]
    public float groundCheckRadius;
    [Tooltip("Variable to determine what is the ground to be marked by the user with the defined layer mask")]
    public LayerMask whatIsGround;

    [Header("Health")]
    public int maxHealth;

    [Header("Shield")]
    public float shieldUpTime;
    public float coolDown;
    public float startSize;
    public float maxSize;
    public float scaleSpeed;
}
