using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float health;
    public float maxHealth = 100.0f;
    public float stamina;
    public float maxStamina = 100.0f;
    public int inventorySize = 20;
    public Rigidbody rb;

    void Start()
    {
        health = maxHealth;
        stamina = maxStamina;

        rb = GetComponent<Rigidbody>();
    }
}
