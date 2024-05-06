using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    void Update()
    {
        // Voice command trigger for scene change
        if (Input.GetKeyDown(KeyCode.V))
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            string targetSceneName = currentSceneName == "StreetScene" ? "RoomScene" : "StreetScene";
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
