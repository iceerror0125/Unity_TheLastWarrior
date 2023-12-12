using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SkillSlot : MonoBehaviour
{
    [SerializeField] private Transform left;
    [SerializeField] private Transform right;
    [SerializeField] private Transform up;
    [SerializeField] private Transform down;

    public Transform Left  => left;
    public Transform Right => right;
    public Transform Up => up;
    public Transform Down => down;
      

}
