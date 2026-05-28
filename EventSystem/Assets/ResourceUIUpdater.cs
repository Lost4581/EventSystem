using UnityEngine;
using UnityEngine.UI;

public class ResourceUIUpdater : MonoBehaviour, IGameEventListener
{
    [Header("Event References")]
    [SerializeField] private ResourceEvent onResourceChangedEvent;
    [SerializeField] private ResetEvent onResetEvent;

    [Header("UI References")]
    [SerializeField] private Transform resourcesContainer;
    [SerializeField] private GameObject resourceItemPrefab;

    private ResourceManager resourceManager;
    private System.Collections.Generic.Dictionary<ResourceType, Text> resourceTexts =
        new System.Collections.Generic.Dictionary<ResourceType, Text>();

    void Start()
    {
        resourceManager = FindObjectOfType<ResourceManager>();

        if (onResourceChangedEvent != null)
            onResourceChangedEvent.RegisterListener(this);

        if (onResetEvent != null)
            onResetEvent.RegisterListener(this);

        InitializeUI();
    }

    void OnDestroy()
    {
        if (onResourceChangedEvent != null)
            onResourceChangedEvent.UnregisterListener(this);

        if (onResetEvent != null)
            onResetEvent.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        UpdateAllResourcesUI();
    }

    private void InitializeUI()
    {
        if (resourceManager == null || resourcesContainer == null) return;

        foreach (Transform child in resourcesContainer)
        {
            Destroy(child.gameObject);
        }

        resourceTexts.Clear();

        foreach (var resource in resourceManager.GetAllResources())
        {
            GameObject item = Instantiate(resourceItemPrefab, resourcesContainer);
            ResourceItemUI itemUI = item.GetComponent<ResourceItemUI>();

            if (itemUI != null)
            {
                itemUI.Initialize(resource.type, resource.amount);
                resourceTexts[resource.type] = itemUI.AmountText;
            }
        }
    }

    private void UpdateAllResourcesUI()
    {
        if (resourceManager == null) return;

        foreach (var resource in resourceManager.GetAllResources())
        {
            if (resourceTexts.ContainsKey(resource.type))
            {
                resourceTexts[resource.type].text = resource.amount.ToString();
            }
        }
    }
}