using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEffect
{
    IEffect rollAfflicationChance();

    public void Aggregate(IEffect aggragate); 
    public void Negate();
    public void Afflict();

    public string ToString();
}