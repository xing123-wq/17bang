//猜数字
function findNumber(min, max) {
    confirm(`弹出游戏玩法说明，等待用户点击“确认”，开始游戏；
             浏览器生成一个不大于1000的随机正整数；
             用户输入猜测；
             如果用户没有猜对，浏览器比较后告知结果：“大了”或者“小了”。如果用户：
             只用了不到6次就猜到，弹出：碉堡了！
             只用了不到8次就猜到，弹出：666！
             用了8 - 10次猜到，弹出：猜到了。
             用了10次都还没猜对，弹出：^ (*￣(oo) ￣) ^`)
    bing(random(min, max) + '');//调用函数

}
function random(min, max) {
    return Math.floor(Math.random() * (max - min)) + min;
}
function bing(binggo) {
    for (var i = 1; i < 10; i++) {
        var word = prompt("输入你的猜测");
        if (!isNaN(word) && word > 0 && word.indexOf(".") === -1) {
            if (word === binggo) {
                if (i < 6) {
                    alert("碉堡了!");
                } else if (i < 8) {
                    alert("666!");
                } else if (i >= 10) {
                    alert("^ (*￣(oo) ￣) ^`");
                } else {
                    alert("猜到了!");
                }
                break;
            } else
                if (word > binggo) {
                    alert("大了");
                } else {
                    alert("小了");
                }
        } else {
            alert("请输入正整数");
        }
    }
}