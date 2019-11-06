using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
    public Image gauge;

    private float max;
    private float current = 100;
    public float CurrentValue
    {
        get { return current; }
        set
        {
            current = value;
            gauge.fillAmount = current / max;
        }
    }

    void Start()
    {
        max = 100;
        CurrentValue = 0;
    }


    public void UpdateCurrent(int amount)
    {
        int intValue = (int)amount;
        intValue = (int)Mathf.Sign(amount) * Mathf.Max(1, Mathf.Abs(intValue)); // lowest modification is always 1 or -1

        CurrentValue = Mathf.Max(CurrentValue + intValue, 0);
        
    }
}
