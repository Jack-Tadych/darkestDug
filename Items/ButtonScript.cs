using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public string sceneName;

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    // Create a new button in your Unity scene by going to GameObject -> UI -> Button.

    // With the button selected, go to the Inspector window and click on the "Add Component" button.

    // Select the "ButtonScript" component from the list and add it to the button.

    // In the Inspector window, set the "sceneName" variable to the name of the scene you want to load when the button is pressed.

    // Finally, in the Inspector window, find the "On Click ()" section and click the "+" button to add a new entry. Drag the button object into the "Object" field, and then select the "ButtonScript -> ChangeScene" method from the dropdown menu.


}
