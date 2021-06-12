using System;
using System.Collections.Generic;
using System.Linq;

namespace Programming_Assignment_2_Summer_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question1:
            Console.WriteLine("Question 1");
            int[] nums1 = { 2, 5, 1, 3, 4, 7 };
            int[] nums2 = { 2, 1, 4, 7 };
            Intersection(nums1, nums2);
            Console.WriteLine("");

            //Question 2 
            Console.WriteLine("Question 2");
            int[] nums = { 0, 1, 0, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question3
            Console.WriteLine("Question 3");
            int[] ar3 = { 2, 2, 3, 4};
            int Lnum = LuckyNumber(ar3);
            if (Lnum == -1)
                Console.WriteLine("Given Array doesn't have any lucky Integer");
            else
                Console.WriteLine("Lucky Integer for given array {0}", Lnum);

            Console.WriteLine();

            //Question 4
            Console.WriteLine("Question 4");
            Console.WriteLine("Enter the value for n:");
            int n = Int32.Parse(Console.ReadLine());
            int Ma = GenerateNums(n);
            Console.WriteLine("Maximun Element in the Generated Array is {0}", Ma);
            Console.WriteLine();

            //Question 5

            Console.WriteLine("Question 5");
            List<List<string>> cities = new List<List<string>>();
            cities.Add(new List<string>() { "London", "New York" });
            cities.Add(new List<string>() { "New York", "Tampa" });
            cities.Add(new List<string>() { "Delhi", "London" });
            string Dcity = DestCity(cities);
            Console.WriteLine("Destination City for Given Route is : {0}", Dcity);

            Console.WriteLine();

            //Question 6
            Console.WriteLine("Question 6");
            int[] Nums = { 2, 3, 4 };
            int target_sum = 6;
            targetSum(Nums, target_sum);
            Console.WriteLine();

            //Question 7
            Console.WriteLine("Question 7");
            int[,] scores = { { 1, 91 }, { 1, 92 }, { 2, 93 }, { 2, 97 }, { 1, 60 }, { 2, 77 }, { 1, 65 }, { 1, 87 }, { 1, 100 }, { 2, 100 }, { 2, 76 } };
            HighFive(scores);
            Console.WriteLine();

            //Question 8
            Console.WriteLine("Question 8");
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            int K = 3;
            RotateArray(arr, K);
            Console.WriteLine(arr);

            //Question 9
            Console.WriteLine("Question 9");
            int[] arr9 = { 5, 4, -1, 7, 8 }; 
            int Ms = MaximumSum(arr9);
            Console.WriteLine("Maximun Sum contiguous subarray {0}", Ms);
            Console.WriteLine();

            //Question 10
            Console.WriteLine("Question 10");
            int[] costs = { 10, 15, 20 };
            int minCost = MinCostToClimb(costs);
            Console.WriteLine("Minium cost to climb the top stair {0}", minCost);
            Console.WriteLine();
        }

        //Question 1
        /// <summary>
        //Given two integer arrays nums1 and nums2, return an array of their intersection.
        //Each element in the result must be unique and you may return the result in any order.
        //Example 1:
        //Input: nums1 = [1,2,2,1], nums2 = [2,2]
        //Output: [2]
        //Example 2:
        //Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
        //Output: [9,4]
        //
        /// </summary>

        public static void Intersection(int[] nums1, int[] nums2)
        {
            try
            {
                // Sort items in nums1 and nums2
                Array.Sort(nums1);
                Array.Sort(nums2);

                // Remove duplicated items from arrays.
                HashSet<int> newNums1 = new HashSet<int>(nums1);
                HashSet<int> newNums2 = new HashSet<int>(nums2);

                // Take the intersection of newNums1 and newNums2.
                List<int> intersect= new List<int>();
                intersect = newNums1.Intersect(newNums2).ToList();

                // Print each item in the intersection list.
                foreach (int i in intersect)      
                {
                    Console.Write(i);
                    Console.WriteLine();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 2:
        /// <summary>
        //Given a sorted array of distinct integers and a target value, return the index if the target is found.If not, return the index where it would be if it were inserted in order.
        //Note: You must write an algorithm with O(log n) runtime complexity.
        //Example 1:
        //Input: nums = [1, 3, 5, 6], target = 5
        //Output: 2
        //Example 2:
        //Input: nums = [1, 3, 5, 6], target = 2
        //Output: 1
        //Example 3:
        //Input: nums = [1, 3, 5, 6], target = 7
        //Output: 4
        //Example 4:
        //Input: nums = [1, 3, 5, 6], target = 0
        //Output: 0
        /// </summary>

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                // Use binary selection, identiry left end, right end, and mid point.
                int left = 0;
                int right = nums.Length - 1;
                int mid=0;
               
                while(left<=right)
                {
                     
                    mid =  (left+right) / 2; // Locate the mid point.
                  
                    // If the target number is less than mid point, take it to the left part.
                   // Otherwise, continue with the right part.
                    if (target<nums[mid]) 
                    {
                        right = mid - 1;
                    }
                    else if (target>nums[mid])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        return mid;
                    }
                }
                return -1;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Question 3
        /// <summary>
        //Given an array of integers arr, a lucky integer is an integer which has a frequency in the array equal to its value.
        //Return a lucky integer in the array. If there are multiple lucky integers return the largest of them. If there is no lucky integer return -1.
        //Example 1:
        //Input: arr = [2, 2, 3, 4]
        //Output: 2
        //Explanation: The only lucky number in the array is 2 because frequency[2] == 2.
        /// </summary>

        private static int LuckyNumber(int[] nums)
        {
            try
            {
                // Creat a list called count which has less than 500 items.
                int[] count = new int[501];
                // Bring every item in nums to the count list.
                for (int i = 0; i < nums.Length; i++)
                {
                    count[nums[i]]++;   
                }                
                for (int i = nums.Length; i > 0; i--)
                {
                    if (count[i] == i) // If the number itself equals its position in the list, return lucky number.
                    {
                        return i;
                    }
                }
                return -1;// No lucky number exists.
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 4:
        /// <summary>
        //You are given an integer n.An array nums of length n + 1 is generated in the following way:
        //•	nums[0] = 0
        //•	nums[1] = 1
        //•	nums[2 * i] = nums[i]  when 2 <= 2 * i <= n
        //•	nums[2 * i + 1] = nums[i] + nums[i + 1] when 2 <= 2 * i + 1 <= n
        // Return the maximum integer in the array nums.

        //Example 1:
        //Input: n = 7
        //Output: 3
        //Explanation: According to the given rules:
        //nums[0] = 0
        //nums[1] = 1
        //nums[(1 * 2) = 2] = nums[1] = 1
        //nums[(1 * 2) + 1 = 3] = nums[1] + nums[2] = 1 + 1 = 2
        //nums[(2 * 2) = 4] = nums[2] = 1
        //nums[(2 * 2) + 1 = 5] = nums[2] + nums[3] = 1 + 2 = 3
        //nums[(3 * 2) = 6] = nums[3] = 2
        //nums[(3 * 2) + 1 = 7] = nums[3] + nums[4] = 2 + 1 = 3
        //Hence, nums = [0, 1, 1, 2, 1, 3, 2, 3], and the maximum is 3.

        /// </summary>
        private static int GenerateNums(int n)
        {
            try
            {
                if (n == 0)//If user input is 0, there will be 0+1=1 item in the array, thus the maximum number will be 0.
                {
                    return 0;
                }
                if (n == 1)// If user inputs 1, 1+1=2 items are in the array. [0,1] Thus the maximum number is 1.
                {
                    return 1;
                }
                int[] nums = new int[n + 1]; // Creat a list called nums which contains all the items.
                nums[0] = 0;
                nums[1] = 1;
                for (int i = 1; i <= (n - 1) / 2; i++)// If i=0, 2*0=0 it's meanless, thus start from i=1.
                {
                    nums[2 * i] = nums[i];
                    nums[2 * i + 1] = nums[i] + nums[i + 1];
                }
                int result = 0;
                for (int i = 0; i <= n; i++) // Find the maximum number in the nums list.
                {
                    result = Math.Max(nums[i], result);
                }               
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        //Question 5
        /// <summary>
        //You are given the array paths, where paths[i] = [cityAi, cityBi] means there exists a direct path going from cityAi to cityBi.Return the destination city, that is, the city without any path outgoing to another city.
        //It is guaranteed that the graph of paths forms a line without any loop, therefore, there will be exactly one destination city.
        //Example 1:
        //Input: paths = [["London", "New York"], ["New York","Lima"], ["Lima","Sao Paulo"]]
        //Output: "Sao Paulo" 
        //Explanation: Starting at "London" city you will reach "Sao Paulo" city which is the destination city.Your trip consist of: "London" -> "New York" -> "Lima" -> "Sao Paulo".
        /// </summary>
        public static string DestCity(List<List<string>> paths)
        {
            try
            {               
                List<string> left = new List<string>();// create a list includes input cities that are on the left.
                List<string> right = new List<string>();// create a list includes input cities that are on the right.
                for (int i = 0; i < paths.Count; i++)
                {
                    left.Add(paths[i][0]);// Add the first item in the ith path to left list. 
                    right.Add(paths[i][1]);// Add the second item in the ith path to left list. 
                }
                for (int i = 0; i < right.Count; i++)
                {
                    if (left.Contains(right[i]))
                    {
                        continue; // go through the right list and find the item that does not have a match in the left list.
                    }
                    return right[i];
                }
                return "";
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Question 6:
        /// <summary>
        //Given an array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number.
        //Print the indices of the two numbers (1-indexed) as an integer array answer of size 2, where 1 <= answer[0] < answer[1] <= numbers.Length.
        //You may not use the same element twice, there will be only one solution for a given array
        //Example 1:
        //Input: numbers = [2,7,11,15], target = 9
        //Output: [1,2]
        //Explanation: The sum of 2 and 7 is 9. Therefore index1 = 1, index2 = 2.

        /// </summary>
        private static void targetSum(int[] nums, int target)
        {
            try
            {
                if (nums.Length==0) return;
                int i = 0;// first item in the array, counting to the right.
                int j = nums.Length - 1;//Last item in the array, counting to the left.
                while (i < j)
                {
                    int sum = nums[i] + nums[j]; // start from two ends of the array, sum up the most left and most right items
                    if (sum == target)// if the sum equals to the target number, return to the output.
                    {
                         Console.WriteLine( i+1+"," +(j+1) );
                        break;
                    }
                    else if (sum > target)// If the sum is greater than the target,                                        
                    {                     // let j move the the next item on the left(take a smaller j).
                        j--;
                    }
                    else
                    {
                        i++;// If the sum is less than the target,let i move the the next item on the right(take a greater i).
                    }
                }
                return;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 7
        /// <summary>
        /// Given a list of the scores of different students, items, where items[i] = [IDi, scorei] represents one score from a student with IDi, calculate each student's top five average.
        /// Print the answer as an array of pairs result, where result[j] = [IDj, topFiveAveragej] represents the student with IDj and their top five average.Sort result by IDj in increasing order.
        /// A student's top five average is calculated by taking the sum of their top five scores and dividing it by 5 using integer division.
        /// Example 1:
        /// Input: items = [[1, 91], [1,92], [2,93], [2,97], [1,60], [2,77], [1,65], [1,87], [1,100], [2,100], [2,76]]
        /// Output: [[1,87],[2,88]]
        /// Explanation: 
        /// The student with ID = 1 got scores 91, 92, 60, 65, 87, and 100. Their top five average is (100 + 92 + 91 + 87 + 65) / 5 = 87.
        /// The student with ID = 2 got scores 93, 97, 77, 100, and 76. Their top five average is (100 + 97 + 93 + 77 + 76) / 5 = 88.6, but with integer division their average converts to 88.
        /// Example 2:
        /// Input: items = [[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100]]
        /// Output: [[1,100],[7,100]]
        /// Constraints:
        /// 1 <= items.length <= 1000
        /// items[i].length == 2
        /// 1 <= IDi <= 1000
        /// 0 <= scorei <= 100
        /// For each IDi, there will be at least five scores.
        /// </summary>
        private static void HighFive(int[,] items)
        {
            try
            {
               // Array.Sort(items);

                List<int> lst = items.Cast<int>().ToList();
          


            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 8
        /// <summary>
        //Given an array, rotate the array to the right by k steps, where k is non-negative.
        //Print the Final array after rotation.
        //Example 1:
        //Input: nums = [1, 2, 3, 4, 5, 6, 7], k = 3
        //Output: [5,6,7,1,2,3,4]
        //Explanation:
        //rotate 1 steps to the right: [7,1,2,3,4,5,6]
        //rotate 2 steps to the right: [6,7,1,2,3,4,5]
        //rotate 3 steps to the right: [5,6,7,1,2,3,4]
        //Example 2:
        //Input: nums = [-1,-100,3,99], k = 2
        //Output: [3,99,-1,-100]
        //Explanation: 
        //rotate 1 steps to the right: [99,-1,-100,3]
        //rotate 2 steps to the right: [3,99,-1,-100]
        /// </summary>

        private static void RotateArray(int[] arr, int n)
        {
            try
            {
                var another = new int[arr.Length];       // Create a new array.
                for (var i = 0; i < arr.Length; i++)// Go through ever item in the origin array.
                {
                    var newIndex = (i + n) % arr.Length;
                    another[newIndex] = arr[i];       // If the origin position of an item is i, put it into the new array
                                                      // with position to be the remider of (i+1)/(length of arr).
                }

                for (var i = 0; i < arr.Length; i++)
                {
                    arr[i] = another[i]; // Copy new array to the origin array.
                    
                }   

                return;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 9
        /// <summary>
        //Given an integer array nums, find the contiguous subarray(containing at least one number) which has the largest sum and return its sum
        //Example 1:
        //Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
        //Output: 6
        //Explanation: [4,-1,2,1] has the largest sum = 6.
        //Example 2:
        //Input: nums = [1]
        //Output: 1
        // Example 3:
        // Input: nums = [5,4,-1,7,8]
        //Output: 23
        /// </summary>

        private static int MaximumSum(int[] arr)
        {
            try
            {
                int current = arr[0]; // Initialize the current sum and maximun sum.
                int maximum = arr[0];

                for (int i = 1; i < arr.Length; i++)
                {
                    current = Math.Max(arr[i], current + arr[i]); // Go throuth all items in the array.
                    maximum = Math.Max(maximum, current);// Only selet the range which has the greatest sum.
                }

                return maximum;

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 10
        /// <summary>
        //You are given an integer array cost where cost[i] is the cost of ith step on a staircase.Once you pay the cost, you can either climb one or two steps.
        //You can either start from the step with index 0, or the step with index 1.
        //Return the minimum cost to reach the top of the floor.
        //Example 1:
        //Input: cost = [10, 15, 20]
        //Output: 15
        //Explanation: Cheapest is: start on cost[1], pay that cost, and go to the top.

        /// </summary>

        private static int MinCostToClimb(int[] costs)
        {
            try
            {
                if (costs.Length < 3)
                {
                    return Math.Min(costs[0], costs[1]);
                }

                int result = 0;

                for (int i = 2; i < costs.Length; i++)  // Start from the third item (index[2].
                {                                       // (Because we can start taking steps from either index[0] or [1].
                    result = Math.Min(costs[i] + costs[i - 2], costs[i - 1]);
                    costs[i] = costs[i] + Math.Min(costs[i - 2], costs[i - 1]);
                }//Minimun cost to step on the ith step = the number at index[i] + take the smaller cost between taking 1 step or 2 steps.

                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
