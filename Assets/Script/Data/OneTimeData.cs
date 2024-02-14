using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OneTimeData
{
    public List<string> idList;

    public OneTimeData (string newId)
    {
        idList.Add(newId);
    }
    public OneTimeData (List<string> newList)
    {
        idList.AddRange(newList);
    }
}
