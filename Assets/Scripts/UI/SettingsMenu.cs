using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class SettingsMenu : MonoBehaviour
{

    private sealed class BindingRow
    {
        public InputAction action;
        public int bindingIndex;
        public string title;
    }
    
    private readonly List<BindingRow> keyboardMouseRows = new List<BindingRow>();
    
    private readonly List<BindingRow> controllerRows = new List<BindingRow>();
    
    private InputSystem_Actions inputSystem;
    
    private PanelRenderer panelRenderer;

    private MultiColumnListView keyboardMouseList;
    
    private MultiColumnListView controllerList;

    private VisualElement settingsMenuRoot;
    
    public PauseMenu pauseMenu;
    
    public void OnEnable()
    {
        GetComponent<PanelRenderer>().RegisterUIReloadCallback(OnUIReload);
    }

    public void OnDisable()
    {
        GetComponent<PanelRenderer>().UnregisterUIReloadCallback(OnUIReload);
        
        ClearList(keyboardMouseList);
        ClearList(controllerList);

        keyboardMouseList = null;
        controllerList = null;

        keyboardMouseRows.Clear();
        controllerRows.Clear();

        inputSystem?.Dispose();
        inputSystem = null;
    }

    private void OnUIReload(
        PanelRenderer renderer,
        VisualElement rootElement,
        int version
    )
    {
        inputSystem = new InputSystem_Actions();
        
        inputSystem.Enable();
        
        keyboardMouseList = rootElement.Q<MultiColumnListView>("KM-Controls");
        
        controllerList = rootElement.Q<MultiColumnListView>("Controller-Controls");

        if (keyboardMouseList == null || controllerList == null)
        {
            Debug.LogError("SettingsMenu: Could not find the controls list(s).", this);
            
            return;
        }
        
        settingsMenuRoot = rootElement;
        
        settingsMenuRoot.style.display = DisplayStyle.None;

        BuildBindingRows();

        ConfigureList(keyboardMouseList, keyboardMouseRows);
        ConfigureList(controllerList, controllerRows);
    }

    private void BuildBindingRows()
    {
        keyboardMouseRows.Clear();
        controllerRows.Clear();

        foreach (InputAction action in inputSystem.Player.Get())
        {
            for (int index = 0; index < action.bindings.Count; index++)
            {
                
                InputBinding inputBinding = action.bindings[index];
                
                if (inputBinding.isComposite)
                {
                    continue;
                }

                string layout = InputControlPath.TryGetDeviceLayout(inputBinding.path);

                List<BindingRow> destination;

                if (IsDeviceLayout(layout, "Gamepad"))
                {
                    destination = controllerRows;
                }
                else if (IsDeviceLayout(layout, "Keyboard") || IsDeviceLayout(layout, "Mouse"))
                {
                    destination = keyboardMouseRows;
                }
                else
                {
                    return;
                }
                
                string title = action.name;

                if (inputBinding.isPartOfComposite && !string.IsNullOrEmpty(inputBinding.name))
                {
                    title += $" ({inputBinding.name})";
                }
                
                destination.Add(new BindingRow
                {
                    action = action,
                    bindingIndex = index,
                    title = title,
                });
            }
        }
    }

    private static bool IsDeviceLayout(string layout, string baseLayout)
    {
        if (string.IsNullOrEmpty(layout))
        {
            return false;
        }
        
        return string.Equals(
            layout, baseLayout, StringComparison.OrdinalIgnoreCase) || InputSystem.IsFirstLayoutBasedOnSecond(layout, baseLayout);
    }

    private void ConfigureList(MultiColumnListView listView, List<BindingRow> rows)
    {
        listView.selectionType = SelectionType.None;
        listView.reorderable = false;
        listView.fixedItemHeight = 32;

        Column titleColumn = listView.columns["Title"];
        titleColumn.makeCell = () => new Label();
        titleColumn.bindCell = (element, index) =>
        {
            ((Label)element).text = rows[index].title;
        };
        
        Column bindingColumn = listView.columns["CurrentBind"];
        bindingColumn.makeCell = () => new Label();
        bindingColumn.bindCell = (element, index) =>
        {
            BindingRow row = rows[index];

            string displayText = row.action.GetBindingDisplayString(row.bindingIndex);

            ((Label)element).text = string.IsNullOrEmpty(displayText) ? "Unbound" : displayText;
        };
        
        Column rebindColumn = listView.columns["RebindAction"];
        rebindColumn.makeCell = CreateRebindCell;
        rebindColumn.bindCell = (element, index) =>
        {
            element.userData = rows[index];
        };

        rebindColumn.unbindCell = (element, index) =>
        {
            element.userData = null;
        };

        listView.itemsSource = rows;
        listView.Rebuild();
    }

    private VisualElement CreateRebindCell()
    {
        var button = new Button
        {
            text = "Rebind",
        };

        button.clicked += () =>
        {
            if (
                isActiveAndEnabled
                && button.userData is BindingRow row
            )
            {
                OnRebindRequested(row);
            }
        };

        return button;
    }

    private void OnRebindRequested(BindingRow row)
    {
        Debug.Log(
            $"Rebind requested: {row.action.name}, "
            + $"binding index {row.bindingIndex}",
            this
        );
    }

    private static void ClearList(MultiColumnListView listView)
    {
        if (listView == null)
        {
            return;
        }

        listView.itemsSource = null;
        listView.Rebuild();
    }
    
    public void ShowSettings()
    {
        inputSystem.Player.Pause.performed += HideSettings;
        settingsMenuRoot.style.display = DisplayStyle.Flex;
    }
    
    public void HideSettings(InputAction.CallbackContext context)
    {
        inputSystem.Player.Pause.performed -= HideSettings;
        settingsMenuRoot.style.display = DisplayStyle.None;
        pauseMenu.ShowPauseMenu();
    }
}
