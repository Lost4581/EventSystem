using UnityEngine;

public class UIStateMachine : MonoBehaviour
{
    [Header("State References")]
    [SerializeField] private BaseUIState currentState;
    [SerializeField] private MainMenuState mainMenuState;
    [SerializeField] private AddMenuState addMenuState;
    [SerializeField] private RemoveMenuState removeMenuState;

    [Header("Event")]
    [SerializeField] private UIStateEvent onUIStateChangedEvent;

    public BaseUIState CurrentState => currentState;

    void Start()
    {
        mainMenuState?.Initialize(this);
        addMenuState?.Initialize(this);
        removeMenuState?.Initialize(this);

        if (currentState == null && mainMenuState != null)
        {
            ChangeState(mainMenuState);
        }
        else if (currentState != null)
        {
            currentState.EnterState();
        }
    }

    public void ChangeState(BaseUIState newState)
    {
        if (currentState != null)
        {
            currentState.ExitState();
        }

        currentState = newState;

        if (currentState != null)
        {
            currentState.EnterState();

            if (onUIStateChangedEvent != null)
            {
                UIStateType stateType = GetStateType(currentState);
                onUIStateChangedEvent.Raise(stateType);
            }
        }
    }

    private UIStateType GetStateType(BaseUIState state)
    {
        if (state is MainMenuState) return UIStateType.MainMenu;
        if (state is AddMenuState) return UIStateType.AddMenu;
        if (state is RemoveMenuState) return UIStateType.RemoveMenu;
        return UIStateType.MainMenu;
    }

    public void GoToMainMenu() => ChangeState(mainMenuState);
    public void GoToAddMenu() => ChangeState(addMenuState);
    public void GoToRemoveMenu() => ChangeState(removeMenuState);
}