using UnityEngine;
using UnityEditor;

public class MenuItems
{
    [MenuItem("Tools/Clear PlayerPrefs %#d")]
    private static void NewMenuOption()
    {
        PlayerPrefs.DeleteAll();
    }
}
