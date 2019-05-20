# README

此程序是基于C#的对学生C++程序作业进行管理批阅的Windows桌面应用程序。

|Author|rayiooo|
|---|---|
|Email|rayiooo@foxmail.com|


## 使用方法

1. 导入的文件夹目录需要类似下面这样：

```
Homework
--张三（可以包含非中文字符，会自动去除）
----E1（作业号）
--李四
----E21
----E21-1（该作业会算作E21）
```

导入以上目录中的Homework即可。

2. 导入的根目录下需有文件`students.txt`，其中存储了学生学号和姓名，格式如下（以tab制表符隔开）：

```
201500001234	张三
201500002345	李四
```

3.每个学生每份作业文件夹下应将所有程序文件放置在同一级目录下，即不能包含子文件夹。编译时会将目录下所有`.cpp`文件编译，因此请仅包含一个`main`方法。

## 项目地址

[Github](https://github.com/rayiooo/Csharp_CppHomeworkManager)

[TencentCloud](https://dev.tencent.com/u/rayiooo/p/Csharp_EmailHomeworkManagement)

## 参考资料

[MinGW安装和使用 - 简书](https://www.jianshu.com/p/e9ff7b654c4a)