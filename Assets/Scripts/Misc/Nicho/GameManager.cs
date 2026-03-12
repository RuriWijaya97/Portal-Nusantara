using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // singleton
    public static GameManager instance;

    [Header("Wait Time Settings")]
    public float waitTimeAttackSequence1 = 0.4f;
    public float waitTimeAttackSequence2 = 0.35f;
    public float waitTimeAttackSequence3 = 0.3f;

    [Header("Dash Distance Settings")]
    public float dashDistanceAttackSequence1 = 1.2f;
    public float dashDistanceAttackSequence2 = 1f;
    public float dashDistanceAttackSequence3 = 1.2f;
    public float dashDistanceDashState = 1.2f;

    [Header("Dash Duration Settings")]
    public float dashDurationAttackSequence1 = 0.15f;
    public float dashDurationAttackSequence2 = 0.15f;
    public float dashDurationAttackSequence3 = 0.15f;
    public float dashDurationDashState = 0.15f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
