
using UnityEngine;



public class HealthSystem : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;

    public float currentHealth;

    // Inicializa la vida al comenzar
    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    // Recibe daño
    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;

        // Evitar que la vida sea menor que cero
        currentHealth = Mathf.Max(currentHealth, 0);

        Debug.Log(gameObject.name + " recibió " + damage +
                  " de daño. Vida restante: " + currentHealth);

        // Comprobar si el personaje murió
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Recupera vida
    public virtual void Heal(float amount)
    {
        currentHealth += amount;

        // Evitar superar la vida máxima
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }

    // Se ejecuta cuando la vida llega a cero
    protected virtual void Die()
    {
        Debug.Log(gameObject.name + " ha muerto.");
    }

    
 



    
    

}
