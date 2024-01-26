using UnityEngine;

public static class Randomizer 
{
    public static int random (int[] weight) {
        for(int i = 1; i < weight.Length; i++) {
            weight[i] += weight[i - 1];
        }
        //[20, 25, 30, 25] => [20, 45, 75. 100]

        int weight_r = UnityEngine.Random.Range(0, weight[weight.Length - 1]);
        for(int i = 0; i < weight.Length; i++) {
            if(weight_r < weight[i]) return i;
        }

        return 0;
    }
}