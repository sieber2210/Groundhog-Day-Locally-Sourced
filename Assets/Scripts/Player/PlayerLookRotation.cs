using UnityEngine;

public class PlayerLookRotation : MonoBehaviour
{
    private float xRotationLock;

    public void LookRotate(Transform camera, float mouseX, float mouseY, float lookRange)
    {
        //Set rotation lock to the y value of the mouse movement then clamp the y rotation to the value of look range set in player stats
        xRotationLock -= mouseY;
        xRotationLock = Mathf.Clamp(xRotationLock, -lookRange, lookRange);

        //Set the rotation of the camera to the y movement of the mouse
        camera.localRotation = Quaternion.Euler(xRotationLock, 0f, 0f);
        //Set the rotation of the player object to the x movement of the mouse
        transform.Rotate(Vector3.up * mouseX);
    }
}
