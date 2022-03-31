using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Explosion : MonoBehaviour
{
	public float explosionForce = 5.0f;
	public float explosionRadius = 10.0f;

	public float damage = 10.0f;
	IEnumerator Start()
	{
		yield return null;

		// An array of nearby colliders
		Collider[] cols = Physics.OverlapSphere(transform.position, explosionRadius);

        // Apply damage to any nearby GameObjects with the Health component
		foreach (Collider col in cols)
		{
			float damageAmount = damage * (1 / Vector3.Distance(transform.position, col.transform.position));

			col.GetComponent<Collider>().gameObject.SendMessageUpwards("ChangeHealth", -damageAmount, SendMessageOptions.DontRequireReceiver);
		}

		// A list to hold the nearby rigidbodies
		List<Rigidbody> rigidbodies = new List<Rigidbody>();

		foreach (Collider col in cols)
		{
			// Get a list of the nearby rigidbodies
			if (col.attachedRigidbody != null && !rigidbodies.Contains(col.attachedRigidbody))
			{
				rigidbodies.Add(col.attachedRigidbody);
			}
		}

		foreach (Rigidbody rb in rigidbodies)
		{
			rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, 1, ForceMode.Impulse);
		}
	}
}
