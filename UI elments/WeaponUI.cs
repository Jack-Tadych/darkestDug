using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public Text heath;
    public Image weaponImage;
    public Sprite swordSprite;
    public Sprite Dagger;
    public Sprite BattleAxe;

    // public AudioSource swing;
    // public AudioSource stab;
    // public AudioSource hardSwing;

    public PlayerController playerController;

    private void Update()
    {
        Text = playerController.maxHeath + " " + playerController.currentHealth);
        
        // Update the weapon image based on the current weapon
        switch (playerController.weapon)
        {
            case "sword":
                weaponImage.sprite = swordSprite;
                break;
            case "dagger":
                weaponImage.sprite = Dagger;
                break;
            case "BattleAxe":
                weaponImage.sprite = BattleAxe;
                break;
            default:
                weaponImage.sprite = null;
                break;
        }
    }
}
