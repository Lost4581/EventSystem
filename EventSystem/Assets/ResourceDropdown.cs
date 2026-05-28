using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceDropdown : MonoBehaviour
{
    [SerializeField] private Dropdown dropdown;

    private List<ResourceType> resourceTypes = new List<ResourceType>();

    void Start()
    {
        InitializeDropdown();
    }

    private void InitializeDropdown()
    {
        if (dropdown == null)
            dropdown = GetComponent<Dropdown>();

        if (dropdown == null) return;

        dropdown.ClearOptions();
        resourceTypes.Clear();

        foreach (ResourceType type in System.Enum.GetValues(typeof(ResourceType)))
        {
            resourceTypes.Add(type);
            dropdown.options.Add(new Dropdown.OptionData(type.ToString()));
        }

        dropdown.value = 0;
        dropdown.RefreshShownValue();
    }

    public ResourceType GetSelectedResource()
    {
        if (dropdown.value >= 0 && dropdown.value < resourceTypes.Count)
        {
            return resourceTypes[dropdown.value];
        }
        return ResourceType.Gold;
    }

    public void ResetToDefault()
    {
        if (dropdown != null)
        {
            dropdown.value = 0;
        }
    }
}