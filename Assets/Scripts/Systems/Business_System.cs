
using Leopotam.Ecs;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

sealed class Business_System : IEcsRunSystem, IEcsInitSystem
{
    private readonly EcsFilter<Business_Component,BalanceComponent> _business_components;
    public void Init()
    {
            _business_components.Get1(1).Impr1.onClick.AddListener(Improve1);
            _business_components.Get1(1).impr2.onClick.AddListener(Improve2);
            _business_components.Get1(1).lvlup.onClick.AddListener(Lvlup);
    }
    public void Run()
    {
        AnimDoxod();
    }

    public void Doxod(int i)
    {
        
        _business_components.Get2(2).balance += _business_components.Get1(i).Doxod;
    }


    public void AnimDoxod()
    {
        
        
            _business_components.Get1(1).ProgressBar.GetComponent<Image>().fillAmount += (0.33f * Time.deltaTime);
            if (_business_components.Get1(1).ProgressBar.GetComponent<Image>().fillAmount == 1)
            {
                 Doxod(1);
                _business_components.Get1(1).ProgressBar.GetComponent<Image>().fillAmount = 0;
            }
        
    }

    public void Improve1()
    {
        if (_business_components.Get2(1).balance >= 5)
        {
            _business_components.Get2(1).balance -= 5;
            _business_components.Get1(1).improve1 = 0.5f;
            _business_components.Get1(1).Doxod = _business_components.Get1(1).CurLvl * 3 * (1 +
                _business_components.Get1(1).improve1 +
                _business_components.Get1(1).improve2);
            _business_components.Get1(1).TextDoxod.text = "Doxod " + _business_components.Get1(1).Doxod;
            _business_components.Get1(1).ImproveText1.text = "You have it!";
        }
    }

    public void Improve2()
    {
        if (_business_components.Get2(1).balance >= 10)
        {
            _business_components.Get2(1).balance -= 10;
            _business_components.Get1(1).improve2 = 1;
            _business_components.Get1(1).Doxod = _business_components.Get1(1).CurLvl * 3 * (1 +
                _business_components.Get1(1).improve1 +
                _business_components.Get1(1).improve2);
            _business_components.Get1(1).TextDoxod.text = "Doxod " + _business_components.Get1(1).Doxod;
            _business_components.Get1(1).ImproveText2.text = "You have it!";
        }
    }

    public void Lvlup()
    {
        if (_business_components.Get2(1).balance >= _business_components.Get1(1).lvlupCost)
        {
            _business_components.Get2(1).balance -= (_business_components.Get1(1).CurLvl+1)*3;
            _business_components.Get1(1).CurLvl++;
            _business_components.Get1(1).Doxod = _business_components.Get1(1).CurLvl*3*(1+
                _business_components.Get1(1).improve1+
                _business_components.Get1(1).improve2);
            _business_components.Get1(1).lvlupCost = (_business_components.Get1(1).CurLvl+1)*3;
            _business_components.Get1(1).TextDoxod.text = "Doxod : " + _business_components.Get1(1).Doxod;
            _business_components.Get1(1).LvlupText.text = "LVL UP \n÷ÂÌ‡: " + _business_components.Get1(1).lvlupCost;
            _business_components.Get1(1).lvl.text = "LvL " + _business_components.Get1(1).CurLvl.ToString();
        }
    }
}