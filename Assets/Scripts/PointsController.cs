using TMPro;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    private TextMeshProUGUI table;
    private int _points;

    private string _name;

    private void Awake()
    {
        table = gameObject.GetComponent<TextMeshProUGUI>();
        _name = table.text;
    }

    public void AddPoints(int points)
    {
        _points += points;
        table.text = _name + _points.ToString();
    }

    public void SetPoints(int points)
    {
        _points = points;
        table.text = _name + _points.ToString();
    }
}
