using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryData
{
    public string equipId;
    public List<string> stashId;

    public InventoryData (string equipId, List<string> stashId)
    {
        this.equipId = equipId;
        this.stashId = stashId;
    }

}
