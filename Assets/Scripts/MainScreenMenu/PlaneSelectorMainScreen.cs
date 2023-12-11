using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSelectorMainScreen : MonoBehaviour
{
    public static bool selected = true;
    public bool Plane;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        selected = Plane;
    }


    public void SetPlane1()
    {
        Plane = true;
    }

    public void SetPlane2()
    {
        Plane = false;
    }
}
