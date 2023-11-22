using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultStyleStrategy : IStyleStrategy
{
    public Material getMaterialForBackground1()
    {
        return (Material)Resources.Load("Materials/DefoultStyle/Mat1Def");
    }
    public Material getMaterialForBackground2()
    {
        return (Material)Resources.Load("Materials/DefoultStyle/Mat2Def");
    }
    public Material getMaterialForBackground3()
    {
        return (Material)Resources.Load("Materials/DefoultStyle/Mat3Def");
    }
    public float getSpeedForBackground1()
    {
        return 0.01f;
    }
    public float getSpeedForBackground2()
    {
        return 0.02f;
    }
    public float getSpeedForBackground3()
    {
        return 0.03f;
    }
    public Sprite getButtonsView()
    {
        return (Sprite)Resources.Load("Images/DefaultStyle/MenuBackView");
    }
    public Color getStyleColor()
    {
        return new Color(5, 10, 207);
    }
    public Color getHoverColor()
    {
        return new Color(0, 127, 255);
    }
}
