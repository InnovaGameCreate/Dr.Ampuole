using UnityEngine;

namespace Player.Scope
{
    public class ScopeCamera : MonoBehaviour
    {
        private void FixedUpdate()
        {
            ChangeScopeForward();
        }

        private void ChangeScopeForward()
        {
            var mousePos = Input.mousePosition;
            mousePos.z = 1.0f;
            var mousePos3d = Camera.main.ScreenToWorldPoint(mousePos);
            transform.LookAt(mousePos3d);
        }
    }
}