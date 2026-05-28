using UnityEngine;

[CreateAssetMenu(menuName = "Game Events/Reset Event")]
public class ResetEvent : GameEvent
{
    public void RaiseReset()
    {
        base.Raise();
    }
}