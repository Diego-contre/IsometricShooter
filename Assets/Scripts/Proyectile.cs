
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Settings")]
    public float speed = 15f;
    public float lifeTime = 3f;
    public float damage = 20f;

    private Vector3 direction;

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;
    }

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        // Comprobar si el objeto impactado tiene un sistema de vida
        HealthSystem health = other.GetComponentInParent<HealthSystem>();

        if (health != null)
        {
            // Aplicar daño al objetivo
            health.TakeDamage(damage);
        }

        // Destruir el proyectil después del impacto
        Destroy(gameObject);
    }
}
