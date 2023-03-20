using Leopotam.Ecs;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

sealed class HotelSystem : IEcsRunSystem, IEcsInitSystem
{
    private readonly EcsFilter<HotelComponent, BalanceComponent> filter = null;
    public void Init()
    {
        filter.Get1(1).Impr1.onClick.AddListener(Improve1);
        filter.Get1(1).impr2.onClick.AddListener(Improve2);
        filter.Get1(1).lvlup.onClick.AddListener(Lvlup);
    }
    public void Run()
    {
        AnimDoxod();
    }

    public void Doxod(int i)
    {

        filter.Get2(2).balance += filter.Get1(i).Doxod;
    }


    public void AnimDoxod()
    {

        filter.Get1(1).ProgressBar.GetComponent<Image>().fillAmount += (0.01f * Time.deltaTime);
        if (filter.Get1(1).ProgressBar.GetComponent<Image>().fillAmount == 1)
        {
            Doxod(1);
            filter.Get1(1).ProgressBar.GetComponent<Image>().fillAmount = 0;
        }

    }

    public void Improve1()
    {
        if (filter.Get2(1).balance >= 5)
        {
            filter.Get2(1).balance -= 5;
            filter.Get1(1).improve1 = 0.5f;
            filter.Get1(1).Doxod = filter.Get1(1).CurLvl * 3 * (1 +
                filter.Get1(1).improve1 +
                filter.Get1(1).improve2);
            filter.Get1(1).TextDoxod.text = "Doxod " + filter.Get1(1).Doxod;
            filter.Get1(1).ImproveText1.text = "You have it!";
        }
    }

    public void Improve2()
    {
        if (filter.Get2(1).balance >= 10)
        {
            filter.Get2(1).balance -= 10;
            filter.Get1(1).improve2 = 1;
            filter.Get1(1).Doxod = filter.Get1(1).CurLvl * 3 * (1 +
                filter.Get1(1).improve1 +
                filter.Get1(1).improve2);
            filter.Get1(1).TextDoxod.text = "Doxod " + filter.Get1(1).Doxod;
            filter.Get1(1).ImproveText2.text = "You have it!";
        }
    }

    public void Lvlup()
    {
        if (filter.Get2(1).balance >= filter.Get1(1).lvlupCost)
        {
            filter.Get2(1).balance -= (filter.Get1(1).CurLvl + 1) * 3;
            filter.Get1(1).CurLvl++;
            filter.Get1(1).Doxod = filter.Get1(1).CurLvl * 3 * (1 +
                filter.Get1(1).improve1 +
                filter.Get1(1).improve2);
            filter.Get1(1).lvlupCost = (filter.Get1(1).CurLvl + 1) * 3;
            filter.Get1(1).TextDoxod.text = "Doxod : " + filter.Get1(1).Doxod;
            filter.Get1(1).LvlupText.text = "LVL UP \nЦена: " + filter.Get1(1).lvlupCost;
            filter.Get1(1).lvl.text = "LvL " + filter.Get1(1).CurLvl.ToString();
        }
    }
}