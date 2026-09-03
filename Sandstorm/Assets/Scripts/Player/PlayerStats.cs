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

    [Header ("Hydration/Hunger Stats")]
    [SerializeField] private float maxHydration = 100f;
    [SerializeField] private float hydrationDepletionRate = 0.05f;
    [SerializeField] private float minHunger = 0f;
    [SerializeField] private float maxHunger = 100f;

    // Runtime stats
    private float currentHealth;
    private float currentStamina;
    private float currentTemp;
    private float currentHydration;
    private bool thirsty;
    private bool hungry;

    void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
        currentTemp = 20f;  // Will need to wait until I build temperature system to do this properly
        currentHydration = maxHydration;
        thirsty = false;
        hungry = false;
    }

    void Update()
    {
        
    }
}
