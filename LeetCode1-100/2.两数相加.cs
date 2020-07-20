/*
 * @lc app=leetcode.cn id=2 lang=csharp
 *
 * [2] 两数相加
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
 public  class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int data)
        {
            val = data;
            next = null;
        }
    }
public class Solution {
    public ListNode head = null;
    public void AddElement(int data)
    {
        ListNode datanode = new ListNode(data);
        if (head == null)
        {
            head = datanode;
            return;
        }
        ListNode tempnode = head;
        while (tempnode.next != null)
        {
            tempnode = tempnode.next;
        }
        tempnode.next = datanode;
    }
    public ListNode AddTwoNumbers(ListNode num1,ListNode num2) {
            if (num1 == null || num2 == null)
            {
                return null;
            }
            ListNode tempnode1 = num1;
            ListNode tempnode2 = num2;
            ListNodeSum resultnode = new ListNodeSum();
            byte carrybit = 0;
            int singlenum = 0;
            while (tempnode1 != null && tempnode2!= null)
            {
                singlenum = tempnode1.val + tempnode2.val + carrybit;
                if (singlenum > 9)
                {
                    carrybit = 1;
                    singlenum = singlenum - 10;
                    resultnode.AddElement(singlenum);
                    if (tempnode1.next == null && tempnode2.next == null)
                    {
                        resultnode.AddElement(1);
                    }
                }
                else
                {
                    carrybit = 0;
                    resultnode.AddElement(singlenum);
                }
                tempnode1 = tempnode1.next;
                tempnode2 = tempnode2.next;
            }
            while (tempnode1 != null)
            {
                singlenum = tempnode1.val + carrybit;
                if (singlenum > 9)
                {
                    carrybit = 1;
                    resultnode.AddElement(singlenum - 10);
                    if (tempnode1.next == null)
                    {
                        resultnode.AddElement(1);
                    }
                }
                else
                {
                    carrybit = 0;
                    resultnode.AddElement(singlenum);
                }
                tempnode1 = tempnode1.next;
            }
            while (tempnode2 != null)
            {
                singlenum = tempnode2.val + carrybit;
                if (singlenum > 9)
                {
                    carrybit = 1;
                    resultnode.AddElement(singlenum - 10);
                    if (tempnode2.next == null)
                    {
                        resultnode.AddElement(1);
                    }
                }
                else
                {
                    carrybit = 0;
                    resultnode.AddElement(singlenum);
                }
                tempnode2 = tempnode2.next;
            }
            return resultnode.head;
    }
}
// @lc code=end

