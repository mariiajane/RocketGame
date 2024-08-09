using Leopotam.Ecs;
using ScriptableObjects;
using Systems.Player;
using Systems.UI.Joystick;
using UnityEngine;


sealed class EcsStartup : MonoBehaviour
{
    [SerializeField] private PlayerInitData playerInitData;
    [SerializeField] private JoystickUIInitData joystickUIInitData;
    [SerializeField] private CanvasUIInitData canvasUIInitData;
    
    EcsWorld _world;
    EcsSystems _systems;

    void Start()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);
        Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
        _systems
            .Add(new PlayerInitSystem())
            .Add(new PlayerMovementRunSystem())
            .Add(new CanvasUIInitSystem())
            .Add(new JoystickUIInitSystem())
            .Add(new JoystickUIRunSystem())
            .Inject(playerInitData)
            .Inject(joystickUIInitData)
            .Inject(canvasUIInitData)
            .Init();
    }

    void Update()
    {
        _systems?.Run();
    }

    void OnDestroy()
    {
        if (_systems != null)
        {
            _systems.Destroy();
            _systems = null;
            _world.Destroy();
            _world = null;
        }
    }
}