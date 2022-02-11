using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public enum FireType
{
	Beam,
	Projectile
}
public enum Auto
{
	Full,
	Semi
}

public class Weapon : MonoBehaviour
{
	public FireType type = FireType.Beam;
	public Auto auto = Auto.Full;

	public GameObject weaponModel;						
	public Transform raycastStartSpot;

	//Projectile
	public GameObject projectile;
	public Transform projectileSpawnSpot;

	// beam 
	public bool reflect = true;
	public int maxReflections = 5;                      
	public string beamTypeName = "laser_beam";         
	public float maxBeamHeat = 1.0f;    // seconds it will last	
	public Material beamMaterial;       // material used for beam -particle material
	private Color beamColor = Color.red;
	public Color[] colors;
	public static int colorsIndex;
	float newAlpha;
	public float startBeamWidth = 0.5f;
	public float endBeamWidth = 1.0f;
	private float beamHeat = 0.0f;      //timer for "heat" of a weapon
	private bool coolingDown = false;
	private GameObject beamGO;
	private bool beaming = false;
	public float beamPower = 1.0f;
	public float range = 9999.0f;

	// Ammo
	public int ammoCapacity = 12;
	public int shotPerRound = 1;
	private int currentAmmo;
	public float reloadTime = 2.0f;
	public bool showCurrentAmmo = true;

	// Audio
	public AudioClip fireSound;
	public AudioClip reloadSound;
	public AudioClip dryFireSound;


	void Start()
	{
		currentAmmo = ammoCapacity; // start with full ammo

        if (type == FireType.Beam)
        {
			colorsIndex = 0;
			newAlpha = 1.0f;
        }


		if (GetComponent<AudioSource>() == null)
			gameObject.AddComponent(typeof(AudioSource));

		if (raycastStartSpot == null)
			raycastStartSpot = gameObject.transform;

		if (projectileSpawnSpot == null)
			projectileSpawnSpot = gameObject.transform;

		if (weaponModel == null)
			weaponModel = gameObject;
	}

	void Update()
	{
		CheckForUserInput();

		if (type == FireType.Beam)
		{
			if (!beaming)
				StopBeam();
			beaming = false;
			
			beamColor = colors[colorsIndex];
			beamColor.a = newAlpha;
		}

	}

	void CheckForUserInput()
	{
		if (type == FireType.Beam)
		{
			if (Input.GetKey(KeyCode.Mouse0) && beamHeat <= maxBeamHeat && !coolingDown)
			{
                Beam();
			}
			else
			{
				StopBeam();
			}

			if (beamHeat >= maxBeamHeat)
			{
				coolingDown = true;
			}
			else if (beamHeat <= maxBeamHeat - (maxBeamHeat / 2))
			{
				coolingDown = false;
			}
		}

		if (type == FireType.Projectile && Input.GetKeyDown(KeyCode.Mouse0))
        {
			Launch();
		}
		
		if (Input.GetKeyDown(KeyCode.Alpha5) && !Input.GetKey(KeyCode.LeftControl)) // up
		{
			colorsIndex++;
			if (colorsIndex > 7)
				colorsIndex = 0;
			beamColor = colors[colorsIndex];
		}
		if (Input.GetKeyDown(KeyCode.Alpha6) && !Input.GetKey(KeyCode.LeftControl)) // down
		{
			colorsIndex--;
			if (colorsIndex < 0)
				colorsIndex = 7;
			beamColor = colors[colorsIndex];
		}
		
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			newAlpha += 0.1f;
			if (newAlpha > 1)
				newAlpha = 1;
		}
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			newAlpha -= 0.1f;
			if (newAlpha < 0)
				newAlpha = 0.1f;
		}
	}

    void Beam()
	{
		beaming = true;
		beamHeat += Time.deltaTime;

		if (beamGO == null)
		{
			beamGO = new GameObject(beamTypeName, typeof(LineRenderer));
			beamGO.transform.parent = transform;
		}

		LineRenderer beamLR = beamGO.GetComponent<LineRenderer>();
		beamLR.material = beamMaterial;
		beamLR.material.SetColor("_TintColor", beamColor);
		beamLR.startWidth = startBeamWidth;
		beamLR.endWidth = endBeamWidth;

		int reflections = 0;

		List<Vector3> reflectionPoints = new List<Vector3>();
		reflectionPoints.Add(raycastStartSpot.position);
		Vector3 lastPoint = raycastStartSpot.position;

		// variables for calculating rays
		Vector3 incomingDirc;
		Vector3 reflectDirc;

		bool keepReflecting = true;
		Ray ray = new Ray(lastPoint, raycastStartSpot.forward);
        RaycastHit hit;

		do
		{
			Vector3 nextPoint = ray.direction * range;

			if (Physics.Raycast(ray, out hit, range))
			{
				// Set the next point to the hit location from the raycast
				nextPoint = hit.point;

				// Calculate the next direction in which to shoot a ray
				incomingDirc = nextPoint - lastPoint;
				reflectDirc = Vector3.Reflect(incomingDirc, hit.normal);
				ray = new Ray(nextPoint, reflectDirc);

				// Update the lastPoint variable
				lastPoint = hit.point;

				hit.collider.gameObject.SendMessageUpwards("ChangeHealth", -beamPower * (newAlpha*2), SendMessageOptions.DontRequireReceiver);
				reflections++;
			}
			else
			{
				keepReflecting = false;
			}
			// Add the next point to the list of beam reflection points
			reflectionPoints.Add(nextPoint);

		} while (keepReflecting && reflections < maxReflections && reflect);

		// Set the positions of the vertices of the line renderer beam
		beamLR.positionCount = reflectionPoints.Count;
		for (int i = 0; i < reflectionPoints.Count; i++)
		{
			beamLR.SetPosition(i, reflectionPoints[i]);
		}
		if (!GetComponent<AudioSource>().isPlaying)
		{
			GetComponent<AudioSource>().clip = fireSound;
			GetComponent<AudioSource>().Play();
		}
	}

	public void StopBeam()
	{
		beamHeat -= Time.deltaTime;
		if (beamHeat < 0)
			beamHeat = 0;
		GetComponent<AudioSource>().Stop();

		if (beamGO != null)
		{
			Destroy(beamGO);
		}
	}

	public void Launch()
	{
		if(currentAmmo > 0)
        {
			// Fire once for each shotPerRound value
			for (int i = 0; i < shotPerRound; i++)
			{
				// Instantiate the projectile
				if (projectile != null)
				{
					GameObject proj = Instantiate(projectile, projectileSpawnSpot.position, projectileSpawnSpot.rotation) as GameObject;
					currentAmmo -= 1;
				}
				else
				{
					Debug.Log("Projectile to be instantiated is null.  Make sure to set the Projectile field in the inspector.");
				}
			}
			GetComponent<AudioSource>().PlayOneShot(fireSound);
        }
		else
			GetComponent<AudioSource>().PlayOneShot(dryFireSound);
	}
	void Reload()
	{
		currentAmmo = ammoCapacity;
		GetComponent<AudioSource>().PlayOneShot(reloadSound);

		SendMessageUpwards("OnEasyWeaponsReload", SendMessageOptions.DontRequireReceiver);
	}

	public void OnGUI()
	{
		if (showCurrentAmmo)
		{
			if (type == FireType.Beam)
				GUI.Label(new Rect(10, Screen.height - 30, 100, 20), "Heat: " + (int)(beamHeat * 100) + "/" + (int)(maxBeamHeat * 100));
			if (type == FireType.Projectile)
				GUI.Label(new Rect(10, Screen.height - 30, 100, 20), "Ammo: " + currentAmmo);
		}
	}
}