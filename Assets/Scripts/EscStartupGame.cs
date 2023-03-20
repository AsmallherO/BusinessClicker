using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;
using System;
using static EscStartupGame;

public sealed class EscStartupGame : MonoBehaviour
{
    private EcsWorld world;
    private EcsSystems systems;
    void Start()
    {
        world = new EcsWorld();
        systems = new EcsSystems(world);

        systems.ConvertScene();

        AddSystems();

        systems.Init();
    }

    
    
    private void AddSystems()
    {
        systems.Add(new BalanceSystem())
            .Add(new Business_System())
            .Add(new BusSystem())
            .Add(new HotelSystem())
            .Add(new CafeSystem())
            .Add(new SystemMagazine());
    }

    private void Update()
    {
        systems?.Run();
    }

    private void OnDestroy()
    {
        systems?.Destroy();
        systems = null;
        world?.Destroy();
        world = null;
    }
}
