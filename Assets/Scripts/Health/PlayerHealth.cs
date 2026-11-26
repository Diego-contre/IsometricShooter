
using UnityEngine;

public class PlayerHealth : HealthSystem
{
    protected override void Die()
    {
        Debug.Log("El jugador ha muerto.");

        // Avisar al GameManager que la partida terminó
        if (GameManager.Instance != null)
        {
            GameManager.Instance.GameOver();
        }
    }
}
