using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraPulse : MonoBehaviour
{
    private GameObject slender;
    public PostProcessVolume postProcessVolume;
    private Vignette vignette;
    private ChromaticAberration chromaticAberration;
    // Start is called before the first frame update
    void Start()
    {
        slender = GameObject.Find("Slender");
        if (!postProcessVolume.profile.TryGetSettings(out vignette))
        {
            Debug.LogError("No Vignette effect found in PostProcessVolume.");
            return;
        }
        if (!postProcessVolume.profile.TryGetSettings(out chromaticAberration))
        {
            Debug.LogError("No Vignette effect found in PostProcessVolume.");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        vignette.intensity.value = Mathf.PingPong(Time.time * 1f, 0.6f); ;
        chromaticAberration.intensity.value = Mathf.PingPong(Time.time * 1f, 1.0f);
    }
}
