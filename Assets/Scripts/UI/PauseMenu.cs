using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    
    // public PauseStatus pauseStatus;
    
    private InputSystem_Actions inputSystem;
    
    private Button continueButton;
    private Button settingsButton;
    private Button exitButton;
    
    private VisualElement pauseMenuRoot;
    
    public GameManager gameManager;
    
    public void OnEnable()
    {
        GetComponent<PanelRenderer>().RegisterUIReloadCallback(OnUIReload);
    }

    public void OnDisable()
    {
        GetComponent<PanelRenderer>().UnregisterUIReloadCallback(OnUIReload);
        if (inputSystem != null)
        {
            inputSystem.Player.Pause.performed -= PauseGame;
            inputSystem.Disable();
            inputSystem.Dispose();
        }

        if (continueButton != null)
        {
            continueButton.clicked -= ResumeGameCallback;
        }

        if (settingsButton != null)
        {
            settingsButton.clicked -= SettingsMenuCallback;
        }

        if (exitButton != null)
        {
            exitButton.clicked -= ExitGameCallback;
        }
    }
    
    void OnUIReload(PanelRenderer renderer, VisualElement rootElement, int version)
    {
        inputSystem = new InputSystem_Actions();
        
        inputSystem.Enable();
        inputSystem.Player.Pause.performed += PauseGame;
        
        pauseMenuRoot = rootElement;
        
        continueButton = pauseMenuRoot.Q<Button>("ContinueBtn");
        settingsButton = pauseMenuRoot.Q<Button>("SettingsBtn");
        exitButton = pauseMenuRoot.Q<Button>("ExitBtn");
        
        pauseMenuRoot.style.display = DisplayStyle.None;
        
        continueButton.clicked += ResumeGameCallback;
        settingsButton.clicked += SettingsMenuCallback;
        exitButton.clicked += ExitGameCallback;
    }

    private void PauseGame(InputAction.CallbackContext ctx)
    {
        if (gameManager.isPaused)
        {
            ResumeGameCallback();
        }
        else
        {
            Time.timeScale = 0f;
            gameManager.isPaused = true;
            pauseMenuRoot.style.display = DisplayStyle.Flex;
        }
    }
    
    private void ResumeGameCallback()
    {
        Time.timeScale = 1f;
        gameManager.isPaused = false;
        pauseMenuRoot.style.display = DisplayStyle.None;
    }

    private void SettingsMenuCallback()
    {
        // TODO: Implement settings menu
    }

    private void ExitGameCallback()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
