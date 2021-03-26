using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPbar : MonoBehaviour
{
    [SerializeField] GameObject health;

    public void HPsetup(float normalisedHP) 
    {
        //Changes scale of health bar
        health.transform.localScale = new Vector3(normalisedHP, 1f);

    }
}