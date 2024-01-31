using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bar();
    }

    public static int foo(ref int a, ref string s)
    {
        s = "yellow";
        a = a + 2;
        return a;
    }

    public static void bar()
    {
        int a = 3;
        string s = "Blue";
        foo(ref a, ref s);
        Debug.Log("a=" + a + ", s=" + s);
    }
}
