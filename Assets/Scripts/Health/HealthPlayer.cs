using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    public Image HealthBar;
    [SerializeField] float maxHealthPoint = 100f;
    [SerializeField] float currentHealthPoint;


    // Start is called before the first frame update
    void Start()
    {
        currentHealthPoint = maxHealthPoint;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.fillAmount = currentHealthPoint / maxHealthPoint;
        if (Input.GetKeyDown(KeyCode.M))
        {
            currentHealthPoint -= 10;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            currentHealthPoint += 10;
        }
    }
    
}
