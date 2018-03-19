

//用户名和密码动态效果公共方法

var commen = function (inputDom, labelDom, placeHolder1, placeHolder2, addClass) {

     inputDom.attr("placeholder", placeHolder1);
     inputDom.focus(function() {
         inputDom.attr("placeholder", placeHolder2);
         labelDom.addClass(addClass);
         labelDom.show();
     })

     inputDom.blur(function() {
         inputDom.attr("placeholder", placeHolder1);
         labelDom.hide();
     })
 }


 var userNameInput, userNameLabel, passwordInput, passwordLabel, placeholderPassword1, placeholderUserName1, placeholderPassword2, placeholderUserName2, focusUserClass, focusPasswordClass;

 //用户名
 commen($('#UserName'), $("label[for='userName']"), '用户名', '请输入用户名', 'layui-label-userfocus');
 //密码
 commen($("#Password"), $("label[for='password']"), '密码', '请输入密码', 'layui-label-passwordfocus')