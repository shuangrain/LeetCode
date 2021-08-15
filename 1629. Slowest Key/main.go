package main

import "log"

func main() {
	log.Print(string(slowestKey([]int{9, 29, 49, 50}, "cbcd")))
}

func slowestKey(releaseTimes []int, keysPressed string) byte {
	var maxDuraionTime int
	var maxDuraionKeyPressed byte

	for i, releaseTime := range releaseTimes {
		var currentDuraionTime int
		if i == 0 {
			currentDuraionTime = releaseTime - 0
		} else {
			currentDuraionTime = releaseTime - releaseTimes[i-1]
		}

		if (currentDuraionTime > maxDuraionTime) || (currentDuraionTime == maxDuraionTime && keysPressed[i] > maxDuraionKeyPressed) {
			maxDuraionTime = currentDuraionTime
			maxDuraionKeyPressed = keysPressed[i]
		}
	}
	return maxDuraionKeyPressed
}
