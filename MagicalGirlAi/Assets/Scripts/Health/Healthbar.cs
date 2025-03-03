using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHB;
    [SerializeField] private Image currentHB;

    private void Start()
    {
        totalHB.fillAmount = playerHealth.currentHealth / 10;
    }

    private void Update()
    {
        currentHB.fillAmount = playerHealth.currentHealth / 10;
    }
}
