using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public void Exit()
    {
        Debug.Log("exit");
        Application.Quit();
    }

    public void RunEasyMode()
    {
        Debug.Log("Run EasyMode");
    }

    public void RunHardMode()
    {
        Debug.Log("Run HardMode");
    }
}
