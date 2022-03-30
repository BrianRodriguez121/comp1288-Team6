using UnityEngine;
using System.Collections;

public enum HealthAttached
{
	Enemy,
	Player
}

public class Health : MonoBehaviour
{
	public HealthAttached healthAttached = HealthAttached.Enemy;
	
	public bool canDie = true;					
	
	public float startingHealth = 100.0f;		
	public float maxHealth = 100.0f;			
	public float currentHealth;
	private static int colorsIndex;
	AiAgent agent;
	private bool dead = false;

	float lastHealthVal;

	void Start()
	{
		agent = GetComponent<AiAgent>();
		currentHealth = startingHealth;

		lastHealthVal = maxHealth;
	}

    private void Update()
    {
		colorsIndex = Weapon.colorsIndex;

		if(healthAttached == HealthAttached.Enemy && agent.detechHealthChange && lastHealthVal != currentHealth)
        {
			agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
			lastHealthVal = currentHealth;
        }
	}

    public void ChangeHealth(float amount)
	{
		if (colorsIndex == 0 && gameObject.tag == "cIndex_0")
		{
			currentHealth += amount;

			if (currentHealth <= 0 && !dead && canDie)
				Die();

			else if (currentHealth > maxHealth)
				currentHealth = maxHealth;
		}/*
		else if (colorsIndex == 1 && gameObject.tag == "cIndex_1")
		{
			currentHealth += amount;

			if (currentHealth <= 0 && !dead && canDie)
				Die();

			else if (currentHealth > maxHealth)
				currentHealth = maxHealth;
		}
		else if (colorsIndex == 2 && gameObject.tag == "cIndex_2")
		{
			currentHealth += amount;

			if (currentHealth <= 0 && !dead && canDie)
				Die();

			else if (currentHealth > maxHealth)
				currentHealth = maxHealth;
		}
		else if (colorsIndex == 3 && gameObject.tag == "cIndex_3")
		{
			currentHealth += amount;

			if (currentHealth <= 0 && !dead && canDie)
				Die();

			else if (currentHealth > maxHealth)
				currentHealth = maxHealth;
		}
		else if (colorsIndex == 4 && gameObject.tag == "cIndex_4")
		{
			currentHealth += amount;

			if (currentHealth <= 0 && !dead && canDie)
				Die();

			else if (currentHealth > maxHealth)
				currentHealth = maxHealth;
		}
		else if (colorsIndex == 5 && gameObject.tag == "cIndex_5")
		{
			currentHealth += amount;

			if (currentHealth <= 0 && !dead && canDie)
				Die();

			else if (currentHealth > maxHealth)
				currentHealth = maxHealth;
		}
		else if (colorsIndex == 6 && gameObject.tag == "cIndex_6")
		{
			currentHealth += amount;

			if (currentHealth <= 0 && !dead && canDie)
				Die();

			else if (currentHealth > maxHealth)
				currentHealth = maxHealth;
		}
		else if (colorsIndex == 7 && gameObject.tag == "cIndex_7")
		{
			currentHealth += amount;

			if (currentHealth <= 0 && !dead && canDie)
				Die();

			else if (currentHealth > maxHealth)
				currentHealth = maxHealth;
		}*/
        else
        {
			currentHealth += amount;

			if (currentHealth <= 0 && !dead && canDie)
				Die();

			else if (currentHealth > maxHealth)
				currentHealth = maxHealth;
		}
	}
	public void TakeHit(float amount)
	{
		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			Debug.Log(currentHealth);
		}
	}

	public void Die()
	{
		dead = true;
		AiDeathState deathState = agent.stateMachine.GetState(AiStateId.Death) as AiDeathState;
		agent.stateMachine.ChangeState(AiStateId.Death);
	}
}
