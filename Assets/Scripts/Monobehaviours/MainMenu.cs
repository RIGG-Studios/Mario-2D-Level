using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    InputActions inputActions;

    private void Awake()
    {
        inputActions = new InputActions();

        inputActions.KeyboardAndMouse.Enter.performed += ctx =>
        {
            SceneManager.LoadScene("Level 1");
        };
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
}
