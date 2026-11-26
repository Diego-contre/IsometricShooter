# IsometricShooter
> A wave-survival isometric shooter built in Unity 6.3 LTS and C#. Features a ScriptableObject-based weapon system, NavMesh enemy AI, progressive waves, and persistent high scores.

Shooter isométrico de supervivencia por oleadas hecho en **Unity 6.3 LTS** con C#. Sobrevive el mayor número de oleadas posible, administra la munición y cambia entre tres armas.

![Gameplay](docs/gameplay.gif)

> Prototipo jugable. Primero las mecánicas, después el arte.

## Cómo se juega

| Acción | Control |
|---|---|
| Moverse | WASD |
| Apuntar | Mouse |
| Disparar | Clic izquierdo |
| Interactuar / recoger | E |
| Pistola / Rifle / Escopeta | 1 / 2 / 3 |

Las oleadas empiezan con 5 enemigos y suman 2 más en cada una. Hay 5 segundos de espera antes de la primera y 5 de descanso entre oleadas (configurable desde el Inspector). Cuando mueres se muestra la oleada alcanzada, los enemigos eliminados, el tiempo sobrevivido y tu mejor oleada, que se guarda localmente con `PlayerPrefs`.

## Qué incluye

- **Jugador:** movimiento isométrico, cámara con seguimiento y apuntado con mouse.
- **Armas:** pistola, rifle de asalto y escopeta definidas con ScriptableObjects, con disparo individual o automático, munición y recarga.
- **Interacción:** recogida y equipamiento de armas.
- **Enemigos:** persecución con NavMesh y ataque con distancia y tiempo de espera configurables.
- **Oleadas:** dificultad progresiva y varios puntos de aparición.
- **Partida:** sistema de vida y daño, Game Over, estadísticas y reinicio.

## Tecnologías

Unity 6.3 LTS · C# · Input System · AI Navigation (NavMesh) · TextMeshPro · ScriptableObjects

## Estructura

```text
Assets/
├── Prefab/
├── Scenes/
├── ScriptableObjects/
└── Scripts/
    ├── Enemy/
    ├── Game/
    ├── Health/
    ├── Interaction/
    ├── Player/
    ├── UI/
    ├── Waves/
    └── Weapons/
```
## Assets de terceros

Los modelos de armas provienen de [Weapons FREE - Low Poly 3D Models Pack](https://assetstore.unity.com/packages/3d/props/weapons/weapons-free-low-poly-3d-models-pack-260492) de ithappy, y **no están incluidos en el repositorio** por su licencia. Antes de abrir la escena, impórtalos desde Package Manager > My Assets.

Weapon models are from ithappy's free [Weapons FREE](https://assetstore.unity.com/packages/3d/props/weapons/weapons-free-low-poly-3d-models-pack-260492) pack and are not included in this repository. Import it from the Package Manager before opening the scene.

## Ejecutarlo

```bash
git clone https://github.com/Diego-contre/IsometricShooter.git
```

1. En Unity Hub: **Add project from disk** y elige la carpeta.
2. Ábrelo con Unity 6.3 LTS.
3. Abre la escena principal en `Assets/Scenes/` y presiona Play.

## Próximos pasos

- Mejorar la sensación del combate y ajustar la dificultad de las oleadas.
- Mejorar la selección de objetos interactuables.
- Nuevas mecánicas de supervivencia e interfaz.
- Arte, animaciones y efectos cuando las mecánicas estén consolidadas.
- Build ejecutable para Windows.

---

Desarrollado por [Diego Contreras](https://github.com/Diego-contre)
