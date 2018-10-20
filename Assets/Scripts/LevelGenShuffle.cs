using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelGenShuffle{

    //NOT MY CODE!!!
    //Fisher-Yates Shuffle https://stackoverflow.com/questions/273313/randomize-a-listt
    //Changed a little to use with unity

    public static void Shuffle<T>(this IList<T> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
