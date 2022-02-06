using UnityEngine;
using UnityEngine.InputSystem;

public class ScreenshotManager : MonoBehaviour
{
    public string baseFileName = "screenshot.png";

    public InputAction takeScreenshot;

    public void OnTakeScreenshot()
    {
        ScreenCapture.CaptureScreenshot(baseFileName);
    }

    private void Awake()
    {
        takeScreenshot.performed += ctx => OnTakeScreenshot();
    }

    private void OnEnable()
    {
        takeScreenshot.Enable();
    }

    private void OnDisable()
    {
        takeScreenshot.Disable();
    }
}
