# SuperFox
练练手de 游戏日志

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



2019.8.16

研究了一下午，原来这个穿模问题的学名叫 “collision tunneling ”

是个老大难问题鸭，试了两个办法

1.让地面变成触发器

2.将运动物体 `Rigidbody`组件的属性`Collision Detection`设置为`Continuous`

好了很多，但是还是有一点问题





2019.8.26

一直在看Ti9，LGD今年是真的技不如人＋心态不好，只能说恭喜OG

加了个射线检测效果总体还不错



2019.8.28

使用[Physics2D](https://docs.unity3d.com/ScriptReference/Physics2D.html).OverlapCircleAll来检测是否到达地面 还是有瑕疵，头疼





2019.9.4

看来还是得用unity自带的重力才行啊

练手练得差不多了  准备开始做原创了  

