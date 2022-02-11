using UnityEngine;
using System.Collections;

public class WeaponSystem : MonoBehaviour
{
	public GameObject[] weapons;
	public int startingWeaponIndex = 0;
	private int weaponIndex;

	void Start()
	{
		weaponIndex = startingWeaponIndex;
		SetActiveWeapon(weaponIndex);
	}
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
			SetActiveWeapon(0);
		if (Input.GetKeyDown(KeyCode.Alpha2))
			SetActiveWeapon(1);
		if (Input.GetKeyDown(KeyCode.Alpha3))
			SetActiveWeapon(2);


		// Allow the user to scroll through the weapons
		if (Input.GetAxis("Mouse ScrollWheel") > 0)
			NextWeapon();
		if (Input.GetAxis("Mouse ScrollWheel") < 0)
			PreviousWeapon();
	}

	void OnGUI()
	{


	}

	public void SetActiveWeapon(int index)
	{
		// Make sure this weapon exists before trying to switch to it
		if (index >= weapons.Length || index < 0)
		{
			Debug.LogWarning("Tried to switch to a weapon that does not exist.  Make sure you have all the correct weapons in your weapons array.");
			return;
		}

		weaponIndex = index;
		weapons[index].GetComponent<Weapon>().StopBeam();
		for (int i = 0; i < weapons.Length; i++)
		{
			weapons[i].SetActive(false);
		}
		weapons[index].SetActive(true);
	}

	public void NextWeapon()
	{
		weaponIndex++;
		if (weaponIndex > weapons.Length - 1)
			weaponIndex = 0;
		SetActiveWeapon(weaponIndex);
	}

	public void PreviousWeapon()
	{
		weaponIndex--;
		if (weaponIndex < 0)
			weaponIndex = weapons.Length - 1;
		SetActiveWeapon(weaponIndex);
	}
}
