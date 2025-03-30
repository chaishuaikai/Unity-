using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Text;

public class Editor_FbxExporter : EditorWindow
{

    private static Editor_FbxExporter _window;

    private string fbxname = "";
    private string path = "";
    GameObject[] meshObjs = null;

    [MenuItem ("Tools/导出模型")]
    public static void GUIDRefReplaceWin()
    {
        Rect wr = new Rect (0, 0, 300, 200);
        // true 表示不能停靠的
        _window = (Editor_FbxExporter)GetWindowWithRect (typeof (Editor_FbxExporter),wr, true, "导出FBX");
        _window.Show ();

    }
    void OnGUI()
    {
        if (meshObjs != Selection.gameObjects)
        {
            fbxname = "";
            meshObjs = Selection.gameObjects;
        }
        
        if (meshObjs.Length!=0)
        {
            GUILayout.Label ("当前选择物体名字 : " + meshObjs[0].name);
            if (fbxname=="")
            {
                fbxname = "Fbx_"+meshObjs[0].name;
            }
            fbxname = EditorGUILayout.TextField ("导出FBX名字：", fbxname);

            GUILayout.Label ("导出路径为Assets目录");
            if (GUILayout.Button ("开始导出"))
            {
                FBXExporter.ExportFBX (path, fbxname, meshObjs, true);
            }
        }
        else
        {
            fbxname = "";
            GUILayout.Label ("先选中物体");
        }
    }
}
