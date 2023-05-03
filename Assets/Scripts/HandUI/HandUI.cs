using UnityEngine;
using UnityEngine.UI;

namespace HandUI
{
    public class HandUI : MonoBehaviour
    {

        private Transform initialParent;
        protected bool attached;

        protected Canvas mainCanvas;

        public enum AttachPoint
        {
            Top,
            Bottom,
            Left,
            Right
        }

        private Vector2 GetScaledDimensions()
        {
            RectTransform rt = mainCanvas.GetComponent<RectTransform>();
            return new(
                rt.rect.width * rt.localScale.x,
                rt.rect.height * rt.localScale.y
            );
        }

        private void Awake()
        {
            initialParent = transform.parent;
        }

        private void Start()
        {

            mainCanvas = GetComponentInChildren<Canvas>();

            if (mainCanvas == null)
            {
                Debug.LogError("No Canvas found in Hand UI object's children");
            }
            else
            {
                HideCanvas();
            }

            attached = false;

        }

        /// <summary>
        /// Show the canvas and places it as a child of the transform provided and offsets itself as needed.
        /// Only succeeds if not already attached to another transform.
        /// </summary>
        /// <param name="parent">The transform to make the canvas a child of</param>
        public void AttachTo(Transform parent, AttachPoint attachPoint)
        {
            if (!attached)
            {

                ShowCanvas();

                transform.parent = parent;
                attached = true;

                // When parenting self to attach parent, make sure to reset local transform (although position is set to something different later anyway)
                transform.localPosition = Vector3.zero;
                transform.localRotation = Quaternion.identity;

                // Calculate position offset

                Vector2 v = attachPoint switch
                {
                    AttachPoint.Top => Vector2.down,
                    AttachPoint.Bottom => Vector2.up,
                    AttachPoint.Left => Vector2.right,
                    AttachPoint.Right => Vector2.left,
                    _ => Vector2.zero
                };

                Vector2 offset = Vector2.Scale(v, GetScaledDimensions() * 0.5f);

                transform.localPosition = offset;

                Debug.Log("Attached");

            }
            else
            {
                Debug.LogWarning("Trying to attach Hand UI when already attached to another parent");
            }

        }

        /// <summary>
        /// Hides the canvas and clears its parent.
        /// Only succeeds if already attached to a transform.
        /// </summary>
        public void Detatch()
        {
            if (attached)
            {

                HideCanvas();

                transform.parent = initialParent;
                attached = false;

                Debug.Log("Detached");

            }
            else
            {
                Debug.LogWarning("Trying to detatch Hand UI whilst not currently attached");
            }
        }

        protected void ShowCanvas() => mainCanvas.gameObject.SetActive(true);
        protected void HideCanvas() => mainCanvas.gameObject.SetActive(false);

    }
}
