using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectColorPlayer : MonoBehaviour
{
    public Material PlayerMaterial;

    public Dropdown dropdown;
    public Color color1;
    public Color color2;
    public Color color3;

    void Start() 
    {
        selColor();
    }

    public void selColor()
    {

        int color = dropdown.value;
        Debug.Log(color);
        if (color == 0) 
        {
            PlayerMaterial.color = color1;
        } 
        else if (color == 1)
        {
            PlayerMaterial.color = color2;
        } 
        else if (color == 2)
        {
            PlayerMaterial.color = color3;
        }
        Debug.Log("ok");
    }
}
