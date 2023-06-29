using UnityEngine;
using UnityEngine.UI;

public class ChargingPowerBar : MonoBehaviour
{
    public Slider slider;
    public LaunchObject launchObject;
    private AmmoManager ammoManager;
    private Slider chargeSlider;

    private void Start()
    {
        ammoManager = FindObjectOfType<AmmoManager>();
        chargeSlider = FindObjectOfType<Slider>();
        chargeSlider.maxValue = launchObject.maxCharge;
    }

    private void Update()
    {
        if (launchObject != null)
        {
        launchObject = FindObjectOfType<LaunchObject>();
        Charge();
        ChargeValues();
        }
    }

    void Charge(){
        
        float currentCharge = launchObject.GetCurrentCharge();
        slider.value = currentCharge;
    }

    void ChargeValues(){
        chargeSlider.maxValue = launchObject.maxCharge;
    }
}
