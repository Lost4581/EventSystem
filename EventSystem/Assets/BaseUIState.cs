using UnityEngine;

public abstract class BaseUIState : MonoBehaviour
{
    [SerializeField] protected GameObject statePanel;

    protected UIStateMachine stateMachine;

    public virtual void Initialize(UIStateMachine machine)
    {
        stateMachine = machine;
    }

    public virtual void EnterState()
    {
        if (statePanel != null)
        {
            statePanel.SetActive(true);
        }
    }

    public virtual void ExitState()
    {
        if (statePanel != null)
        {
            statePanel.SetActive(false);
        }
    }
}