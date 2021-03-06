﻿using UnityEngine;
using System.Collections;

public enum ShieldState { Grow, Shrink, IdleMin, Cooldown}

public class PlayerShield : MonoBehaviour
{
    public string shieldKeyInput { get { return _keyInput; }set { _keyInput = value.Substring(0, maxLetters); } }
    string _keyInput;
    int maxLetters = 1;

    public string keyInput;

    PlayerMovementInput inputObj;
    PlayerMovement_SO stats;
    GameObject shieldObj;
    ShieldState state;

    //Havokk
    FMOD.Studio.EventInstance shieldSound;
    string audioState = "ShieldAudioState";

    private void Start()
    {
        inputObj = GetComponent<PlayerMovementInput>();
        stats = inputObj.moveStats;
        shieldObj = inputObj.shield;
        shieldKeyInput = keyInput;
        state = ShieldState.IdleMin;
        shieldObj.SetActive(false);

        //Havokk
        shieldSound = FMODUnity.RuntimeManager.CreateInstance("event:/Shield");
    }

    private void Update()
    {
        if(Input.GetKeyDown(shieldKeyInput) && state == ShieldState.IdleMin)
        {
            GrowShield();
        }

        ShieldSwitch();
    }

    void ShieldSwitch()
    {
        switch (state)
        {
            case ShieldState.Grow:
                Vector3 scale = shieldObj.transform.localScale;
                scale = Vector3.Lerp(scale, Vector3.one * stats.maxSize, stats.scaleSpeed * Time.deltaTime);
                shieldObj.transform.localScale = scale;

                if (shieldObj.transform.localScale.x <= stats.maxSize - 0.01f)
                {
                    StartCoroutine(GrowIdle());
                }
                break;

            case ShieldState.Shrink:
                scale = shieldObj.transform.localScale;
                scale = Vector3.Lerp(scale, Vector3.one * stats.startSize, stats.scaleSpeed * Time.deltaTime);
                shieldObj.transform.localScale = scale;

                if(shieldObj.transform.localScale.x <= stats.startSize + 0.01f)
                {
                    StartCoroutine(CoolDown());
                }
                break;

            case ShieldState.Cooldown:
                break;
        }
    }

    void GrowShield()
    {
        shieldObj.SetActive(true);
        state = ShieldState.Grow;

        //Havokk
        shieldSound.start();
    }

    IEnumerator GrowIdle()
    {
        yield return new WaitForSeconds(stats.shieldUpTime);

        //Havokk
        shieldSound.setParameterByName(audioState, 1f);
        //

        state = ShieldState.Shrink;
    }

    IEnumerator CoolDown()
    {
        //Havokk
        shieldSound.setParameterByName(audioState, 0f);

        shieldObj.SetActive(false);
        state = ShieldState.Cooldown;
        yield return new WaitForSeconds(stats.coolDown);
        state = ShieldState.IdleMin;
    }

    public void OnDisable()
    {
        shieldSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        shieldSound.release();
    }
}
