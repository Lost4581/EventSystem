using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [SerializeField] private List<ResourceData> resources = new List<ResourceData>();

    public System.Action<ResourceType, int> OnResourceChanged;
    public System.Action OnResourcesReset;

    void Start()
    {
        InitializeResources();
    }

    private void InitializeResources()
    {
        foreach (ResourceType type in System.Enum.GetValues(typeof(ResourceType)))
        {
            if (!resources.Any(r => r.type == type))
            {
                resources.Add(new ResourceData(type, 100)); 
            }
        }
    }

    public int GetResourceAmount(ResourceType type)
    {
        var resource = resources.Find(r => r.type == type);
        return resource?.amount ?? 0;
    }

    public void AddResource(ResourceType type, int amount)
    {
        var resource = resources.Find(r => r.type == type);
        if (resource != null)
        {
            resource.Add(amount);
            OnResourceChanged?.Invoke(type, resource.amount);
            Debug.Log($"Добавлено {amount} {type}. Всего: {resource.amount}");
        }
    }

    public void RemoveResource(ResourceType type, int amount)
    {
        var resource = resources.Find(r => r.type == type);
        if (resource != null)
        {
            int oldAmount = resource.amount;
            resource.Remove(amount);
            OnResourceChanged?.Invoke(type, resource.amount);
            Debug.Log($"Удалено {amount} {type}. Было: {oldAmount}, стало: {resource.amount}");
        }
    }

    public void ResetAllResources()
    {
        foreach (var resource in resources)
        {
            resource.Reset();
            OnResourceChanged?.Invoke(resource.type, 0);
        }

        OnResourcesReset?.Invoke();
        Debug.Log("Все ресурсы сброшены до 0");
    }

    public List<ResourceType> GetAllResourceTypes()
    {
        return new List<ResourceType>(System.Enum.GetValues(typeof(ResourceType)).Cast<ResourceType>());
    }

    public List<ResourceData> GetAllResources()
    {
        return new List<ResourceData>(resources);
    }
}