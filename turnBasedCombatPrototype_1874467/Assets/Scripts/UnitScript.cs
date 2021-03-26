using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    public string unitGama;
    public int uLevel;

    public int damage;

    public int currentHealtH;
    public int MaxHP;

    public bool tDamage(int Dmg) 
    {
        currentHealtH -= Dmg;
        if (currentHealtH <= 0)
            return true;
        else
            return false;  
    
    }

    public void healing(int ammount) 
    {
        currentHealtH += ammount;
        if (currentHealtH > MaxHP)
            currentHealtH = MaxHP;
       
    
    } 
}

