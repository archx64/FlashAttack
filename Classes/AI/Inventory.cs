using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int rawEnergy = 5;
    public int quantizedEnergy = 0;
    //[SerializeField] int drawOffset = 0;
    public string itemName = "";

    //private void OnGUI()
    //{
    //    GUI.Box(new Rect(0, 0 + drawOffset, 100, 100), "" + itemName);
    //    GUI.Label(new Rect(10, 20 + drawOffset, 100, 20), "Flour: " + rawEnergy);
    //    GUI.Label(new Rect(10, 35 + drawOffset, 100, 20), "Bread: " + quantizedEnergy);
    //}
}
