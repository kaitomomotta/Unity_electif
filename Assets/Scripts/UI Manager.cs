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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}