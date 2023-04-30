using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public Text weaponText;
    public PlayerController playerController;

    private void Update()
    {
        weaponText.text = "Weapon: " + playerController.weapon;
    }
}
