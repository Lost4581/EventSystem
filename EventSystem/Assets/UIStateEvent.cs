using UnityEngine;

[CreateAssetMenu(menuName = "Game Events/UI State Event")]
public class UIStateEvent : GameEvent
{
    public UIStateType stateType;

    public void Raise(UIStateType type)
    {
        stateType = type;
        base.Raise();
    }
}

public enum UIStateType
{
    MainMenu,
    AddMenu,
    RemoveMenu
}