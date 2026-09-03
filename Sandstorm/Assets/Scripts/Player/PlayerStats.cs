using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header ("Health Stats")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float healthRegenRate = 1f; // Unsure if auto regen or not yet

    [Header ("Stamina Stats")]
    [SerializeField] private float maxStamina = 100f;
    [SerializeField] private float staminaUsageRate = 10f;
    [SerializeField] private float staminaRegenRate = 15f;

    [Header ("Temperature Stats")]
    [SerializeField] private float maxTemp = 45f;
    [SerializeField] private float minTemp = -5f;

    [Header ("Hydration Stats")]
    [SerializeField] private float maxHydration = 100f;
    [SerializeField] private float hydrationDepletionRate = 0.05f;

    // Runtime stats
    private float currentHealth;
    private float currentStamina;
    private float currentTemp;
    private float currentHydration;

    void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
        currentHydration = maxHydration;
        currentTemp = 20f;  // Will need to wait until I build temperature system to do this properly
    }

    void Update()
    {
        
    }
}
