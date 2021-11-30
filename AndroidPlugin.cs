using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Android;
using System.IO;

public class AndroidPlugin : MonoBehaviour
{
    public static AndroidPlugin instance;
    private static AndroidJavaObject Kotlin;
   
    private (Texture2D _tex, Sprite _spr) CallBack = (null, null);


    private void Awake()
    {
        Kotlin = new AndroidJavaObject("com.example.myapplication9.unityPlugin");
       
    
             
        instance = this;
    }

    public IEnumerator ShowGallery(UnityAction<Texture2D, Sprite> val)
    {
        Kotlin.Call("Open");
        yield return new WaitUntil(predicate: () => CallBack._tex != null && CallBack._spr!=null);
        val(CallBack._tex, CallBack._spr);
        CallBack = (null, null);
    }

    public IEnumerator ShowContacts()
    {
        Kotlin.Call("Open");
      
        yield return null;
    }

    public static void CallAndroidMethod(string methodName, string name,string email, string phone)
    {
        using (var clsUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) // "com.pingtech.swingtracker.UnityPlayerActivity"))
        {
            using (var objActivity = clsUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
            {
                objActivity.Call(methodName, name, email,phone);
               
               
            }
        }
    }

    public static void sendStr(string name, string email, string phone)
    {
#if !UNITY_EDITOR
#if UNITY_ANDROID
      // CallAndroidMethod("nameActive", str);
      CallAndroidMethod("Open", name,email,phone);
      
#endif
#endif
    }
    private void getImage(string path)
    {
        var www = new WWW("file:/" + path);
        var _tex = www.texture;
        var _spr = Sprite.Create(_tex,new Rect(0,0,_tex.width,_tex.height),new Vector2(0.5f,0.5f),100);
        Debug.Log("Path: " + path);

        Debug.Log("WWW: " + www);
       // ImageUse.instance.Im.sprite = www.texture;
        CallBack = (_tex, _spr);
    }

   
    /*  public string GetGalleryPath(string directoryPath)
      {

          if (false == Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
          {
              return string.Empty;
          }
          string galleryPath = string.Empty;
          string persistentDataPath = Application.persistentDataPath;
          galleryPath = persistentDataPath.Substring(0, persistentDataPath.IndexOf("Android")) + string.Format("/DCIM/{0}/", directoryPath);

          if (false == string.IsNullOrEmpty(directoryPath) && false == Directory.Exists(directoryPath))
          {
              Directory.CreateDirectory(directoryPath);
          }




          Debug.Log("Gallery Path :" + galleryPath);

          return galleryPath;
      }*/
}
