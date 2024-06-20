using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraPulse : MonoBehaviour
{
    GameObject slender;
    PostProcessVolume m_Volume;
    Vignette m_Vignette;
    ChromaticAberration m_ChromaticAberration;
    // Start is called before the first frame update
    void Start()
    {
        slender = GameObject.Find("Slender");
        m_Vignette = GetComponent<Vignette>();
        m_ChromaticAberration = GetComponent<ChromaticAberration>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Vignette.intensity.value = Mathf.Sin(Time.realtimeSinceStartup);
    }
}
