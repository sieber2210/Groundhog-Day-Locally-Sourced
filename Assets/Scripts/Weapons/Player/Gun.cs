﻿using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] PlayerWeapon_SO gunType;
    [SerializeField] ParticleSystem muzzleFlash;

    Camera cam;
    float nextTimeToFire = 0f;

    //Havokk
    FMOD.Studio.EventInstance FireSound;

    private void Start()
    {
        cam = GetComponentInParent<Camera>();
        
        //Havokk
        //Debug.Log(gunType.name);
        FireSound = FMODUnity.RuntimeManager.CreateInstance("event:/guns/" + gunType.weaponClassName);
    }

    private void Update()
    {
        if (gunType.isAuto)
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / gunType.fireRate;
                Shoot();
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();

        FireSound.start();

        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, gunType.range))
        {
            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
            EnemyController eControl = enemy.GetComponent<EnemyController>();
            if (enemy != null) 
            {
                enemy.TakeDamage(gunType.damage);
                eControl.anim.SetTrigger("Hit");
                //instantiate enemy impact effect
                //remove effect after x seconds
            }
            else
            {
                //instantiate non enemy impact effect
                //remove effect after x seconds
            }

            //Havokk
            Boom radio = hit.transform.GetComponent<Boom>();
            if(radio != null)
            {
                radio.TakeDamage(gunType.damage);
            }
            //
        }
    }
}
