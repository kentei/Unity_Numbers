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
        //var selectedToggle = toggleGroup.ActiveToggles().First();
        foreach (Transform child in toggleGroup.transform)
        {
            //name = child.gameObject.name;
            Debug.Log("selected " + child.gameObject.GetComponentInChildren<Text>().text);
            //if (name.Contains(idx_st1.ToString()))
            //{ // e.g. "SelP1", "SelP2"...
            //    selected = child.gameObject.GetComponent(typeof(Toggle)) as Toggle;
            //    break;
            //}
        }
    }
}
