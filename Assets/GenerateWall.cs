using UnityEngine;
using UnityEditor;
 
static class GenerateWall
{
    [MenuItem("GenerateWall/Generate")]
    private static void Generate()
    {
        GameObject source = (GameObject)Selection.objects[0];
        for (int i = 0; i < 100; i++)
        {
            GameObject newObj = (GameObject)PrefabUtility.InstantiatePrefab(source);
            newObj.transform.parent = source.transform.parent;
            newObj.transform.position += Vector3.up * i;
        }
    }
}