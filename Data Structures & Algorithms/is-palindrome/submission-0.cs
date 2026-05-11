public class Solution {
    public bool IsPalindrome(string s) {
    
   
string pattern = "[^a-zA-Z0-9]"; // The '^' inside brackets means "NOT"
string result = Regex.Replace(s, pattern, "").ToLower();
 int left=0;int right=result.Length-1;
    while (left<right)
    {
        
        if(result[left]!=result[right])
            return false;
        left++;
        right--;    
    }

    return true;

    }
}
