using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

    sealed class BalanceSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BalanceComponent> _balanceSystem = null;

        public void Run()
        {
            _balanceSystem.Get1(1).m_TextMeshPro.text = "Balance: " + _balanceSystem.Get1(1).balance.ToString();
        }
    }

