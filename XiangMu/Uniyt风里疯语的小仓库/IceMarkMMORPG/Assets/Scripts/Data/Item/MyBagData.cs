﻿using System;
//-------------------------------
//该Demo由风冻冰痕所写
//http://icemark.cn/blog
//转载请说明出处
//-------------------------------
using System.Collections.Generic;
using UnityEngine;

public class MyBagData
{
    public DataEvent.UpdateBagData OnUpdateBagData;

    private Dictionary<int, DataItem> _consumableDict;  //key为格子索引，value为物品信息
    private Dictionary<int, DataItem> _materialDict;    //key为格子索引，value为物品信息
    private Dictionary<int, DataItem> _equipmentDict;   //key为格子索引，value为物品信息

    /*
    物品数量，之所以单独用一个Dictionary存数量是因为在
    项目中会经常需要用到数量比如物品合成判断数量是否足
    够，背包重量显示，不可能每次都去遍历整个背包
    */
    private Dictionary<int, int> _countDict;            //key为id，value为数量
    /*
    记录负重量的作用：
    1.背包显示
    2.负重超过一定百分比就不能再添加新东西（未实现）
    3.负重影响玩家的行动
    */
    private int _nowWeight;             //当前的负重量
    private int _maxWeight = 999;       //最大的负重量

    public MyBagData()
    {
        _countDict = new Dictionary<int, int>();
        /*
        呃，这里只是手动把每个背包里面的数据加进来
        实际项目中肯定是通过与服务端通信获取
        */
        _consumableDict = new Dictionary<int, DataItem>();
        _consumableDict.Add(0, new DataItem(10001, 77));
        UpdateItemCount(10001, 77);
        _consumableDict.Add(1, new DataItem(10002, 2));
        UpdateItemCount(10002, 2);
        _consumableDict.Add(2, new DataItem(10003, 3));
        UpdateItemCount(10003, 3);
        _consumableDict.Add(4, new DataItem(10001, 63));
        UpdateItemCount(10001, 63);

        _materialDict = new Dictionary<int, DataItem>();
        _materialDict.Add(0, new DataItem(20001, 4));
        UpdateItemCount(20001, 4);
        _materialDict.Add(1, new DataItem(20002, 5));
        UpdateItemCount(20002, 5);
        _materialDict.Add(2, new DataItem(20003, 6));
        UpdateItemCount(20003, 6);

        _equipmentDict = new Dictionary<int, DataItem>();
        _equipmentDict.Add(0, new DataItem(30001, 7));
        UpdateItemCount(30001, 7);
        _equipmentDict.Add(1, new DataItem(30002, 8));
        UpdateItemCount(30002, 8);
        _equipmentDict.Add(2, new DataItem(30003, 9));
        UpdateItemCount(30003, 9);
    }

    /// <summary>
    /// 处理Item的拖动
    /// </summary>
    /// <param name="bagType">背包类型</param>
    /// <param name="indexFrom">原始Item</param>
    /// <param name="indexTo">目标Item</param>
    public void DragItem(int bagType, int indexFrom, int indexTo)
    {
        Dictionary<int, DataItem> itemDict = GetItemDictByBagType(bagType);
        //原Item存在，开始更新数据
        if (itemDict.ContainsKey(indexFrom))
        {
            //目标Item存在，交换数据
            if (itemDict.ContainsKey(indexTo))
            {
                //ID相同的话合并Item
                if (itemDict[indexFrom].Id == itemDict[indexTo].Id)
                {
                    int countFrom = itemDict[indexFrom].Count;
                    int countTo = itemDict[indexTo].Count;
                    if (countFrom + countTo <= 99)
                    {
                        itemDict[indexFrom].AddCount(countTo);
                        itemDict.Remove(indexTo);
                    }
                    else
                    {
                        itemDict[indexFrom] = new DataItem(itemDict[indexTo].Id, countFrom + countTo - BaseConfig.maxItemCount);
                        itemDict[indexTo] = new DataItem(itemDict[indexFrom].Id, BaseConfig.maxItemCount);
                    }
                }
                else
                {
                    DataItem temp = itemDict[indexFrom];
                    itemDict[indexFrom] = itemDict[indexTo];
                    itemDict[indexTo] = temp;
                }
            }
            else    //否则就移动数据
            {
                itemDict[indexTo] = itemDict[indexFrom];
                itemDict.Remove(indexFrom);
            }
        }
        //通知背包窗口更新对应的Item
        if (OnUpdateBagData != null) OnUpdateBagData(bagType, indexFrom);
        if (OnUpdateBagData != null) OnUpdateBagData(bagType, indexTo);
    }

    /// <summary>
    /// 根据背包类型来获取Item的列表
    /// </summary>
    /// <param name="bagType">背包类型[0:消耗][1:材料][2:装备]</param>
    /// <returns></returns>
    public Dictionary<int, DataItem> GetItemDictByBagType(int bagType)
    {
        switch (bagType)
        {
            case 0: return _consumableDict;
            case 1: return _materialDict;
            case 2: return _equipmentDict;
        }
        return null;
    }

    /// <summary>
    /// 获取指定背包类型的空格子
    /// </summary>
    /// <param name="bagType"></param>
    /// <returns></returns>
    public int GetEmptyIndex(int bagType)
    {
        Dictionary<int, DataItem> itemDict = GetItemDictByBagType(bagType);
        for (int i = 0; i < 30; i++)
        {
            if (!itemDict.ContainsKey(i)) return i;
        }
        return -1;
    }

    /// <summary>
    /// 往背包内添加Item
    /// </summary>
    /// <param name="id">ID</param>
    /// <param name="count">数量</param>
    public void AddItemToBag(int id, int count)
    {
        if (GameConfig.items.ContainsKey(id))
        {
            int bagType = GameConfig.items[id].bagType;
            Dictionary<int, DataItem> itemDict = GetItemDictByBagType(bagType);
            int index = GetEmptyIndex(bagType);
            if (index > 0)
            {
                itemDict.Add(index, new DataItem(id, count));
                UpdateItemCount(id, count);
                if (OnUpdateBagData != null) OnUpdateBagData(bagType, index);
            }
            else
            {
                Debug.LogError("背包已满");
            }
        }
        else
        {
            Debug.LogError("ID不存在");
        }
    }

    /// <summary>
    /// 整理背包
    /// </summary>
    /// <param name="bagType"></param>
    public void ArrangeBag(int bagType)
    {
        Dictionary<int, DataItem> itemDict = GetItemDictByBagType(bagType);
        Dictionary<int, DataItem> dict = new Dictionary<int, DataItem>();
        //根据ID合并掉相同的Item
        foreach (DataItem item in itemDict.Values)
        {
            if (dict.ContainsKey(item.Id))
            {
                dict[item.Id].AddCount(item.Count);
            }
            else
            {
                dict.Add(item.Id, item);
            }
        }
        //将Dict转换成List并排序
        List<DataItem> list = new List<DataItem>();
        foreach (DataItem item in dict.Values)
        {
            if (item.Count > BaseConfig.maxItemCount)
            {
                int groupCount = item.Count / BaseConfig.maxItemCount;
                int surplusCount = item.Count % BaseConfig.maxItemCount;
                for (int i = 0; i < groupCount; i++)
                {
                    list.Add(new DataItem(item.Id, BaseConfig.maxItemCount));
                }
                list.Add(new DataItem(item.Id, surplusCount));
            }
            else
            {
                list.Add(item);
            }
        }
        list.Sort();

        itemDict.Clear();
        for (int i = 0; i < list.Count; i++)
        {
            itemDict.Add(i, list[i]);
        }
        if (OnUpdateBagData != null) OnUpdateBagData(bagType, -1);//-1表示更新所有Item
    }

    /// <summary>
    /// 在对物品进行增删操作的时候更新保存数量的Dictionary
    /// </summary>
    /// <param name="id">物品ID</param>
    /// <param name="count">改变的数量，为正则加，为负则减</param>
    private void UpdateItemCount(int id, int count)
    {
        _nowWeight += (count * GameConfig.items[id].weight);
        if (_countDict.ContainsKey(id))
        {
            _countDict[id] += count;
        }
        else
        {
            _countDict.Add(id, count);
        }
        if (_countDict[id] < 0) throw new Exception("物品数量异常 ID:" + id);
    }

    public Dictionary<int, int> CountDict { get { return _countDict; } }

    public int NowWeight { get { return _nowWeight; } }

    public int MaxWeight { get { return _maxWeight; } }
}