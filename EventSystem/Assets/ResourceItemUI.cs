using UnityEngine;
using UnityEngine.UI;

public class ResourceItemUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Text nameText;
    [SerializeField] private Text amountText;
    [SerializeField] private Image iconImage;

    public Text AmountText => amountText;

    public void Initialize(ResourceType type, int amount)
    {
        if (nameText != null)
            nameText.text = type.ToString();

        if (amountText != null)
            amountText.text = amount.ToString();

        if (iconImage != null)
        {
        }
    }

    public void UpdateAmount(int newAmount)
    {
        if (amountText != null)
            amountText.text = newAmount.ToString();
    }
}