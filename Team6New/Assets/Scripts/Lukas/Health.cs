using UnityEngine;
using System.Collections;

public enum HealthAttached
{
	Enemy,
	Player
}
public enum ColorID: int
{
	zero_red = 0,
	one_orange = 1,
	two_green = 2,
	three_Pruple = 3,
	four_blue = 4,
	five_cyan = 5 
}

public class Health : MonoBehaviour
{
	public HealthAttached healthAttached = HealthAttached.Enemy;
	public ColorID enemyColorMatch = ColorID.zero_red;
	
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

		//enemy detecting if it has received damage to change states
		if(healthAttached == HealthAttached.Enemy && agent.detechHealthChange && lastHealthVal != currentHealth)
        {
			agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
			lastHealthVal = currentHealth;
        }

		if(currentHealth > maxHealth)
        {
			currentHealth = maxHealth;
        }
	}

    public void ChangeHealth(float amount)
	{
		//if laser color match enemy color more damage is dealt
		if(healthAttached == HealthAttached.Enemy)
        {
			if (colorsIndex == (int)enemyColorMatch)
			{
				currentHealth += amount * 2;
				print("colors matching, double damage");

				if (currentHealth <= 0 && !dead && canDie) 
					Die();
			}

			//if colors do not match deal base damage
			else if(colorsIndex != (int)enemyColorMatch && !CheckColorMatch())
			{
				currentHealth += amount;
				print("colors not match, base damage");

				if (currentHealth <= 0 && !dead && canDie)
					Die();
			}
		
			//if colors are opposite increase enemys stats
			else if(CheckColorMatch())
			{
				
				print("oposite colors detected");
				if(currentHealth <= maxHealth)
					currentHealth += 1.0f;

				if(agent.navMeshAgent.speed <= 20)
					agent.navMeshAgent.speed += 0.01f;

				if(agent.shootTimerMax >= 0.4f)
                    agent.shootTimerMax -= 0.001f;
			}

			//other two weapons health damage
			else
			{
				currentHealth += amount;

				if (currentHealth <= 0 && !dead && canDie)
				{
					Die();
				}
			}
        }

		//controls players health upon death
		else if (healthAttached == HealthAttached.Player)
        {
			currentHealth += amount;

			if (currentHealth <= 0 && !dead && canDie)
			{
				Time.timeScale = 0;
			}
            else
            {
				//print("player_Health 8==========D");
            }
		}
	}
	/*
	public void TakeHit(float amount)
	{
		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			Debug.Log(currentHealth);
		}
	}
	*/
	public void Die()
	{
		dead = true;
		AiDeathState deathState = agent.stateMachine.GetState(AiStateId.Death) as AiDeathState;
		agent.stateMachine.ChangeState(AiStateId.Death);
	}

	public bool CheckColorMatch()
    {
		if (colorsIndex == 0 && (int)enemyColorMatch == 5)
			return true;
		else if (colorsIndex == 1 && (int)enemyColorMatch == 4)
			return true;
		else if (colorsIndex == 2 && (int)enemyColorMatch == 3)
			return true;
		else if (colorsIndex == 3 && (int)enemyColorMatch == 2)
			return true;
		else if (colorsIndex == 4 && (int)enemyColorMatch == 1)
			return true;
		else if (colorsIndex == 5 && (int)enemyColorMatch == 0)
			return true;
        else
			return false;
    }
}
