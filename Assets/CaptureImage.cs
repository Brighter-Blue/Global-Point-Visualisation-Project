using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CaptureImage : MonoBehaviour

{
    public Camera cam;
    public RenderTexture rt;
    public string fileName = "Render.png";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Capture();
        }
    }

    public void Capture()
    {
        string downloads = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + "\\Downloads";
        string fileName = "Render_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
        string path = System.IO.Path.Combine(downloads, fileName);

        ScreenCapture.CaptureScreenshot(path, 4); // 4x super resolution

        Debug.Log("Saved to " + path);
    }
}

