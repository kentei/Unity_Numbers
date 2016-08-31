using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class ToggleTest : MonoBehaviour
{

    //連携するGameObject
    public ToggleGroup toggleGroup;

    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void onClick()
    {
        //Get the label in activated toggles
        var selectedToggle = toggleGroup.ActiveToggles().First();

        //gameObject.SetActive(false);
        selectedToggle
                .GetComponentsInChildren<Text>()
                .First(t => t.name == "Label").text = gameObject.GetComponentInChildren<Text>().text;

        //もしトグルが全てOFFになっていたら何もしない
        if (selectedToggle == null) return;

        var selectedLabel =
            selectedToggle
                .GetComponentsInChildren<Text>()
                .First(t => t.name == "Label").text; //Labelが取れないと例外になる（むしろ例外を出すべきと判断してFirst)
        //string selectedLabel = toggleGroup.ActiveToggles()
        //    .First().GetComponentsInChildren<Text>()
        //    .First(t => t.name == "Label").text;

        Debug.Log("selected " + selectedLabel);

    }
}