using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialLanguage : MonoBehaviour

{
    public GameObject panelEng; 
    public GameObject panelEsp; 
    public Button toggleButton;
    public TextMeshProUGUI buttonText;

    private bool isPanelEngVisible = true;

    void Start()
    {
        panelEng.SetActive(isPanelEngVisible);
        panelEsp.SetActive(!isPanelEngVisible);

        UpdateButtonText();

        toggleButton.onClick.AddListener(TogglePanelsVisibility);
    }

    void TogglePanelsVisibility()
    {
        isPanelEngVisible = !isPanelEngVisible;


        panelEng.SetActive(isPanelEngVisible);
        panelEsp.SetActive(!isPanelEngVisible);

        UpdateButtonText();
    }

    void UpdateButtonText()
    {
        if (isPanelEngVisible)
        {
            buttonText.text = "Esp";
        }
        else
        {
            buttonText.text = "Eng";
        }
    }
}
