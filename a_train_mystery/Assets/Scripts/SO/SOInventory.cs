using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Inventory")]
public class SOInventory : ScriptableObject
{
    public List<Slot> inventorySlots = new List<Slot>();
    int stackLimit = 2;
    public void addItem(SOItem item)
    {
        foreach (Slot slot in inventorySlots)
        {
            if (slot.item == item)
            {
                if (slot.itemCount < stackLimit)
                {
                    slot.itemCount++;
                    break;
                }
            }
            else if(slot.isFull == false)
            {
                slot.AddItemSlot(item);
                slot.isFull = true;
                break;
            }
        }
    }

}


[System.Serializable]
public class Slot
{
    public bool isFull;
    public int itemCount;
    public SOItem item;

    public void AddItemSlot(SOItem item)
    {
        this.item = item;
        isFull = true;
        itemCount++;
    }

}
