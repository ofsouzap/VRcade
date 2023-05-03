using System.Collections;
using UnityEngine;
using HandUI;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace PlayerControl
{
    public class HandUIController : MonoBehaviour
    {

        [SerializeField] protected Transform uiAttachParent;
        [SerializeField] protected HandUI.HandUI.AttachPoint uiAttachPoint;

        [SerializeField] private InputActionReference _toggleMenuAction;
        protected InputAction ToggleMenuAction => _toggleMenuAction.action;

        [SerializeField] protected HandUI.HandUI _handUi;
        private HandUI.HandUI handUi;
        public HandUI.HandUI GetHandUI() => handUi;

        private bool menuActive;

        private void Start()
        {

            menuActive = false;

            // Find Hand UI component

            if (_handUi == null)
            {

                var handUis = FindObjectsOfType<HandUI.HandUI>();

                if (handUis.Length == 1)
                {
                    handUi = handUis[0];
                }
                else
                {
                    Debug.LogWarning("Couldn't automatically find Hand UI for Hand UI controller");
                }

            }
            else
                handUi = _handUi;

            // Add input action event listener

            ToggleMenuAction.started += _ => ToggleMenu();

        }

        private void ToggleMenu()
        {

            menuActive = !menuActive;

            if (menuActive)
                GetHandUI().AttachTo(uiAttachParent, uiAttachPoint);
            else
                GetHandUI().Detatch();

        }

    }
}