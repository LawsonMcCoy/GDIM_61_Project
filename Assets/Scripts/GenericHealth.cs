using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract public class GenericHealth : MonoBehaviour

{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    [SerializeField] protected Slider slider;
    // Start is called before the first frame update
    private void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    private void setHealth(int health)
    {
        slider.value = health;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        this.setHealth(currentHealth);
    }

    private void Awake()
    {
        currentHealth = maxHealth;
        
    }

    virtual protected void Start()
    {
        setMaxHealth(currentHealth);
    }

    abstract protected void onDeath();
}
