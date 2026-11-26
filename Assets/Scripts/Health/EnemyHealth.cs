
using UnityEngine;

public class EnemyHealth : HealthSystem
{
    public WaveManager waveManager;

    protected override void Die()
    {
        Debug.Log(gameObject.name + " ha sido eliminado.");

        // Avisar al administrador que un enemigo fue eliminado
        if (waveManager != null)
        {
            waveManager.EnemyDefeated();
        }
        // Registrar el enemigo eliminado en las estadísticas
        if (GameManager.Instance != null)
        {
            GameManager.Instance.RegisterEnemyKilled();
        }

        // Destruir al enemigo
        Destroy(gameObject);
    }
}
