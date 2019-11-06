using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    private static PuzzleManager instance = null;
    private static readonly object padlock = new object();

    public Gauge powerGauge;
    public Gauge handlingGauge;
    public Gauge brakeGauge;


    // Constructor
    // ------------------------------------------------------------------------------
    PuzzleManager()
    {
    }

    // thread safe singleton
    public static PuzzleManager Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new PuzzleManager();
                }
                return instance;
            }
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
}
