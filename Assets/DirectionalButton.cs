using UnityEngine;
using System.Collections.Generic;
using System;

//TODO for now this class will be ported to actual for use. modifications must be made in case of multi motion/input type of scenarios
// solution is to turn DirectionalPrefix and Button to a dynamic array (maybe a linked list instead)
[System.Serializable]
public class DirectionalButton
{
    public List<int> DirectionalPrefix { get; private set; }
    public List<ButtonEnum> Button { get; private set; }
    /*
    public int[] DirectionalPrefix;
    public ButtonEnum[] Button;
    */
    public Vector2 setPrefixByVector
    {
        set
        {
           // DirectionalPrefix = ConvertVector(value);
        }
    }
    public void RecordPrefixByVector(Vector2[] vects)
    {
        DirectionalPrefix = new List<int>();
        for(int x=0; x< vects.Length;x++)
        {
            DirectionalPrefix.Add(ConvertVector(vects[x]));
           
        }
    }
    public void RecordButtons(char[] buttons)
    {
        Button = new List<ButtonEnum>();
        for(int x=0;x< buttons.Length;x++)
        {
            Button.Add(ConvertCharToButtonEnum(buttons[x]));
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

    /// <summary>
    /// construct a directionalbutton by passing a string.
    /// </summary>
    /// <param name="ButtonInString"></param>
    public DirectionalButton(string ButtonInString)
    {
        DirectionalPrefix = new List<int>();
        Button = new List<ButtonEnum>();
        char[] _Buttons = ButtonInString.ToCharArray();
        for (int x = 0; x < _Buttons.Length; x++)
        {
            if (CheckCharIsNumberUnicode(_Buttons[x]))
            {
                //  DirectionalPrefix = (int)Buttons[x] - 48;
                DirectionalPrefix.Add((int)_Buttons[x] - 48);

            }
            else
            {
                Button.Add(ConvertCharToButtonEnum(_Buttons[x]));
              // Button = ConvertCharToButtonEnum(Buttons[x]);
            }
        }
    }
    //probably put this in extensions for future uses
    bool CheckCharIsNumberUnicode(char Char)
    {
        return (int)Char > 47 && (int)Char < 58;
    }

    //TODO work on throwing an error instead of just defaulting to F6 function  
    ButtonEnum ConvertCharToButtonEnum(char Char)
    {
        ButtonEnum _Button;
        if (Enum.TryParse<ButtonEnum>(Char.ToString(), true, out _Button))
        {
            return _Button;
        }
        return ButtonEnum.N;
    }

    public bool isEquals(List<int> prefix, List<ButtonEnum> rButtons)
    {
        if (DirectionalPrefix.Count != prefix.Count || Button.Count != rButtons.Count)
            return false;
        for(int x=0; x< DirectionalPrefix.Count;x++)
        {
            if (DirectionalPrefix[x] != prefix[x])
                return false;
        }
        for(int y=0; y<Button.Count; y++)
        {
            if (Button[y] != rButtons[y])
                return false;
        }
        return true;
    }
  
    public bool isEquals(DirectionalButton button)
    {
        return isEquals(button.DirectionalPrefix, button.Button);
       
    }
    public override string ToString()
    {
        return DirPrefixToString() + ButtontoString();
    }
    public string getStringKeyFormat()
    {
        return ButtontoString() + DirPrefixToString();
    }

   private string DirPrefixToString()
    {
        string strPrefix ="";
        for(int x=0; x< DirectionalPrefix.Count;x++)
        {
            strPrefix += DirectionalPrefix[x];
        }
        return strPrefix;
    }
    private string ButtontoString()
    {
        string strButton="";
        for(int x=0; x< Button.Count;x++)
        {
            strButton += Button[x].ToString();
        }
        return strButton;
    }

    public static string translateReadable()
    {
        return "";
    }
}
