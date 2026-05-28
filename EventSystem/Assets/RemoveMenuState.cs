using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveMenuState : BaseUIState
{
    [Header("UI References")]
    [SerializeField] private Dropdown resourceDropdown;
    [SerializeField] private InputField amountInputField;
    [SerializeField] private Button removeButton;

    [Header("Events")]
    [SerializeField] private ResourceEvent onResourceChangedEvent;

    private ResourceManager resourceManager;
    private List<ResourceType> resourceTypes = new List<ResourceType>();

    public override void Initialize(UIStateMachine machine)
    {
        base.Initialize(machine);
        resourceManager = FindObjectOfType<ResourceManager>();

        InitializeDropdown();

        if (removeButton != null)
        {
            removeButton.onClick.AddListener(OnRemoveClicked);
        }

        SetDefaultValues();
    }

    private void InitializeDropdown()
    {
        if (resourceDropdown == null || resourceManager == null) return;

        resourceDropdown.ClearOptions();
        resourceTypes.Clear();

        resourceTypes = resourceManager.GetAllResourceTypes();
        List<string> options = new List<string>();

        foreach (var type in resourceTypes)
        {
            options.Add(type.ToString());
        }

        resourceDropdown.AddOptions(options);
    }

    private void OnRemoveClicked()
    {
        if (resourceManager == null || resourceDropdown == null || amountInputField == null) return;

        int selectedIndex = resourceDropdown.value;
        if (selectedIndex < 0 || selectedIndex >= resourceTypes.Count) return;

        ResourceType selectedType = resourceTypes[selectedIndex];

        if (int.TryParse(amountInputField.text, out int amount))
        {
            if (amount > 0)
            {
                int currentAmount = resourceManager.GetResourceAmount(selectedType);

                if (amount > currentAmount)
                {
                    amount = currentAmount;
                }

                resourceManager.RemoveResource(selectedType, amount);

                if (onResourceChangedEvent != null)
                {
                    onResourceChangedEvent.Raise(selectedType, amount, false);
                }

                SetDefaultValues();
            }
            else
            {
                Debug.LogWarning("Количество должно быть положительным числом");
            }
        }
        else
        {
            Debug.LogWarning("Некорректное значение количества");
        }
    }

    private void SetDefaultValues()
    {
        if (resourceDropdown != null && resourceTypes.Count > 0)
        {
            resourceDropdown.value = 0;
        }

        if (amountInputField != null)
        {
            amountInputField.text = "0";
        }
    }
}