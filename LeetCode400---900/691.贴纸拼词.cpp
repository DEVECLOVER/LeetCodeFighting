/*
 * @lc app=leetcode.cn id=691 lang=cpp
 *
 * [691] 贴纸拼词
 */

// @lc code=start
class Solution {
public:
//第一步 想到了字符计数  用map存储
//联想动态规划 状态转移方程如何推导呢
    #define INF INT_MAX
    int minStickers(vector<string>& stickers, string target) {
        vector<int> dp(1 << 15, INF);
        int n = stickers.size(), m = target.size();
        vector<vector<int>> cnt(n, vector<int>(26));
        for (int i = 0; i < n; ++i)
            for (char c : stickers[i])
                cnt[i][c - 'a']++;
        
        dp[0] = 0;
        for (int i = 0; i < (1 << m); ++i) {
            if (dp[i] == INF)
                continue;
            for (int k = 0; k < n; ++k) {
                int nxt = i;
                vector<int> left(cnt[k]);
                for (int j = 0; j < m; ++j) {
                    if (nxt & (1 << j))
                        continue;
                    if (left[target[j] - 'a'] > 0) {
                        nxt += (1 << j);
                        left[target[j] - 'a']--;
                    }
                }
                dp[nxt] = min(dp[nxt], dp[i] + 1);
            }
        }
        return dp[(1 << m) - 1] == INF ? -1 : dp[(1 << m) - 1];
    }

};
// @lc code=end

