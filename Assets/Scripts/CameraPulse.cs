using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraPulse : MonoBehaviour
{
    GameObject slender;
    PostProcessVolume m_Volume;
    Vignette m_Vignette;

    // Start is called before the first frame update
    void Start()
    {
        slender = GameObject.Find("Slender");
        m_Vignette = GetComponent<Vignette>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
