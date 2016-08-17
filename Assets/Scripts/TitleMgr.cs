using UnityEngine;
using System.Collections;

public class TitleMgr : MonoBehaviour {
    private GUIStyle titleStyle;

    void Start()
    {
        titleStyle = new GUIStyle();
        titleStyle.fontSize = 30;
    }

    void OnGUI()
    {
        // フォントの位置
        float w = 100; // 幅
        float h = 30; // 高さ
        float px = Screen.width / 2 - w / 2;
        float py = Screen.height / 2 - h / 2;
        titleStyle.fontSize = 30;
        GUI.Label(new Rect(px, py - 50, w, h), "Numbers", titleStyle);
        GUI.Button(new Rect(px, py, w, h), "ニューゲーム");
        GUI.Button(new Rect(px, py + 50, w, h), "設定");
    }
}
