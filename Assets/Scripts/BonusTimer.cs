using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class BonusTimer : MonoBehaviour
{
    private float _time;
    private TextMeshProUGUI _table;
    private string _name;

    public UnityEvent OnBonusOver;

    private void Awake()
    {
        _table = gameObject.GetComponent<TextMeshProUGUI>();
        _name = _table.text;
    }

    private void Update()
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
            gameObject.SetActive(false);
            OnBonusOver?.Invoke();
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
}
