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
     
        heath.text = playerController.currentHealth.ToString() + "/" + playerController.maxHealth.ToString();

        // Update the weapon image based on the current weapon
        switch (playerController.weapon)
        {
            
            case "sword":
                weaponImage.sprite = swordSprite;
                weaponImage.gameObject.SetActive(true);                
                break;
            case "dagger":
                weaponImage.sprite = Dagger;
                weaponImage.gameObject.SetActive(true);
                break;
            case "BattleAxe":
                weaponImage.sprite = BattleAxe;
                weaponImage.gameObject.SetActive(true);
                break;
            default:
                weaponImage.sprite = null;
                weaponImage.gameObject.SetActive(false);
                break;
        }
    }
}
