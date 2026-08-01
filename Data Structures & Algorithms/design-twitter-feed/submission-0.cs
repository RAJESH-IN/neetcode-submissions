public class Twitter {
    // Helper class to store tweet details
    private class Tweet {
        public int Id { get; set; }
        public int Time { get; set; }
        public Tweet(int id, int time) {
            Id = id;
            Time = time;
        }
    }

    private int timestamp;
    private Dictionary<int, HashSet<int>> following;
    private Dictionary<int, List<Tweet>> tweets;

    public Twitter() {
        timestamp = 0;
        following = new Dictionary<int, HashSet<int>>();
        tweets = new Dictionary<int, List<Tweet>>();
    }
    
    public void PostTweet(int userId, int tweetId) {
        if (!tweets.ContainsKey(userId)) {
            tweets[userId] = new List<Tweet>();
        }
        // Increment global timer and record tweet
        tweets[userId].Add(new Tweet(tweetId, timestamp++));
    }
    
    public List<int> GetNewsFeed(int userId) {
        List<Tweet> feedCandidates = new List<Tweet>();

        // 1. Add user's own tweets
        if (tweets.ContainsKey(userId)) {
            // Only take the last 10 tweets to optimize performance
            feedCandidates.AddRange(tweets[userId].TakeLast(10));
        }

        // 2. Add tweets from people they follow
        if (following.ContainsKey(userId)) {
            foreach (int followeeId in following[userId]) {
                if (tweets.ContainsKey(followeeId)) {
                    feedCandidates.AddRange(tweets[followeeId].TakeLast(10));
                }
            }
        }

        // 3. Sort by timestamp descending and take the top 10
        return feedCandidates
            .OrderByDescending(t => t.Time)
            .Select(t => t.Id)
            .Take(10)
            .ToList();
    }
    
    public void Follow(int followerId, int followeeId) {
        // A user cannot follow themselves
        if (followerId == followeeId) return;

        if (!following.ContainsKey(followerId)) {
            following[followerId] = new HashSet<int>();
        }
        following[followerId].Add(followeeId);
    }
    
    public void Unfollow(int followerId, int followeeId) {
        if (following.ContainsKey(followerId)) {
            following[followerId].Remove(followeeId);
        }
    }
}
