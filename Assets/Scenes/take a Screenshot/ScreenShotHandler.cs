using UnityEngine;

public class ScreenShotHandler : MonoBehaviour
{
    // ±ó¥Î ¥\¯à©Ç²§


    private static ScreenShotHandler instance;
    Camera myCam;

    bool takeScreenShotOnNextFrame;

    private void Awake()
    {
        instance = this;
        myCam = GetComponent<Camera>();
    }

    private void OnPostRender()
    {
        if(takeScreenShotOnNextFrame)
        {
            takeScreenShotOnNextFrame = false;

            RenderTexture renderTexture = myCam.targetTexture;
            Texture2D renderResult = new Texture2D(renderTexture.width , renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderResult.width, renderResult.height);
            renderResult.ReadPixels(rect , 0 , 0);

            byte[] byteArray = renderResult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/CameraScreenShot.png" , byteArray);
            Debug.Log("Saved CameraScreenShot.png");

            RenderTexture.ReleaseTemporary(renderTexture);
            myCam.targetTexture = null;

        }
    }




    private void TakeScreenShot(int width , int height)
    {
        myCam.targetTexture = RenderTexture.GetTemporary(width, height , 16);
        
        takeScreenShotOnNextFrame = true;
    }

    public static void static_TakeScreenShot(int width , int height)
    {
        instance.TakeScreenShot(width , height);
    }

}
