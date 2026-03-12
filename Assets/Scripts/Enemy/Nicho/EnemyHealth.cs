using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public float enemyMaxHealth = 3;
    public float enemyMinHealth = 0;

    private float health;

    public float Health
    {
        get { return health; }
        set
        {
            float finalValue = Mathf.Clamp(value, enemyMinHealth, enemyMaxHealth);
            health = finalValue;
            debugEnemyHealth.text = $"enemy hp = {health}";
            if (health <= 0) gameObject.SetActive(false);
        }
    }

    // debug only
    public TextMeshProUGUI debugEnemyHealth;

    private void Awake()
    {
        Health = 3;
    }
}
