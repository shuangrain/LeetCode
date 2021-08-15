package main

import "log"

func main() {
	log.Print(twoSum([]int{2, 7, 11, 15}, 9))
}

func twoSum(nums []int, target int) []int {
	results := make([]int, 2)
	hashMap := make(map[int]int, len(nums))
	for i, num := range nums {
		if idx, exists := hashMap[nums[i]]; exists {
			results[0] = idx
			results[1] = i
			break
		} else {
			hashMap[target-num] = i
		}
	}
	return results
}
