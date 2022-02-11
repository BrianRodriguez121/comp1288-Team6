using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	public float damage = 100.0f;
	public float speed = 10.0f;
	public float initialForce = 1000.0f;
	public float lifetime = 30.0f;
	public GameObject explosion;
	private float lifeTimer = 0.0f;


	void Start()
	{
		// Add the initial force to rigidbody
		GetComponent<Rigidbody>().AddRelativeForce(0, 0, initialForce);
	}

	void Update()
	{
		lifeTimer += Time.deltaTime;

		if (lifeTimer >= lifetime)
		{
			Explode(transform.position);
		}

		if (initialForce == 0)		// Only if initial force is not being used to propel this projectile
			GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}

	void OnCollisionEnter(Collision col)
	{
		Hit(col);
	}

	void Hit(Collision col)
	{
		Explode(col.contacts[0].point);
	}

	void Explode(Vector3 position)
	{
		if (explosion != null)
		{
			Instantiate(explosion, position, Quaternion.identity);
		}
		Destroy(gameObject);
	}
}

