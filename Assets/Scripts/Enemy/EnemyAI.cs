
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("Player Settings")]
    public Transform player;

    [Header("Attack Settings")]
    public float attackDistance = 1.5f;
    public float attackDamage = 10f;
    public float attackCooldown = 2f;

    private NavMeshAgent agent;
    private PlayerHealth playerHealth;

    private float nextAttackTime;

    void Start()
    {
        // Obtener el componente NavMeshAgent
        agent = GetComponent<NavMeshAgent>();

        // Obtener el sistema de vida del jugador
        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
        }
    }

    void Update()
    {
        // Comprobar que exista un jugador
        if (player == null || playerHealth == null)
            return;

        // Calcular la distancia entre el enemigo y el jugador
        float distance = Vector3.Distance(
            transform.position,
            player.position
        );

        // Comprobar si el jugador está dentro del rango de ataque
        if (distance <= attackDistance)
        {
            // Detener el movimiento del enemigo
            agent.isStopped = true;

            // Atacar respetando el tiempo de espera
            AttackPlayer();
        }
        else
        {
            // Permitir que el enemigo vuelva a moverse
            agent.isStopped = false;

            // Actualizar el destino del enemigo
            agent.SetDestination(player.position);
        }
    }

    void AttackPlayer()
    {
        // Comprobar si ya puede realizar otro ataque
        if (Time.time >= nextAttackTime)
        {
            // Aplicar daño al jugador
            playerHealth.TakeDamage(attackDamage);

            // Establecer el tiempo del siguiente ataque
            nextAttackTime = Time.time + attackCooldown;
        }
    }
}
