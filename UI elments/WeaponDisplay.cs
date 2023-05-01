using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour {

    public Text weaponText;
    public PlayerController player;

    private bool hovering = false;

    void Start() {
        weaponText.enabled = false;
    }

    void Update() {
        if (hovering) {
            weaponText.text = "Weapon: " + player.weapon;
        }
    }

    public void OnPointerEnter() {
        hovering = true;
        weaponText.enabled = true;
    }

    public void OnPointerExit() {
        hovering = false;
        weaponText.enabled = false;
    }
}
