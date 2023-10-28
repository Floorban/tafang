using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject itemSlotPrefab;
    public GameObject dragDropPrefab;
    public Transform itemSlotsParent; // Assign the ItemSlotsParent GameObject in the Inspector
    public Transform dragDropsParent; // Assign the DragDropsParent GameObject in the Inspector
    public int numberOfPairs = 5;

    void Start()
    {
        // Instantiate all the ItemSlots under the ItemSlotsParent
        for (int i = 0; i < numberOfPairs; i++)
        {
            // Define positions where you want to instantiate each pair
            Vector3 itemSlotPosition = new Vector3(i * 100, 0, 0); // Adjust the position as needed

            // Instantiate ItemSlot
            GameObject instantiatedItemSlot = Instantiate(itemSlotPrefab, itemSlotPosition, Quaternion.identity);
            instantiatedItemSlot.transform.SetParent(itemSlotsParent, false);
        }

        // Instantiate all the DragDrops under the DragDropsParent
        for (int i = 0; i < numberOfPairs; i++)
        {
            // Define positions where you want to instantiate each pair
            Vector3 dragDropPosition = new Vector3(i * 100, -100, 0); // Adjust the position as needed

            // Instantiate DragDrop
            GameObject instantiatedDragDrop = Instantiate(dragDropPrefab, dragDropPosition, Quaternion.identity);
            instantiatedDragDrop.transform.SetParent(dragDropsParent, false);
        }
    }
}
