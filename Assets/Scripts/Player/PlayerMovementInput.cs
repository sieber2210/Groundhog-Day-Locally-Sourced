using UnityEngine;

[RequireComponent(typeof(PlayerMovementController))]
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerLookRotation))]
public class PlayerMovementInput : MonoBehaviour
{
    [Tooltip("Created object to be used as the 'stats' of the player to be configured and customized by the user")]
    [Header("Player Stats Object")]
    public PlayerMovement_SO moveStats;  //Player stats scriptable object created in the assets folder by the user
    [Space]
    [Tooltip("Empty Transform on player object set at the base of the object to check for ground components within a set range")]
    [Header("Check Ground Transform")]
    public Transform groundCheckPosition;  //Empty transform set at the bottom of the player object to search for the objects marked as ground
    [Space]
    [Tooltip("Camera to be used as the 'eyes' of the player object")]
    [Header("Camera on Player")]
    public Transform viewCamera;  //Camera mounted to the player to be used as the "eyes" of the playerpublic

    private CharacterController controller;  //The Character controller component required by this script
    private Rigidbody rb; //Rigidbody component that will be added at start if the user chooses to use rigidbody movement
    private PlayerMovementController movement;  //Required component to be used as the backend of the movement
    private PlayerLookRotation rotate; //Required component to be used to rotate the player based on mouse input

    private float horizontal;  //float to be used for checking horizontal input
    private float vertical;  //float to be used for checking vertical input
    private Vector3 input;  //vector3 to combine the input floats for ease of variable transfer

    private void Start()
    {
        //Getting components to fill private variables
        movement = GetComponent<PlayerMovementController>();
        rotate = GetComponent<PlayerLookRotation>();
        controller = GetComponent<CharacterController>();

        //if the user selects the use of rigidbody movement
        if (moveStats.isRigidbody) {
            controller.enabled = false;//disable the character controller
            gameObject.AddComponent<Rigidbody>();//add the rigidbody and set the rigidbody variable
            rb = GetComponent<Rigidbody>();
            rb.collisionDetectionMode = CollisionDetectionMode.Continuous;//set the collision detection to continuous
            rb.constraints = RigidbodyConstraints.FreezeRotation;//lock all rotation constraints
        }

        if(moveStats.lockMouse) Cursor.lockState = CursorLockMode.Locked;//if the user selects locking the mouse lock mouse and hide
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");//setting input floats to the input axies
        vertical = Input.GetAxisRaw("Vertical");

        input = new Vector3(horizontal, 0f, vertical);//set the input vector3 to the input floats

        if (!moveStats.isRigidbody) ControllerMovement();
        else RigidbodyMovement();

        LookRotation();
    }

    void LookRotation()
    {
        //define and set the mouse inputs to mouse movement and look speed and multiply by delta time to make it frame independent
        float mouseX = Input.GetAxisRaw("Mouse X") * moveStats.lookSpeed * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * moveStats.lookSpeed * Time.deltaTime;

        //Call the function on the player look rotation script to do the look rotation math for turning the camera and player objects
        rotate.LookRotate(viewCamera, mouseX, mouseY, moveStats.lookRange);
    }

    void ControllerMovement()
    {
        //call function to do the movement based on the character controller within the movement controller script
        movement.CharacterControllerMovement(controller, GroundCheck(), moveStats.canSprint, moveStats.canJump, input, moveStats.moveSpeed, moveStats.sprintSpeed, moveStats.gravity, moveStats.jumpForce);
    }

    void RigidbodyMovement()
    {
        //call function to do movement based on rigidbody and physics within the movement controller script
        movement.RigidbodyMovement(rb, GroundCheck(), moveStats.canSprint, moveStats.canJump, input, moveStats.moveSpeed, moveStats.sprintSpeed, moveStats.jumpForce);
    }

    bool GroundCheck()
    {
        //boolean check to determine if the player is within a set distance from the object labeled ground and returning the result
        return Physics.CheckSphere(groundCheckPosition.position, moveStats.groundCheckRadius, moveStats.whatIsGround);
    }
}
