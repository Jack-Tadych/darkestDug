using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public Text weaponText;
    public Image weaponImage;
    public Sprite swordSprite;
    public Sprite bowSprite;
    public Sprite wandSprite;
    public PlayerController playerController;

    private void Update()
    {
        weaponText.text = "Weapon: " + playerController.weapon;
        
        // Update the weapon image based on the current weapon
        switch (playerController.weapon)
        {
            case "sword":
                weaponImage.sprite = swordSprite;
                break;
            case "bow":
                weaponImage.sprite = bowSprite;
                break;
            case "wand":
                weaponImage.sprite = wandSprite;
                break;
            default:
                weaponImage.sprite = null;
                break;
        }
    }
}
