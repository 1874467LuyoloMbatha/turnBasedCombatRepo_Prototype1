using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleUnit : MonoBehaviour
{
    [SerializeField] fighterBase _baSee;
    [SerializeField] int level;
    [SerializeField] bool isPlayerUni;

    public fightersScript fighters { get; set; }
    
    
    
    
    
    
    
    public void blSetup() 
    {
        fighters = new fightersScript(_baSee, level);
        if (isPlayerUni)
            GetComponent<Image>().sprite = fighters._base.backVeiw;
        else
            GetComponent<Image>().sprite = fighters._base.frontVeiw;
    }
}
