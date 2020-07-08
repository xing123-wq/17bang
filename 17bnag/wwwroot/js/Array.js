//完成：二分查找 / 快速排序（选做，参考：）

//将源栈同学姓名装入数组，再根据该数组输出所有同学，以及共有多少位同学
//var Name = ['阿泰', '王胖子', '李哥', '刘江平'];
//var sum;
//for (var i = 0; i < Name.length + 1; i++) {
//    sum = i;
//    console.log(Name[i]);
//}
//console.log(sum);

//声明一个数组odds，利用循环把100以内的奇数按从小到大的顺序存入其中
//计算从odds数组中所有元素的和
//找到数组中的最小值

//100以内包不包括100和0和负数
//和算不算负数
//最小值包不包括负数
//最小值的范围
function SeekOdd() {
    var odds = [];
    for (var i = 1; i < 100; i++) {
        if (Isodd(i)) {
            odds[i] = i;
        }
    }
    return odds;
}
function Min() {
    var min = 0;
    for (var i = 0; i < arguments.length; i++) {
        if (min > arguments[i]) {
            min = arguments[i];
        }
    }
    return min;
}

//输出1000以内的所有“素数”
//负数算不算素数
//有小数点算不算素数
function SeekPrime() {
    var PrimeArr = [1, 2, 3];
    for (var i = 4; i <= 1000; i++) {
        var IsPrime = true;
        for (var j = 2; j <= i / 2; j++) {
            if (i % j === 0) {
                IsPrime = false;
            }
        }
        if (IsPrime) {
            PrimeArr[i] = i;
        }
    }
    return PrimeArr;
}

function Isodd(numbers) {
    var whether = true;
    if (numbers % 2 === 0) {
        whether = false;
    }
    return whether;
}

//去除一个数组中重复的值（提示：仔细思考需求）
function daleteEcho() {
    for (var i = 0; i < arguments.length; i++) {
        if (arguments.indexOf(arguments[i]) === arguments[i]) {//inddexof取下标
            arguments.push(arguments[i])//把arr[i];数组推向hash=[];
        }
    }
    console.log(arguments)
}

//完成冒泡排序（必做，参考）
function BubbleSort() {
    for (var i = 0; i < arguments.length; i++) {
        for (var j = 0; j < arguments.length - i - 1; j++) {
            if (arguments[j] > arguments[j + 1]) {
                var a = arguments[j];
                arguments[j] = arguments[j + 1];
                arguments[j + 1] = a;
            }
        }
    }
    return arguments;
}
