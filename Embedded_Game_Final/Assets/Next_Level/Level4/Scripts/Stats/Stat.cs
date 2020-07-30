using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat 
{
    [SerializeField]
    private int baseValue;
    private List<int>modifiers=new List<int>();

    public int GetValue()
    {

        int finalvalue = baseValue;
        modifiers.ForEach(x=>finalvalue+=x);
        return finalvalue;
    }

    public void Addmodifier(int modifier)
    {
        if (modifier != 0)
            modifiers.Add(modifier);
    }

    public void Removemodifier(int modifier)
    {
        if (modifier != 0)
            modifiers.Remove(modifier);
    }

}
