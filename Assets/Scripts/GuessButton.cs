using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class GuessButton : MonoBehaviour {

    //連携するGameObject
    public ToggleGroup toggleGroup;

    /// ボタンをクリックした時の処理
    public void OnClick()
    {
        foreach (Transform child in toggleGroup.transform)
        {
            Debug.Log("selected " + child.gameObject.GetComponentInChildren<Text>().text);
        }
    }
}
