using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//BattleSystem link//
public class bHUD : MonoBehaviour
{
    public Text nameText;
    public Text levelText;
    public Slider HpSlider;

    public void setHUD(UnitScript unit) 
    {
        nameText.text = unit.unitGama;
        levelText.text = "Lvl " + unit.uLevel;
        HpSlider.maxValue = unit.MaxHP;
        HpSlider.value = unit.currentHealtH;


    }

    public void setHP(int hp) 
    {
        HpSlider.value = hp;
    }


}
