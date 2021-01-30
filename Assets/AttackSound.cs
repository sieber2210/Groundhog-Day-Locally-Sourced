using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSound : MonoBehaviour
{
    float currAnim;
    public Animator enemyAnimator;
    public FMOD.Studio.EventInstance attackSound;


    // Start is called before the first frame update
    void Start()
    {
        //currAnim = enemyAnimator.GetCurrentAnimatorStateInfo(0);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
        {
            attackSound.start();
        }
    }
}
