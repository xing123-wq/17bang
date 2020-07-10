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
function SeekOdd(number) {
    var odds = [];
    for (var i = 1; i < number; i++) {
        if (Isodd(i)) {
            odds.push(i);
        }
    }
    return odds;
}

function Min() {
    for (var i = 0; i < arguments.length; i++) {
        var min = arguments[i];
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
    var PrimeArr = [];
    for (var i = 1; i <= 1000; i++) {
        var IsPrime = true;
        for (var j = 1; j <= i / 2; j++) {
            if (i % j === 0) {
                IsPrime = false;
            }
        }
        if (IsPrime) {
            PrimeArr.push(i);
        }
    }
    return PrimeArr;
}

function Isodd(numbers) {
    if (numbers % 2 === 0) {
        return false;
    }
    return true;
}

//去除一个数组中重复的值（提示：仔细思考需求）


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
