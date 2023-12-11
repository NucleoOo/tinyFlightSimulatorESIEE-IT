using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedPlane : MonoBehaviour
{
    public List<GameObject> plane1Components;
    public List<GameObject> plane2Components;
    // Start is called before the first frame update
    void Start()
    {
        if (PlaneSelectorMainScreen.selected)
        {
            SetActive(plane1Components, true);
            SetActive(plane2Components, false);
        }
        else
        {
            SetActive(plane2Components, true);
            SetActive(plane1Components, false);
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetActive(List<GameObject> gameObjects, bool value)
    {
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.SetActive(value);
        }
    }
}
