# NGDataStorage
一个类似于Android上SharedPreference的.Net数据存储方案

### 使用方法
将Release中的dll引用进项目中，把Example.xml放在需要存储数据的地方，然后在需要使用的地方using NGDataStorage即可。
  
### 读取
```
NGData gData = new NGData(Environment.CurrentDirectory + @"\Example.xml");
String strData = gData.GetString("IP_Addr");
Boolean boolData = gData.GetBoolean("NightMode");
int intData = gData.GetInt("Level")
```
  
### 保存
```
NGDataEditor editor = new NGDataEditor(Environment.CurrentDirectory + @"\Example.xml");
editor.PutString("IP_Addr", "127.0.0.1");
editor.PutBoolean("NightMode", false);
editor.PutInt("Level", 9);
```
