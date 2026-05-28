using UnityEngine;
using UnityEngine.UI;

public class MainMenuState : BaseUIState
{
    [Header("UI References")]
    [SerializeField] private Button resetButton;

    [Header("Events")]
    [SerializeField] private ResetEvent onResetEvent;

    private ResourceManager resourceManager;

    public override void Initialize(UIStateMachine machine)
    {
        base.Initialize(machine);
        resourceManager = FindObjectOfType<ResourceManager>();

        if (resetButton != null)
        {
            resetButton.onClick.AddListener(OnResetClicked);
        }
    }

    private void OnResetClicked()
    {
        if (resourceManager != null)
        {
            resourceManager.ResetAllResources();

            if (onResetEvent != null)
            {
                onResetEvent.RaiseReset();
            }
        }
    }
}