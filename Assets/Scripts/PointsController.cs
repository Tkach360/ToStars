using TMPro;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    private TextMeshProUGUI table;
    private int _points;

    private void Start()
    {
        table = gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void OnStartGame()
    {
        _points = 0;
        table.text = table.text + "0";
    }

    public void AddPoints(int points)
    {
        _points += points;
        table.text = table.text + _points.ToString();
    }

    public void SetPoints(int points) 
    {
        _points = points;
        table.text = table.text + _points.ToString();
    }
}
