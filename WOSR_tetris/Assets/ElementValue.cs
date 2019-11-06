using TMPro;
using UnityEngine;

public class ElementValue : MonoBehaviour
{
    [SerializeField]
    private int _power = 0;
    [ExecuteInEditMode]
    public int Power
    {
        get
        {
            return _power;
        }
        set
        {
            _power = value;
            text.text = text.text + _power + "\n";
        }
    }

    [SerializeField]
    private int _brake = 0;
    [ExecuteInEditMode]
    public int Brake
    {
        get
        {
            return _brake;
        }
        set
        {
            _brake = value;
            text.text = text.text + _brake + "\n";
        }
    }

    [SerializeField]
    private int _handling = 0;
    [ExecuteInEditMode]
    public int Handling
    {
        get
        {
            return _handling;
        }
        set
        {
            _handling = value;
            text.text = text.text + _handling + "\n";
        }
    }

    public TextMeshPro text;
}
