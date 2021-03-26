using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move",menuName = "fighters/ Create new move")]
public class moveBaseScript : ScriptableObject
{
    //Refers to the name of the move/attack
    public string name;

    [TextArea]
    [SerializeField] string discription;

    [SerializeField] fighterType type;
    [SerializeField] int power;
    [SerializeField] int pp;
    [SerializeField] int accuracy;

    public string Name 
    {
        get 
        {
            return name;
        }
    }

    public string Description 
    {
        get
        {
            return discription;
        }
    }

    public fighterType Type
    {
        get
        {
            return type;
        }
    }

    public int Power
    {
        get
        {
            return power;
        }
    }

    public int PP
    {
        get
        {
            return pp;
        }
    }

    public int Accuracy
    {
        get
        {
            return accuracy;
        }
    }





}
