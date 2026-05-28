using UnityEngine;

public class AnalyticsLogger : MonoBehaviour, IGameEventListener
{
    [Header("Event References")]
    [SerializeField] private ResourceEvent onResourceChangedEvent;
    [SerializeField] private UIStateEvent onUIStateChangedEvent;
    [SerializeField] private ResetEvent onResetEvent;

    void Start()
    {
        if (onResourceChangedEvent != null)
            onResourceChangedEvent.RegisterListener(this);

        if (onUIStateChangedEvent != null)
            onUIStateChangedEvent.RegisterListener(this);

        if (onResetEvent != null)
            onResetEvent.RegisterListener(this);
    }

    void OnDestroy()
    {
        if (onResourceChangedEvent != null)
            onResourceChangedEvent.UnregisterListener(this);

        if (onUIStateChangedEvent != null)
            onUIStateChangedEvent.UnregisterListener(this);

        if (onResetEvent != null)
            onResetEvent.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        if (onResourceChangedEvent != null)
        {
            Debug.Log($"[Analytics] Resource {onResourceChangedEvent.resourceType} " +
                     $"{(onResourceChangedEvent.isAdded ? "added" : "removed")}: " +
                     $"{onResourceChangedEvent.amount}");
        }

        if (onUIStateChangedEvent != null)
        {
            Debug.Log($"[Analytics] UI State changed to: {onUIStateChangedEvent.stateType}");
        }

        if (onResetEvent != null)
        {
            Debug.Log("[Analytics] All resources reset");
        }
    }
}