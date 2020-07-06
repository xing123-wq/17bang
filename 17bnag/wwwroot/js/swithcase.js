//写一段代码，能根据一起帮用户的帮帮点（bCredit）输出他对应的等级（可适度精简）
//一起帮用户被分为5种，每种都有一个整数代号：
//0：访客
//1：注册用户
//2：文章发布者
//3：管理员
//4：超级管理员
//写一段代码，用switch...case将代号转换成文字输出，但3和4都统称“管理员”即可

//万一是字符串的3了
//var bCredit = '3';
//万一是包含3的字符了
//var bCredit = '35';
//var bCredit = 0;
//switch (bCredit) {
//    case 0:     //if(weekday == 1)
//        console.log('访客');
//        break;  //:和break类似于 {}
//    case 1:     //else if(weekday == 1)
//        console.log('注册用户');
//        break;
//    //省略....
//    case 2:
//        console.log('文章发布者');
//        break;
//    case 3:
//    case 4:
//        console.log('管理员');
//        break;
//    default:    //兜底的else 
//        console.log('没有当前权限');
//        break;
//}