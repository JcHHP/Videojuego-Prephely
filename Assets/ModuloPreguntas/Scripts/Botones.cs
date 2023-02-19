using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Botones: MonoBehaviour
{
    public List<Button> buttonsList;
    private Button[] buttons;
    public int num;
    private void Start()
    {
        buttons = GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; i++)
        {
            buttonsList.Add(buttons[i]);
        }

    }
    private void Update()
    {
        
    }

    public void verifyIsPressed(bool verify)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttonsList[i].interactable = verify;
        }
    }
}