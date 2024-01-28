using UnityEngine;

public static class Randomizer 
{
    public static int random (int[] weight) {
        int total = 0;
        for(int i = 0; i < weight.Length; i++) {
            total += weight[i];
        }
        //[20, 25, 30, 25] => total: 100

        int weight_r = UnityEngine.Random.Range(0, total);
        Debug.Log($"{total}, Random Weight: {weight_r}");
        for(int i = 0; i < weight.Length; i++) {
            weight_r -= weight[i];
            if(weight_r < 0) return i;
        }

        return 0;
    }
}