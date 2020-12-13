using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;

    [HideInInspector]public int curWeapon;

    private void Start()
    {
        curWeapon = 0;
    }

    private void Update()
    {
        CheckCurrentWeapon();
        SwitchWeapon();
    }

    void CheckCurrentWeapon()
    {
        if (curWeapon == 0)
        {
            weapons[0].SetActive(true);
            weapons[1].SetActive(false);
        }
        else if (curWeapon == 1)
        {
            weapons[0].SetActive(false);
            weapons[1].SetActive(true);
        }
    }

    void SwitchWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) curWeapon = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2)) curWeapon = 1;

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if(scroll > 0f)
        {
            //scroll up
            curWeapon = 0;
        }
        else if(scroll < 0f)
        {
            //scroll down
            curWeapon = 1;
        }
    }
}
