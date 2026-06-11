// Definition for a pair
// public class Pair {
//     public int Key;
//     public string Value;
//
//     public Pair(int key, string value) {
//         Key = key;
//         Value = value;
//     }
// }

public class Solution {
    public List<List<Pair>> InsertionSort(List<Pair> pairs) {
        List<List<Pair>> states = new List<List<Pair>>();
        
        for (int i = 0; i < pairs.Count; i++) {
            Pair current = pairs[i];
            int j = i - 1;
            
            // Shift elements of the sorted portion that have a key greater than current.Key
            while (j >= 0 && pairs[j].Key > current.Key) {
                pairs[j + 1] = pairs[j];
                j--;
            }
            
            // Insert the current element into its correct position
            pairs[j + 1] = current;
            
            // Capture a snapshot of the list after this insertion step
            states.Add(new List<Pair>(pairs));
        }
        
        return states;
    }
}

