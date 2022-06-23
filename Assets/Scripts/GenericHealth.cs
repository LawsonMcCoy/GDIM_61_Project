using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract public class GenericHealth : MonoBehaviour

{

    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    [SerializeField] protected Slider slider;

    public Image DamageImage;
    public float damageFlashSpeed = 3f;
    public Color damageFlashColor = new Color(1f, 0f, 0f, 0.1f);

    #region Private Variables
    bool damaged = false;
    #endregion
    //Start is called before the first frame update
    private void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    private void setHealth(int health)
    {
        slider.value = health;
    }

    virtual public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        this.setHealth(currentHealth);

        damaged = true;
        
        if (currentHealth < 0)
        {
            onDeath();
        }

        
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

    virtual protected void Update()
    {
        DamageFlash();
    }

    public void DamageFlash()
    {
        
        if (gameObject.tag == "PlayerMain")
        {
            if (!damaged)
            {
                DamageImage.color = Color.Lerp(DamageImage.color, Color.clear, (damageFlashSpeed * Time.deltaTime));

            }
            else
            {
                DamageImage.color = damageFlashColor;

            }

            damaged = false;
        }

        
    }


    
}
