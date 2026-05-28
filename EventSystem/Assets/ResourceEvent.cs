using UnityEngine;

[CreateAssetMenu(menuName = "Game Events/Resource Event")]
public class ResourceEvent : GameEvent
{
    public ResourceType resourceType;
    public int amount;
    public bool isAdded; 

    public void Raise(ResourceType type, int amountValue, bool added)
    {
        resourceType = type;
        amount = amountValue;
        isAdded = added;
        base.Raise();
    }
}