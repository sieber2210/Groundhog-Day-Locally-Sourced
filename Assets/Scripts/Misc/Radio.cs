using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class Radio : MonoBehaviour
{
    Animator anim;
    int curHealth;
    //EventInstance radioSound;

    public GameObject radioSound;

    public void OnEnable()
    {
        //radioSound = FMODUnity.RuntimeManager.CreateInstance("Event:/RadioSound");
    }

    public void Start()
    {
        //RuntimeManager.PlayOneShot("event:/RadioSound", transform.position);
        curHealth = 1;
        anim = GetComponent<Animator>();
        //radioSound.start();
    }

    public void TakeDamage(int amount)
    {
        if (curHealth > 0)
        {
            curHealth -= amount;

            if (curHealth <= 0) BreakRadio();
        }

        //Havokk

        //FMODUnity.RuntimeManager.PlayOneShot("event:/damage", transform.position);
    }

    public void BreakRadio()
    {
        anim.SetTrigger("Break");
        RuntimeManager.PlayOneShot("event:/RadioDestroy", transform.position);
        //radioSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        radioSound.SetActive (false);
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) BreakRadio();
        //Debug.Log(curHealth);
    }
#endif
}
