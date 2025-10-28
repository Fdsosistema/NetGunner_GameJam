using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthSlider : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public Slider healthSlider;
    public float tempoInvulneravel = 1f;
    private bool invulneravel = false;

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

        if (invulneravel) return;
        currentHealth -= dano;

        StartCoroutine(TornarInvuneravel());

    }

   IEnumerator TornarInvuneravel()
    {
        invulneravel = true;
        yield return new WaitForSeconds(tempoInvulneravel);
        invulneravel = false;
    }

}