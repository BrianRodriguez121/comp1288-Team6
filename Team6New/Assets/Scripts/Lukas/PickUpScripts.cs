using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickUpType
{
    Health,
    BeamAmmo,
    Grenage_Ammo
}

public class PickUpScripts : MonoBehaviour
{ 
    public PickUpType pickUpType = PickUpType.Health;
    public FPSController playerController;
    public WeaponSystem weaponSystem;

    public Weapon BeamWeapon;
    public Weapon GrenadeWeapon;

    public float healthIncreaseAmount = 1000f;
    public int beamAmmo= 8;
    public int grenadeAmmo = 4;

    public void Start()
    {
        playerController = FindObjectOfType<FPSController>();
        weaponSystem = playerController.GetComponentInChildren<WeaponSystem>();
        BeamWeapon = weaponSystem.weapons[1].GetComponent<Weapon>();
        GrenadeWeapon = weaponSystem.weapons[2].GetComponent<Weapon>();
    }
    

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            if(pickUpType == PickUpType.Health)
            {
                playerController.health.currentHealth += healthIncreaseAmount;
                Destroy(gameObject);
            }
            else if(pickUpType == PickUpType.BeamAmmo)
            {
                BeamWeapon.currentAmmo += beamAmmo;
                Destroy(gameObject);
            }
            else if(pickUpType == PickUpType.Grenage_Ammo)
            {
                GrenadeWeapon.currentAmmo += grenadeAmmo;
                Destroy(gameObject);
            }
        }
    }
}

