using UnityEngine;
using UnityEngine.UI;

public interface IStyleStrategy
{
    public Material getMaterialForBackground1();
    public Material getMaterialForBackground2();
    public Material getMaterialForBackground3();
    public float getSpeedForBackground1();
    public float getSpeedForBackground2();
    public float getSpeedForBackground3();
    public Sprite getButtonsView();
    public Color getStyleColor();
    public Color getHoverColor();
}
