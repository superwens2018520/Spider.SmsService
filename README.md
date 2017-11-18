# Spider.SmsService
Spider Sms Service

# 项目结构
项目主要由如下几个部分组成
1.	短信服务器（Spider.SmsService）
主要负责从access 数据库中读取数据，分析数据，
然后将数据库中原本的数据结构转换成新数据结构进行保存

2.	短信客户端 （Spider.SmsClient）
主要用来从短信服务器中查询 并且显示出解析过后的短信内容

3.	短信服务器和短信客户端通讯协议（Spider.CommandApi）
里面包含client 和server 之前要使用到的通讯协议 和接口

4.	短信服务器测试（Spider.SmsServiceTests）
测试短信服务器的基本功能



# 数据库文件 简单描述
/DB/
#SMS.
|id|number|content|time|imsi|iccid|simnum

#Devices
|id|Comport|phonum|imsi|iccid|imei

在描述中不存在但是在数据库中存在的字段 忽视


具体实现的内容 ：


扩展帮助文件 
http://www.wavecomcn.com/help/162.html
使用新酷卡软件实现外部短信发送使用说明

