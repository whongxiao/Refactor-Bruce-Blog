# BruceBlog重构
　　学习开源软件NHibernate时，阅读过一本英文书籍 NHibernate In Action，希望利用书上知识开发一个项目进行练习，因此下载了BruceBlog程序源码进行学习。
利用书中描述的三层结构方式，对原程序进行了重构，感谢原作者stulife贡献了源代码。 
　　为了帮助更多的NHibernate研究者，我们也决定将重构的代码进行开源，开源使用了Apache License。 项目详情请参看 http://qvancang.com/blog/opensource/refactorbruceblog

注： 下载本项目后， 请为Blog web 项目添加引用 FredCK.FCKeditorV2.dll， 此文件在NHibernateDLL project的DLL目录下

作者：Allen

BruceBlog程序源码(采用NHibernate)

博客程序是一个单用户博客程序，基于Asp.net技术
使用了ORM数据持久框架NHibernate
使用最简单的Access文件数据库（App_Data下为Access数据库文件）开发完成的
前台页面全部采用Div + Css，网页编辑器采用的是fckEditor
后台主要栏目：发表文章 评论管理 logo设置 理 大类管理 友情链接 修改密码 
后台管理地址：admin/login.aspx，默认帐号/密码：51aspx/51aspx

原作者：stulife
