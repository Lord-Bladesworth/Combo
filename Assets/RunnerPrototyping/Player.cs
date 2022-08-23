using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Sprite[] sprites; //variable to pass to spriteAnim;

    ReelData<Sprite> spriteAnim;
    SpriteRenderer sprRenderer;
    int frame;


    string strang;
    int Turing;
    // Start is called before the first frame update
    void Start()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
        spriteAnim = new ReelData<Sprite>(sprites);

        Turing = 0;
        /*
        List<char> strList;
        string star = "Completion";
        strList = new List<char>();

        for(int n=0; n< star.Length;n++)
        {
            strList.Add(star[n]);
        }
        RecursionTest(strList);
        */


        RecursionTest("beans");
    }

    // Update is called once per frame
    void Update()
    {
        //playSprite();
    }
    /*
    void RecursionTest(string testString)
    {
        if (TuringCheck())
            return;

        Debug.Log(testString);
        if (testString.Length >1)
        {

            RecursionTest(testString.ToCharArray(1,testString.Length-1).ConvertToString());
        }
        Debug.Log(testString);
    }
    */
    string RecursionTest(string str)
    {
        if(TuringCheck())
            return "";



        return "";
    }

    //function to avoid an infinite recursion
    bool TuringCheck()
    {
        Turing++;
        if (Turing > 30)
        {
            Debug.Log("Turing Limit reached, terminating function");
            return true;
        }
        return false;

    }
    void RecursionTest(List<char> strlist)
    {
        Turing++;
        if(Turing>30)
        {
            Debug.Log("Turing limit reached, terminating function");
        }
        print(strlist);
        if (strlist.Count>0)
        {
            strlist.RemoveAt(0);
            RecursionTest(strlist);
        }
        print(strlist);

    }
    void print(List<char> str)
    {
        string dbgStr="";
        for(int x=0; x< str.Count;x++)
        {
            dbgStr += str[x];
        }
        Debug.Log(dbgStr);
    }
    void playSprite()
    {
        
        sprRenderer.sprite = spriteAnim.ReadReelData(frame);
        frame++;
        if (frame > spriteAnim.ReelLength)
        {
            frame = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       
    }
    private void OnCollisionStay(Collision collision)
    {
        
    }
    private void OnCollisionExit(Collision collision)
    {

    }
}

