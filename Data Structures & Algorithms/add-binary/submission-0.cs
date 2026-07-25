public class Solution {
    public string AddBinary(string a, string b) {
        StringBuilder result = new StringBuilder();
        int i = a.Length - 1;
        int j = b.Length - 1;
        int carry = 0;

        // Process both strings from right to left
        while (i >= 0 || j >= 0 || carry > 0) {
            int sum = carry;

            // Add bit from string a if available
            if (i >= 0) {
                sum += a[i] - '0';
                i--;
            }

            // Add bit from string b if available
            if (j >= 0) {
                sum += b[j] - '0';
                j--;
            }

            // Append the remainder (current bit position value)
            result.Append(sum % 2);

            // Calculate the new carry
            carry = sum / 2;
        }

        // Reverse the string builder to get the correct order
        char[] charArray = result.ToString().ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
