using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Menu Buttons")]
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button addMenuButton;
    [SerializeField] private Button removeMenuButton;

    [Header("Menu Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject addMenuPanel;
    [SerializeField] private GameObject removeMenuPanel;

    [Header("Button Panel")]
    [SerializeField] private GameObject buttonPanel; 

    private UIStateMachine stateMachine;

    void Start()
    {
        stateMachine = GetComponent<UIStateMachine>();
        if (stateMachine == null)
        {
            stateMachine = gameObject.AddComponent<UIStateMachine>();
        }

        InitializeButtons();

        if (buttonPanel != null)
        {
            buttonPanel.SetActive(true);
        }
    }

    private void InitializeButtons()
    {
        if (mainMenuButton != null)
            mainMenuButton.onClick.AddListener(() => stateMachine?.GoToMainMenu());

        if (addMenuButton != null)
            addMenuButton.onClick.AddListener(() => stateMachine?.GoToAddMenu());

        if (removeMenuButton != null)
            removeMenuButton.onClick.AddListener(() => stateMachine?.GoToRemoveMenu());
    }

    public void SetMenuPanelActive(GameObject panelToActivate)
    {
        if (mainMenuPanel != null) mainMenuPanel.SetActive(false);
        if (addMenuPanel != null) addMenuPanel.SetActive(false);
        if (removeMenuPanel != null) removeMenuPanel.SetActive(false);

        if (panelToActivate != null)
        {
            panelToActivate.SetActive(true);
        }
    }
}