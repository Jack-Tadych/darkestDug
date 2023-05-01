using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public Text weaponText;
    public Image weaponImage;
    public Sprite swordSprite;
    public Sprite Dagger;
    public Sprite BattleAxe;
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
                weaponImage.sprite = Dagger;
                break;
            case "wand":
                weaponImage.sprite = BattleAxe;
                break;
            default:
                weaponImage.sprite = null;
                break;
        }
    }
}
