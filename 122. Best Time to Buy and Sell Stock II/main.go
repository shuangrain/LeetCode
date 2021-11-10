package main

func main() {
	print(maxProfit([]int{3, 2, 6, 5, 0, 3}))
}

func maxProfit(prices []int) int {
	min := prices[0]
	profit := 0
	for i := 1; i < len(prices); i++ {
		// 找出最低價格
		if min > prices[i] {
			min = prices[i]
		}
		// 計算賣出後的價格是否大於零
		// 若大於零則累計獲利並將 min 賦予當前的股價
		// 下次買進時的日期才不會與賣出日期重複
		currentProfit := prices[i] - min
		if currentProfit > 0 {
			min = prices[i]
			profit += currentProfit
		}
	}
	return profit
}
