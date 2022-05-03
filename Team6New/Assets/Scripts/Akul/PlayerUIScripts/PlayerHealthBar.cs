using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    //to be merged with lucas health code
    public int MaxHealth = 100;
    public int CurrentHealth;

    public HealthBar healthBar;


    // Start is called before the first frame update
    void Start()
    {

        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }


    void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        healthBar.SetHealth(CurrentHealth);
    }

}
