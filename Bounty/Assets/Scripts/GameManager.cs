using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  [Header("References")]
  PlayerWeapon playerWeapon;
  PlayerHealth playerHealth;
  [Header("UI")]
  [SerializeField] GameObject gameUI;
  [Header("Ammo UI Settings")]
  [SerializeField] GameObject loadedAmmoTextBox;
  [SerializeField] GameObject maxAmmoTextBox;
  TextMeshProUGUI loadedAmmoText;
  TextMeshProUGUI maxAmmoText;
  [Header("Health UI Settings")]
  [SerializeField] Slider health;

 
  void Awake()
    {
        playerWeapon = FindFirstObjectByType<PlayerWeapon>();
        playerHealth = FindFirstObjectByType<PlayerHealth>();
        loadedAmmoText = loadedAmmoTextBox.GetComponent<TextMeshProUGUI>();
        maxAmmoText = maxAmmoTextBox.GetComponent<TextMeshProUGUI>();
        health.maxValue = playerHealth.GetPlayerHealth();
    }

    void Update()
    {
        UpdateAmmoUI();
        HealthSlider();
    }

    void UpdateAmmoUI()
    {
        loadedAmmoText.text = playerWeapon.GetLoadedAmmo().ToString();
        maxAmmoText.text = playerWeapon.GetMaxAmmo().ToString();
    }

    void HealthSlider()
    {
       health.value = playerHealth.GetPlayerHealth();
    }

    
}
