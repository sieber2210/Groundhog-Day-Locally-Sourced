using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject[] weapons;

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
        switch (curWeapon)
        {
            case 0:
                weapons[0].SetActive(true);
                weapons[1].SetActive(false);
                break;

            case 1:
                weapons[0].SetActive(false);
                weapons[1].SetActive(true);
                break;
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
            if (curWeapon + 1 <= weapons.Length - 1) curWeapon++;
            else curWeapon = 0;
        }
        else if(scroll < 0f)
        {
            //scroll down
            if (curWeapon - 1 >= 0) curWeapon--;
            else curWeapon = weapons.Length - 1;
        }

        if (curWeapon == weapons.Length) curWeapon = 0;
        if (curWeapon == -1) curWeapon = weapons.Length - 1;
    }
}
