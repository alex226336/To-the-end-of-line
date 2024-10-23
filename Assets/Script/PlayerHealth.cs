using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour,IDamageable
{    
    [field: SerializeField] public float MaxHealth { get; set;} = 5f;
    [SerializeField] private TextMeshProUGUI HealthStates;

    public float CurrentHealth { get; set;}

    [SerializeField] HealthBar healthbar;

    private void Awake(){
        healthbar = GetComponentInChildren<HealthBar>();
        CurrentHealth = MaxHealth;

    }
    void Start()
    {
        healthbar.UpdateHealthBar(CurrentHealth,MaxHealth);
        HealthStates.text = "HEALTH "+ CurrentHealth+"/"+MaxHealth;

    }

    void Update()
    {


    }

    public void Damage(float dmg) {
        CurrentHealth-=dmg;
        if (CurrentHealth > MaxHealth){
            CurrentHealth = MaxHealth;
        }
        healthbar.UpdateHealthBar(CurrentHealth,MaxHealth);
        HealthStates.text = "HEALTH "+ CurrentHealth+"/"+MaxHealth;

        if (CurrentHealth<=0) {
            Die();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
