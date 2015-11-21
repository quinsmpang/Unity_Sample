﻿using System;
using UnityEngine;

public class DataShop : IComparable
{
    private _unit_of_items _data;
    private int _id;
    private int _count;

    public DataShop(int id, int count)
    {
        if (!GameConfig.items.ContainsKey(id))
        {
            Debug.LogError("ID为" + id + "的物品不存在！");
            return;
        }
        _id = id;
        _count = count;
        _data = GameConfig.items[id];
    }

    public int CompareTo(object obj)
    {
        int result = 1;
        DataItem data = (DataItem)obj;
        result = _id.CompareTo(data.Id);
        if (result != 0) return result;
        return data.Count.CompareTo(_count);
    }

    public void AddCount(int count)
    {
        _count += count;
    }

    public int Id { get { return _data.id; } }

    public string Icon { get { return _data.icon; } }

    public string Name { get { return _data.name; } }

    public int Type { get { return _data.type; } }

    public int Count { get { return _count; } }
}