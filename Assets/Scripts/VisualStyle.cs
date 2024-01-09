using UnityEngine;

[CreateAssetMenu(fileName = "VisualStyle", menuName = "Visual Styles/New Style")]
public class VisualStyle : ScriptableObject
{
    [SerializeField] private Material _background1;
    [SerializeField] private float _speedForBackground1;

    [SerializeField] private Material _background2;
    [SerializeField] private float _speedForBackground2;

    [SerializeField] private Material _background3;
    [SerializeField] private float _speedForBackground3;

    //[SerializeField] private Sprite _buttonsView;
    [SerializeField] private Color _styleColor;
    [SerializeField] private Color _hoverColor;
    public Material background1 => this._background1;
    public Material background2 => this._background2;
    public Material background3 => this._background3;
    public float speedForBackground1 => this._speedForBackground1;
    public float speedForBackground2 => this._speedForBackground2;
    public float speedForBackground3 => this._speedForBackground3;
    //public Sprite buttonsView => this._buttonsView;
    public Color hoverColor => this._hoverColor;
    public Color styleColor => this._styleColor;


}
