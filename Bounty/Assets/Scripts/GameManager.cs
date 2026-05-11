using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
  [Header("References")]
  PlayerWeapon playerWeapon;
  [Header("UI")]
  [SerializeField] GameObject gameUI;
  [Header("Ammo UI Settings")]
  [SerializeField] GameObject loadedAmmoTextBox;
  [SerializeField] GameObject maxAmmoTextBox;
  TextMeshProUGUI loadedAmmoText;
  TextMeshProUGUI maxAmmoText;
 
  void Awake()
    {
        playerWeapon = FindFirstObjectByType<PlayerWeapon>();
        loadedAmmoText = loadedAmmoTextBox.GetComponent<TextMeshProUGUI>();
        maxAmmoText = maxAmmoTextBox.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        UpdateAmmoUI();
    }

    void UpdateAmmoUI()
    {
        loadedAmmoText.text = playerWeapon.GetLoadedAmmo().ToString();
        maxAmmoText.text = playerWeapon.GetMaxAmmo().ToString();
    }

    
}
