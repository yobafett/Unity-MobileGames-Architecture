using UnityEditor;
using UnityEngine;

namespace CodeBase.Editor
{
  public class Tools 
  {
    [MenuItem("Tools/ClearPrefs")]
    public static void ClearPrefs()
    {
      PlayerPrefs.DeleteAll();
      PlayerPrefs.Save();
    }
  }
}
