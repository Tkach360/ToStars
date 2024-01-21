using TMPro;
using UnityEngine;
using UnityEngine.Events;

abstract public class BonusTimer : MonoBehaviour
{
    protected float _time;
    protected TextMeshProUGUI _table;
    protected string _name;

    private void OnEnable()
    {
        GameController.DisableGame += EndBonus;
    }
    private void OnDisable()
    {
        GameController.DisableGame -= EndBonus;
    }
    protected void Awake()
    {
        _table = gameObject.GetComponent<TextMeshProUGUI>();
        _name = _table.text;
    }
    protected void Update()
    {
        if (_time > 0f)
        {
            //if(!gameObject.activeSelf) gameObject.SetActive(true);
            gameObject.SetActive(true);

            _time -= Time.deltaTime;
            _table.text = _name + Mathf.Round(_time).ToString();


        }
        else
        {
            EndBonus();
        }
    }

    public void AddTime(float time)
    {
        if (!gameObject.activeSelf) gameObject.SetActive(true);
        _time += time;
        _table.text = _name + _time.ToString();
    }

    public void SetTime(float time)
    {
        _time = time;
    }

    abstract public void EndBonus();
}