using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIColorManager : MonoBehaviour
{
    public Button[] buttons = new Button[3];
    public Color[] colors = new Color[3];

    public Player player;

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            Color c = buttons[i].GetComponent<Image>().color;
            colors[i] = c;
        }
    }

    public void OnClick(string color)
    {
        switch (color)
        {
            case "Red":
                player.ChangeColor(colors[0], color);
                break;

            case "Blue":
                player.ChangeColor(colors[1], color);
                break;

            case "Yellow":
                player.ChangeColor(colors[2], color);
                break;

            default: break;

        }
    }
}
