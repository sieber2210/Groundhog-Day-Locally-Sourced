using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private Vector3 velocity;  //Velocity variable to keep the character controller grounded when the player goes airborne
    private float moveSpeed;  //Variable to be used to keep track of the current speed of the player during sprinting or not
    private bool moveSpeedSet = false;  //boolean to check if the movespeed variable was set on start

    public void CharacterControllerMovement(CharacterController control, bool checkGround, bool canSprint, bool canJump, Vector3 input, float speed, float sprintSpeed, float gravity, float jumpForce)
    {
        if (!moveSpeedSet)//if the move speed variable is not set set the variable and set the bool to not run this code again
        {
            moveSpeed = speed;
            moveSpeedSet = true;
        }

        if (checkGround && velocity.y < 0) velocity.y = -2f;  //if the player is on a ground object and the player is not falling or rising set the y value of velocity to -2

        if (Input.GetButtonDown("Sprint") && checkGround && canSprint) moveSpeed = sprintSpeed; //if the player hits the sprint and is grounded and can sprint is set true set move speed to sprint speed
        if (Input.GetButtonUp("Sprint") && canSprint) moveSpeed = speed; //if the player can sprint and releases the sprint button reset the move speed to regular speed

        Vector3 move = transform.right * input.x + transform.forward * input.z; //create a variable to set the directions of the input variable to allow for player movement as intended

        control.Move(move * moveSpeed * Time.deltaTime); //move the character controller based on the above move variable, player speed, and delta time for frame independance

        if (Input.GetButtonDown("Jump") && checkGround && canJump) velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity); //if the player can jump and is grounded set the y velocity to allow for upward movement

        velocity.y += gravity * Time.deltaTime; //add the velocity by delta time and gravity to create a faster fall like normal physics would do
        control.Move(velocity * Time.deltaTime);// reset the movement so that the new velocity is taken into account
    }

    public void RigidbodyMovement(Rigidbody rb, bool groundCheck, bool canSprint, bool canJump, Vector3 input, float speed, float sprintSpeed, float jumpForce)
    {
        if (!moveSpeedSet)//if the move speed variable is not set set the variable and set the bool to not run this code again
        {
            moveSpeed = speed;
            moveSpeedSet = true;
        }

        //create a move variable to take in the input and set them to proper directions then multiply by movespeed to set the velocity
        Vector3 move = transform.right * input.x + transform.forward * input.z;
        Vector3 vel = move * moveSpeed;
        
        //check for jumping if the player is grounded and can jump, then adding a force to the rigidbody to make the player jump
        if (Input.GetButtonDown("Jump") && groundCheck && canJump) rb.AddForce(Vector3.up * Mathf.Sqrt(jumpForce * -2f * Physics.gravity.y), ForceMode.VelocityChange);

        //check if the player hits sprint is grounded and can sprint the setting movespeed to sprint speed
        if (Input.GetButtonDown("Sprint") && groundCheck && canSprint) moveSpeed = sprintSpeed;
        if (Input.GetButtonUp("Sprint") && canSprint) moveSpeed = speed; //when sprint is released reset move speed to regular speed

        //if the input is not zero and the player is grounded, use the rigidbody to move towards the desired velocity
        if (input != Vector3.zero && groundCheck) rb.MovePosition(rb.position + vel * Time.deltaTime);        
    }
}
