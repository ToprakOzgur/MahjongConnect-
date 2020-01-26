using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumberGenerator : MonoBehaviour
{
    public static List<int> ShuffleList(List<int> list)
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            int randomIndex = Random.Range(i, list.Count);
            int tempItem = list[randomIndex];
            list[randomIndex] = list[i];
            list[i] = tempItem;
        }
        return list;
    }
}
