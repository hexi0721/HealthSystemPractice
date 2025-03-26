using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ScreenShotGH : MonoBehaviour
{
    // 看不出作用
    [SerializeField] Button screenShotButton;

    double compileTime;
    bool isCompling = false;


    private void Start()
    {
        screenShotButton.onClick.AddListener(() =>
        {
            ScreenCapture.CaptureScreenshot(Application.dataPath + "/CameraScreenShot.png");
        });
    }

    private void Update()
    {
        
        if (isCompling)
        {
            if (!EditorApplication.isCompiling)
            {
                isCompling = false;
                CompileFinished();
            }
            Debug.Log(1);
        }
        else
        {
            if (EditorApplication.isCompiling)
            {
                isCompling = true;
                CompileStarted();
            }
            Debug.Log(2);
        }


    }

    private void CompileStarted()
    {
        Debug.Log("Compile Started...");
        compileTime = EditorApplication.timeSinceStartup;
    }

    private void CompileFinished()
    {
        double finishedTime = EditorApplication.timeSinceStartup - compileTime;
        Debug.Log($"Compile TIme {finishedTime}");
    }
}
