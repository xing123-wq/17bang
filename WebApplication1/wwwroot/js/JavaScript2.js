﻿//var obj = { a: 8 };
//function double(array) {
//    array.a *= 2;
//}
//double(obj);
//console.log(obj.a);

//var b = 8;
//function double(number) {
//    number *= 2;
//}
//double(b);
//console.log(b);

////值传递，引用类型
//var sender;
//var greet = function (sender, words, receiver) {
//    if (sender === undefined) {
//        sender = `薛明林`;
//    }
//    if (receiver === undefined) {
//        receiver = `飞哥`;
//    }
//    if (words === null) {
//        words = `晕死`;
//    }

//    console.log(sender + "对" + receiver + "说:" + words);
//    return `贺仙人` + `王晓夫`;
//}
//var slogan = greet(`薛明林`, null);

////函数的声明
//function learn/*函数名*/(major, student/*标明参数*/) {
//    console.log(student + "学习了" + major);/*输出*//*方法体*/
//    return//返回值
//};
///*使用函数名调用函数*/learn(`javascript`, `阿泰`);
//var greet = function () {     //匿名函数
//    console.log("hello,源栈");
//};

////数组换位
//var arr = [8, 3];//下标（0，1）;
//function swap(arr, a, b) {
//    var temp = arr[a];
//    arr[a] = arr[b];
//    arr[b] = temp;
//}
//swap(arr, 0, 1);
//console.log(`arr[0]=` + arr[0]);
//console.log(`arr[1]=` + arr[1]);

////for..in循环
//var atai = {
//    name: `阿泰`,
//    age: 18
//};
//for (var item in atai) {
//    console.log(atai[item]);
//}

////es6,数组新特性
//var [name, age, female] = ['飞哥', 38, true];
//if (female) {
//    alert(`${age}岁的${name}真汉子`);
//}

////变量提升
//`use strict`;//严格模式
//function feige() {
//    sname = `飞哥`;//赋值
//    var words = `Hello,` + sname;
//    ;//console.log(x);
//    console.log(words);
//    //先声明，再使用
//    //赋值放在前面，声明放在后面。
//    var sname;//声明
//}
//feige();

//function blockscope() {
//    if (true) {
//        var i = 986;
//    }
//    console.log(`i=` + i);
//}
//blockscope()

//闭包
//function luckystack() {
//    var _price = 986;
//    return function () {
//        return _price;//返回值
//    }
//}
//var getPrice = luckystack();
//alert(`"源栈"培训的价格是每周${getPrice()}元!`);

////定时器
function greet(name) {
    console.log(`hello,` + name);
}
/*第一步*/
function delaycall(name) {
    var title = `学生`;//外部函数
    return function () {
        setTimeout(function () {
            greet(name + title);//内部函数调用外部函数title
        }, 2000);
    }
}
var result = delaycall(`阿泰`);
result();

/*第三步*/
//for (var i = 0; i < 10; i++) {
//    console.log(`i` + i);
//    var conter = 0;
//        /*var mutipleGreet =*/ setInterval(function () {
//        conter++;
//        //if (conter === 3) {
//        console.log(`conter;` + conter);
//        //    //clearInterval(mutipleGreet);
//        //}
//        greet(`阿泰`);
//    }, 5000);

//}
    console.log("after delaycall");

