public class TimeMap {
    private class TimeEntry {
        public int Timestamp { get; set; }
        public string Value { get; set; }
    }

    private Dictionary<string, List<TimeEntry>> map;

    public TimeMap() {
        map = new Dictionary<string, List<TimeEntry>>();
    }
    
    public void Set(string key, string value, int timestamp) {
        if (!map.ContainsKey(key)) {
            map[key] = new List<TimeEntry>();
        }
        map[key].Add(new TimeEntry { Timestamp = timestamp, Value = value });
    }
    
    public string Get(string key, int timestamp) {
        if (!map.ContainsKey(key)) {
            return "";
        }
        
        List<TimeEntry> list = map[key];
        int low = 0;
        int high = list.Count - 1;
        string result = "";
        
        // Binary search for the right-most timestamp <= target timestamp
        while (low <= high) {
            int mid = low + (high - low) / 2;
            
            if (list[mid].Timestamp <= timestamp) {
                result = list[mid].Value; // Found a valid timestamp, keep searching for a closer one
                low = mid + 1;
            } else {
                high = mid - 1;
            }
        }
        
        return result;
    }
}
