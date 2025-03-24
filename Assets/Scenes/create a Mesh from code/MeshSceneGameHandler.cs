using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class MeshSceneGameHandler : MonoBehaviour
{
    [SerializeField] Button changeButton1 , changeButton2 , changeButton3;
    [SerializeField] Material material;

    Vector2[] activateUV = new Vector2[4];

    private void Start()
    {

        Vector3[] vertices = new Vector3[4]
        {
            new Vector3(0, 0),
            new Vector3(1, 0),
            new Vector3(0, 1),
            new Vector3(1, 1),
        };

        int firstX = 1;
        int secondX = 49;
        int thirdX = 97;
        int firstY = 319;
        int width = 47;
        int height = 66;
        int textureWidth = 144;
        int textureHeight = 400;

        Vector2[] uv = GetUVRectangleFromPixel(firstX , firstY , width, height, textureWidth , textureHeight);

        int[] triangles = new int[6]
        {
            2 , 3 , 0 ,
            3 , 1 , 0
        };

        Mesh mesh = new Mesh();

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;


        GameObject gameObject = new GameObject("New GameObject", typeof(MeshFilter), typeof(MeshRenderer));
        gameObject.transform.localPosition = Vector3.zero;

        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.GetComponent<MeshRenderer>().material = material;

        changeButton1.onClick.AddListener(() => 
        {
            uv = GetUVRectangleFromPixel(secondX, 319, width, height, textureWidth, textureHeight);
            结ぉuv(uv,ref activateUV);
            mesh.uv = activateUV;

        });

        changeButton2.onClick.AddListener(() =>
        {
            uv = GetUVRectangleFromPixel(thirdX, 319, width, height, textureWidth, textureHeight);
            结ぉuv(uv, ref activateUV);
            mesh.uv = activateUV;

        });

        changeButton3.onClick.AddListener(() =>
        {
            uv = GetUVRectangleFromPixel(thirdX + width , 319, -width, height, textureWidth, textureHeight);
            结ぉuv(uv, ref activateUV);
            mesh.uv = activateUV;

        });

    }

    private Vector2 ConvertPixelToUVCoordinate(int x, int y, int textureWidth, int textureHeight)
    {
        return new Vector2((float)x / textureWidth, (float)y / textureHeight);
    }

    private Vector2[] GetUVRectangleFromPixel(int x, int y, int width, int height, int textureWidth, int textureHeight)
    {
        /** 0 , 0 **/
        /** 1 , 0 **/
        /** 0 , 1 **/
        /** 1 , 1 **/
        return new Vector2[]
        {
            ConvertPixelToUVCoordinate(x , y , textureWidth , textureHeight) ,
            ConvertPixelToUVCoordinate(x + width , y , textureWidth , textureHeight),
            ConvertPixelToUVCoordinate(x , y + height , textureWidth , textureHeight),
            ConvertPixelToUVCoordinate(x + width , y + height , textureWidth , textureHeight),
        };

    }

    private void 结ぉuv(Vector2[] uv , ref Vector2[] activateUV)
    {
        activateUV[0] = uv[0];
        activateUV[1] = uv[1];
        activateUV[2] = uv[2];
        activateUV[3] = uv[3];

    }


}
