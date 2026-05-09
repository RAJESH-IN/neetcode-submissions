public class Solution {
    public bool IsAnagram(string s, string t) {

     //Array.Sort(s.ToArray().ToString());
      //Array.Sort(t.ToArray().ToString());
        char[] s1=s.ToCharArray();
        char[] t1=t.ToCharArray();
        Array.Sort(t1);
        Array.Sort(s1);

      return new string(s1) == new string(t1);
    }
}
