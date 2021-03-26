using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class battleHUD : MonoBehaviour
{
    [SerializeField] Text nameTxt;
    [SerializeField] Text levelTxt;
    [SerializeField] HPbar hpBar;

    //Sets values for tHe above classes(nmaeText,levelText and hpBar)//

    public void dataSetup(fightersScript fighters) 
    {
        nameTxt.text = fighters._base.Name;
        levelTxt.text = "Lvl" + fighters.level;
        hpBar.HPsetup((float)fighters.HP / fighters.HealthPoints);




    }


}
