using UnityEngine;
using UnityEngine.UI;

public class ChargingPowerBar : MonoBehaviour
{
    public Slider slider;
    public LaunchObject launchObject;

    private void Update()
    {
        float currentCharge = launchObject.GetCurrentCharge();
        slider.value = currentCharge;
        // Debug.Log(currentCharge);
    }
}
