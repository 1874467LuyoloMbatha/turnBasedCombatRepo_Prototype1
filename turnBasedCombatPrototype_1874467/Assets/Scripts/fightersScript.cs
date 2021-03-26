using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightersScript // : MonoBehaviour//
{
    //Will calculate the stats attached to the level of the fighter (through _base_ + level))//

    public fighterBase _base { get; set; } // Allows class to be accessable from battle script//
    public int level { get; set; }

    // Auto creates private variable privatly //
    public int HP { get; set; }

    public List<MoveScript> moveS { get; set; }

    //Creation of fighters
    public fightersScript(fighterBase pBase, int pLevel) 
    {
        //Allows for attacks to be unlocked after a fighters reatchs a specific level 
        _base = pBase;
        level = pLevel;

        HP = HealthPoints;



       moveS = new List<MoveScript>();
        foreach (var move in _base.Moves2BLearnedP2) 
        {
            //Checks if the move/attack that can be learned is equal to the level of the fighter 
            if (move.Level <= level)
                moveS.Add(new MoveScript(move.MBase));

            if (moveS.Count >= 4)
                break;
           
        
        }
    }

    //Characterises the states of figter bsaed on level//
    public int Attack 
    {
        get { return Mathf.FloorToInt((_base.Attack * level) / 100f) + 5; }
    }

    public int Defense
    {
        get { return Mathf.FloorToInt((_base.Defence * level) / 100f) + 5; }
    }

    public int Speed
    {
        get { return Mathf.FloorToInt((_base.Speed * level) / 100f) + 5; }
    }

    public int HealthPoints
    {
        get { return Mathf.FloorToInt((_base.Speed * level) / 100f) + 5; }
    }

    public int SpAttack
    {
        get { return Mathf.FloorToInt((_base.SpAttack * level) / 100f) + 5; }
    }

    public int SpDefence
    {
        get { return Mathf.FloorToInt((_base.SpAttack * level) / 100f) + 10; }
    }

    public bool Tdamage(MoveScript move, fightersScript attackerr) 
    {
        float modies = Random.Range(0.85f, 1f); //Random number is added to ensure damge ammount varies each time //
        float a = (2* attackerr.level + 10)/ 250f;
        float d = a *move.Base.Power * ((float) attackerr.Attack/ Defense) +2;
        int damage = Mathf.FloorToInt(d * modies);

        HP -= damage;
        if (HP <= 0) 
        {
            HP = 0;
            return true;
        }
        return false;


    }
}
