using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void Exit()
    {
        Debug.Log("exit");
        Application.Quit();
    }

    public void RunLevel()
    {
        Debug.Log("Run Level");
    }
}
