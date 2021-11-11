package main

func main() {
	print(maxProfit([]int{7, 1, 5, 3, 6, 4}))
}

func maxProfit(prices []int) int {
	min := prices[0]
	profit := 0
	for i := 1; i < len(prices); i++ {
		// 找出最低價格
		if min > prices[i] {
			min = prices[i]
		}
		// 現在的價錢賣出是否可以獲得更高的獲利
		currentProfit := prices[i] - min
		if currentProfit > profit {
			profit = currentProfit
		}
	}
	return profit
}
