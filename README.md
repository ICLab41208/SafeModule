# SafeModule
SafeModule.dll (資安防護程式)
Default.aspx.cs (範例檔案)


簡易說明如下 ↓

1	將SafeModule.dll複製到網站 .\bin

2	在需要保護的網頁(如範例：Example.aspx.cs)中Page_Load函式加入程式碼，例如：【SafeModule.JSONHelper.Deserialize<Machine>(json)】，該網頁即可防禦非法攻擊。

  
