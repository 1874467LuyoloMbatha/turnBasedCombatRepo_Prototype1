using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// adds new 
[CreateAssetMenu (fileName ="fighters", menuName = "fighters/ Create new fighter")]
public class fighterBase : ScriptableObject
{ //Variables will be used ouside of this class,hense the SerializedField//
    public string name;

    [TextArea]
    [SerializeField] string description;

    //Base Stats for All Fighters//
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int speed;
    [SerializeField] int HP;
    [SerializeField] int sAttack;
    [SerializeField] int sDefense;

    [SerializeField] fighterType type1;
    [SerializeField] fighterType type2;

    public Sprite frontVeiw;
    public Sprite backVeiw;

    // List of attacks that can be learned//
    [SerializeField] List<moves2bLearned> Moves2BLearned;

    
    public string Name 
    {
        get 
        {
            return name;
        }
    }

    public string Descriptionn 
    {
        get 
        {
            return description;
        }
    }

    public int SpDefence
    {
        get { return sDefense; }
    }

    public int SpAttack
    {
        get { return sAttack; }
    }

    public int HealthPoints
    {
        get { return HP; }
    }

    public int Defence
    {
        get { return defense; }
    }

    public int Attack
    {
        get { return attack; }
    }

    public int Speed 
    {
        get { return speed; }
    }

    public List<moves2bLearned> Moves2BLearnedP2 
    {
        get 
        {
            return Moves2BLearned;
        }
    }
    
}

[System.Serializable]
public class moves2bLearned 
{
    //Allows the number of moves/attacks to be adjusted from inspector from the scriptable object
    
    
    
    
    //

    [SerializeField] moveBaseScript moveBase;
    [SerializeField] int level;

    public moveBaseScript MBase
    {
        get 
        {
            return moveBase;
        }
    }

    public int Level 
    {
        get 
        {
            return level;
        }
    } 
}

public enum fighterType 
{
    none,
    fire,
    water,
    grass,
    poision,
    ice,
    electric,
}

