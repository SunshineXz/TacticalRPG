using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject _actionPanel;

    static UIManager instance;
    private void Awake()
    {
        instance = this;
    }
    public static UIManager GetInstance()
    {
        return instance;
    }

    public void ShowActionPanel(bool show)
    {
        _actionPanel.SetActive(show);
    }
}
