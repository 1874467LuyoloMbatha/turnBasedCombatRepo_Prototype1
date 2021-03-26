using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript //: MonoBehaviour//
{
    public moveBaseScript Base { get; set; }

    public int PP { get; set; }

    public MoveScript(moveBaseScript pBasee) 
    {
        Base = pBasee;
        PP = pBasee.PP;
    
    }


    
    
}
