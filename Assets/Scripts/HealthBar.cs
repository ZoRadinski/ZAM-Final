using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBarIM;
    public float CurrentHealth;
    private float MaxHealth = 100f;
    PlayerHealth player;
    // Start is called before the first frame update
    void Start()
    {
        healthBarIM = GetComponent<Image>();
        player = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = player.health;
        healthBarIM.fillAmount = CurrentHealth / MaxHealth;
            
    }
}
