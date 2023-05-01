using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FGAnimations;
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

        DirectionalButton buttonA = new DirectionalButton("623AB");
        Debug.Log(buttonA.ToString());
        Debug.Log(buttonA.getStringKeyFormat());
        DirectionalButton ButtonB = new DirectionalButton("623AB");
        DirectionalButton ButtonC = new DirectionalButton("5A");
        DirectionalButton ButtonD = new DirectionalButton("APRFA929");
        DirectionalButton buttonE = new DirectionalButton("6321478ABCD");
        StringTree<int> testTree = new StringTree<int>();
        TreeNode<int> tree = new TreeNode<int>();

        tree.Add("ABCDE", 2022);
        tree.Add("ABC123", 2025);
        tree.Add("ABC", 152223);
        tree.Add("ABCDE", 2023);

        string turd = "Buggerall";
        //possibly do a nullcase class?
        //if tree returns a null, internally handle it by passing this class
        Debug.Log(tree.getData("ABCDE").Data.ToString());
        Debug.Log(tree.getData("A").Data.ToString());
        if (tree.getData("AB") == null)
            Debug.Log("AB node does not contain anything");
        else
            Debug.Log("contains something");

        TreeNode<testclass> tree2 = new TreeNode<testclass>();

        tree2.Add("ABC", new testclass { v = 0,strang ="ABC" });
        tree2.Add("A123", new testclass { v = 1, strang = "Alkallabeth" });

        var node = tree2.getData("A");
        Debug.Log(tree2.getData("ABC").Data.strang);
        if (node.isNodeEmpty)
            Debug.Log("Node has returned empty");
        Debug.Log(node.isNodeEmpty);
        Debug.Log(tree2.getData("A").Data.strang);

        Debug.Log(turd.AppendIndex(1));


       // RecursionTest("beans");
    }

    class testclass
    {
        public int v;
        public string strang;
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
        if (TuringCheck())
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

