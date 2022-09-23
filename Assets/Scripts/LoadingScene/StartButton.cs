using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartButton : MonoBehaviour
{
    [SerializeField] private string sceneName; 

    private void Awake()
    {
        //anonymous function
        GetComponent<Button>().onClick.AddListener(
            () => 
            {
                SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            });
    }
}
