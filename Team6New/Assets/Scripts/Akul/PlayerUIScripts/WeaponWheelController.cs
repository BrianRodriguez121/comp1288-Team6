using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponWheelController : MonoBehaviour 
{

    public Animator anim;
    private bool weaponWheelSelected = false;
    public Image selectedItem;
    public Sprite noImage;
    public static int weaponID;

    public FPSController fpsController;

    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            weaponWheelSelected = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            fpsController.lookSpeed = 2;
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            weaponWheelSelected = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            fpsController.lookSpeed = 2;
        }



        if (weaponWheelSelected)
        {
            anim.SetBool("OpenWeaponWheel", true);
        }
        else
        {
            anim.SetBool("OpenWeaponWheel", false);
            
        }


        switch (weaponID) //The Id = each weapon on the wheel
        {
            case 0://nothing selected
                selectedItem.sprite = noImage;
                
                break;
                

            case 1://LAZER GUN 1 selected
                anim.SetBool("OpenWeaponWheel", false);

                break;



            case 2://GranadeLauncher

                Debug.Log("GranadeLauncher selected");
                anim.SetBool("OpenWeaponWheel", false);
                break;



            case 3://LAZER GUN 2 selected

                Debug.Log("BeamGun selected");
                anim.SetBool("OpenWeaponWheel", false);
                break;


            case 4://BEAM GUN selected
                Debug.Log("BeamGun selected");
                anim.SetBool("OpenWeaponWheel", false);
                break;



            


                //ect FOR EVERY GUN IN THE WHEEL A NEW CASWE NEEDED THAT CORROSPONDS TO THE NUMBER


        }





    }
}
