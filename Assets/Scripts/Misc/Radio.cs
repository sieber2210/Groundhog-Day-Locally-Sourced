using UnityEngine;

public class Radio : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void BreakRadio()
    {
        anim.SetTrigger("Break");
    }
#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) BreakRadio();
    }
#endif
}
