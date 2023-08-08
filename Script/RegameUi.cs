using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegameUi : MonoBehaviour
{
    public GameObject boss;
    public GameObject panel;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if(!boss)
        {
            panel.SetActive(true);
        }
    }
}
