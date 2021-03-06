﻿using UnityEngine;

public class RampRotationCheck : MonoBehaviour
{
    public Collider col;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            col.enabled = true;
            transform.Rotate(0f, 90f, 0f, Space.Self);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            col.enabled = false;
        }
    }

    public void AllowRotation()
    {
        col.enabled = true;
    }
}
