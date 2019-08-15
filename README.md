# SuperFox
自己做个游戏奥de 游戏日志

2019.8.13
随便整理了一下素材，简单写了一下跳跃，不理想

2019.8.14
跳跃和移动搞得比较满意了，着手处理动画的播放 但是遇到问题了 难受

2019.8.15

动画的切换也搞得不错了

在做动画时遇到了优先级的问题，就是移动和跳跃的判断是不同的，如果玩家同时按下空格和方向键，这两个动画会互相冲突

参考了链接https://answers.unity.com/questions/787508/how-do-i-determine-the-priority-in-which-animation.html

Q:Say I have 2 transitions from one state to 2 other states. If both conditions on the transitions are true, then is there a way to set a priority on which transition I want to happen?

A：Played around with the animator and this functionality does exist. You just have to click on a state in the animator, and arrange the transitions in the inspector in the order you want to prioritize them. The top most transition will have the highest priority.

有趣的是 这个人是自问自答，真好！

目前的问题是，有点穿模，就是下落后，有时会半个身体卡在地里，不知道是为啥emmmmm