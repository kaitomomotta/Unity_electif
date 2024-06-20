using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                print("UIManager is null");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public TextMeshProUGUI ObjectiveText;
    public TextMeshProUGUI PressEText;
    [SerializeField] public TextMeshProUGUI NoExitText;
    public List<Page> pages;
    public SC_FPSController player;
    public Slider signalSlider;
    public float minBar = 5f;
    public float maxBar = 500f;

    public void UpdateObjectiveText()
    {
        int pages = SC_FPSController.Instance._pages;
        if (pages >= 8)
        {
            ObjectiveText.text = "Objective:\nGet to the exit...";
        }
        else
        {
            ObjectiveText.text = "Objective:\nFind out...\n" + pages + "/8 pages collected";
        }
    }

    public void EnablePressE()
    {
        PressEText.enabled = true;
    }
    public void DisablePressE()
    {
        PressEText.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        DisablePressE();
        NoExitText.enabled = false;
        maxBar = 500f;
    }

    // Update is called once per frame
    void Update()
    {
        updateBarFill(closestDist(closestPage()));      
    }

    public Page closestPage() {
        Page closest = pages[0];
        float minDist = Mathf.Infinity;
        Vector3 playerPosition = player.transform.position;

        foreach(Page page in pages) {
            float distanceToPlayer = Vector3.Distance(page.transform.position, playerPosition);
            if (distanceToPlayer < minDist) {
                minDist = distanceToPlayer;
                closest = page;
            }
        }
        return closest;
    }

    public float closestDist(Page page) { 
        float distanceToTarget = Vector3.Distance(player.transform.position, page.transform.position);
        return distanceToTarget;
    }

    private void updateBarFill(float distance) {
        Debug.Log($"Normalized distance: {distance}");
        signalSlider.value = maxBar - distance;
        Debug.Log($"Signal bar fill amount: {signalSlider.value}");
    }
}
