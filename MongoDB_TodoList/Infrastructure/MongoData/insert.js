use db_todoList;

db.createCollection("UserInfo");
db.createCollection("TodoList");
db.createCollection("UpdateLog");

db.UserInfo.insert({
    "UserName": "admin123",
    "Password": "E10ADC3949BA59ABBE56E057F20F883E",
    "NickName": "Edwin",
    "HeadPortrait": "https://images.cnblogs.com/cnblogs_com/Can-daydayup/1976329/o_210517164541myMpQrcode.png",
    "Email": "1070342164@qq.com",
    "Status": 1,
    "CreateTime": ISODate("2023-02-10T14:56:45.531Z"),
    "UpdateTime": ISODate("2023-02-10T14:56:45.531Z")
});

db.TodoList.insert({
    "UserId": "63949e2d9f602f6bdcc35208",
    "Content": "今天任务熟记100个英语单词",
    "ExpirationTime": ISODate("2023-02-10T14:56:45.531Z"),
    "IsRemind": true,
    "RemindTime": ISODate("2023-02-10T14:56:45.531Z"),
    "CompleteStatus": 0,
    "CreateTime": ISODate("2023-02-10T14:56:45.531Z"),
    "UpdateTime": ISODate("2023-02-10T14:56:45.531Z")
});

db.UpdateLog.insert({
    "UpdateContent": "系统界面优化升级",
    "CreateTime": ISODate("2023-02-10T14:56:45.531Z"),
    "UpdateTime": ISODate("2023-02-10T14:56:45.531Z")
});