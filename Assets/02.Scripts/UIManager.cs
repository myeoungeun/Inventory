using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject uiMainMenu;
    [SerializeField]private GameObject uiStatus;
    [SerializeField]private GameObject uiInventory;

    public void OnUiMainMenu()
    {
        uiMainMenu.SetActive(true);
    }

    public void OnUiStatus()
    {
        uiStatus.SetActive(true);
    }

    public void OnUiInventory()
    {
        uiInventory.SetActive(true);
    }
}
