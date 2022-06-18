using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;

    private void Awake() {
        if (instance != null)
        {
            Debug.LogError("There is more than one Equipment instance!!");
        }else
            instance = this;
    }
    #endregion

    public GameObject[] onEquipments;
    Equiment[] currentEquipments;
    Inventory inventory;

    //回调:装备更改时调用
    public delegate void OnEquipmentChanged(Equiment newItem, Equiment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    private void Start() {
        //小技巧：获取枚举某个类型的所有数量
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipments = new Equiment[numSlots];

        inventory = Inventory.instance;
    }
    
    public void Equip(Equiment newItem){
        //把新物品匹配到对应的枚举索引中
        //装备数组每个元素代表一种装备，而且数量各为1
        int slotIndex = (int)newItem.equipmentSlot;

        Equiment oldItem = null;

        if (currentEquipments[slotIndex] != null)
        {
            //如果替换掉原来的装备，将重新加载回数据库中
            oldItem = currentEquipments[slotIndex];
            inventory.Add(oldItem);
        }

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        currentEquipments[slotIndex] = newItem;
        onEquipments[slotIndex].SetActive(true);    //显示出来

    }

    public void Uneuip(int slotIndex){

        Equiment oldItem = null;
        if (currentEquipments[slotIndex] != null)
        {
            onEquipments[slotIndex].SetActive(false);
            oldItem = currentEquipments[slotIndex];
            inventory.Add(oldItem);

            currentEquipments[slotIndex] = null;
        }

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(null, oldItem);
        }
    }

    public void UnequipAll(){
        for (int i = 0; i < currentEquipments.Length; i++)
        {
            Uneuip(i);
        }
    }

    //装备的获取和卸下主要还是在Manager（小库存）和数据库（大库存）来进行交流
    private void Update() {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }
}
