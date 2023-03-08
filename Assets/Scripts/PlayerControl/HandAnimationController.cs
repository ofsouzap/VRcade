using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerControl
{
    public class HandAnimationController : MonoBehaviour
    {

        protected const string thumbParam = "Thumb";
        protected const string triggerParam = "Trigger";
        protected const string gripParam = "Grip";

        [SerializeField] protected Animator animator;

        [SerializeField] private InputActionReference _thumbAction;
        [SerializeField] private InputActionReference _triggerAction;
        [SerializeField] private InputActionReference _gripAction;

        protected InputAction ThumbAction => _thumbAction.action;
        protected InputAction TriggerAction => _triggerAction.action;
        protected InputAction GripAction => _gripAction.action;

        private void Update()
        {

            float thumb, trigger, grip;
            thumb = ThumbAction.ReadValue<float>();
            trigger = TriggerAction.ReadValue<float>();
            grip = GripAction.ReadValue<float>();

            animator.SetFloat(thumbParam, thumb);
            animator.SetFloat(triggerParam, trigger);
            animator.SetFloat(gripParam, grip);

        }

    }
}