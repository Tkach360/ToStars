using TMPro;
using UnityEngine;

public class TableController : MonoBehaviour
{
    protected TextMeshProUGUI table;
    protected int _points;

    protected string _name;

    private void Awake()
    {
        table = gameObject.GetComponent<TextMeshProUGUI>();
        _name = table.text;
        //SetTablePoints(0);
    }

    public void SetTablePoints(int points)
    {
        _points = points;
        table.text = _name + _points.ToString();
    }
}
