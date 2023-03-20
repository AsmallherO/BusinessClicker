using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Voody.UniLeo;

[Serializable]
public struct MagazineComponent
{
    public float Doxod, improve1, improve2, lvlupCost;

    public int Time, CurLvl;
    public Button Impr1, impr2, lvlup;
    public TextMeshProUGUI TextDoxod, ImproveText1, ImproveText2, LvlupText, lvl;
    public GameObject ProgressBar;

}