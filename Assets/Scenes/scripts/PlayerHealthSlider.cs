using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthSlider : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public Slider healthSlider; 
 
    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
       
    }

    private void Update()
    {
         healthSlider.value = currentHealth;
       
    }

    public void TakeDamage(float dano)
    {
      
       currentHealth -= dano;
       
      
        
    }

}