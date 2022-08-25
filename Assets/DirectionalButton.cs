using UnityEngine;
using System.Collections;
using System;
//TODO for now this class will be ported to actual for use. modifications must be made in case of multi motion/input type of scenarios
// solution is to turn DirectionalPrefix and Button to a dynamic array (maybe a linked list instead)
[System.Serializable]
public class DirectionalButton
{
    public int DirectionalPrefix;
    public ButtonEnum Button;

    public Vector2 setPrefixByVector
    {
        set
        {
            DirectionalPrefix = ConvertVector(value);
        }
    }

    //converts given vector2 to numpad notation
    int ConvertVector(Vector2 vect)
    {
        //should throw an error with this one maybe?
        if (vect.x > 1 || vect.y > 1)
            Debug.Log("vector values should not be great than 1");
        if (vect == new Vector2(-1, -1))
            return 1;
        if (vect == new Vector2(1, -1))
            return 3;
        if (vect == new Vector2(-1, 1))
            return 7;
        if (vect == new Vector2(1, 1))
            return 9;
        if (vect == new Vector2(0, -1))
            return 2;
        if (vect == new Vector2(-1, 0))
            return 4;
        if (vect == new Vector2(0, 0))
            return 5;
        if (vect == new Vector2(1, 0))
            return 6;
        if (vect == new Vector2(0, 1))
            return 8;
        return 0;
    }
    public DirectionalButton(int directionalPrefix, ButtonEnum button)
    {
        Button = button;
        DirectionalPrefix = directionalPrefix;
    }
    /// <summary>
    /// construct a directionalbutton by passing a string. NOTE: currently it can only accept latest entries so a 236AB passing would only result in creating a 6B button
    /// </summary>
    /// <param name="ButtonInString"></param>
    public DirectionalButton(string ButtonInString)
    {
        char[] Buttons = ButtonInString.ToCharArray();
        for (int x = 0; x < Buttons.Length; x++)
        {
            if (CheckCharIsNumberUnicode(Buttons[x]))
            {

                DirectionalPrefix = (int)Buttons[x] - 48;
            }
            else
            {
                Button = ConvertCharToButtonEnum(Buttons[x]);
            }
        }
    }
    //probably put this in extensions for future uses
    bool CheckCharIsNumberUnicode(char Char)
    {
        return (int)Char > 47 && (int)Char < 58;
    }
    void Concatenate(string button)
    {

    }

    //TODO work on throwing an error instead of just defaulting to F6 function
    ButtonEnum ConvertCharToButtonEnum(char Char)
    {
        ButtonEnum _Button;
        if (Enum.TryParse<ButtonEnum>(Char.ToString(), true, out _Button))
        {
            return _Button;
        }
        return ButtonEnum.F6;
    }
    public bool Equals(int DirectPrfx, ButtonEnum button)
    {
        if (!(DirectPrfx == DirectionalPrefix))
            return false;
        if (!(Button == button))
            return false;
        return true;
    }
    public bool Equals(DirectionalButton button)
    {
        if (DirectionalPrefix != button.DirectionalPrefix)
            return false;
        if (Button != button.Button)
            return false;
        return true;
    }
    public override string ToString()
    {
        return DirectionalPrefix.ToString() + Button.ToString();
    }
    public string toString()
    {
        return "";
    }
}

enum ButtonEnumToStringMode
{
    normal, mirrored, buttonPrefixed
}
