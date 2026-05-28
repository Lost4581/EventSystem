using System;
using UnityEngine;

[Serializable]
public class ResourceData
{
    public ResourceType type;
    public int amount;

    public ResourceData(ResourceType type, int amount = 0)
    {
        this.type = type;
        this.amount = amount;
    }

    public void Add(int value)
    {
        amount += value;
        if (amount < 0) amount = 0;
    }

    public void Remove(int value)
    {
        amount -= value;
        if (amount < 0) amount = 0;
    }

    public void Reset()
    {
        amount = 0;
    }

    public bool HasEnough(int requiredAmount)
    {
        return amount >= requiredAmount;
    }
}