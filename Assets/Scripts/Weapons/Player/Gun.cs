using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] PlayerWeapon_SO gunType;
    [SerializeField] ParticleSystem muzzleFlash;

    FMOD.Studio.EventInstance FireSound;
    
    Camera cam;
    float nextTimeToFire = 0f;

    private void Start()
    {
        cam = GetComponentInParent<Camera>();
        Debug.Log(gunType.name);
        FireSound = FMODUnity.RuntimeManager.CreateInstance("event:/guns/" + gunType.name);
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
            if (enemy != null) 
            { 
                enemy.TakeDamage(gunType.damage);
                //instantiate enemy impact effect
                //remove effect after x seconds
            }
            else
            {
                //instantiate non enemy impact effect
                //remove effect after x seconds
            }
        }
    }
}
