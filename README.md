# chat-gpt-console

## A simple app to use ChatGPT in terminal

 ![Logo](project-logo.png)
 

### Build from source:

```bash 
> dotnet publish \
  -c Release \
  -r {your CPU type} \ 
  -p:PublishSingleFile=true \ 
  --self-contained true \
  --output publish/{your CPU type}/ ⏎
```
  
whereas *{your CPU type}* is the one of the following values, 

*  osx-arm64: OSX (Apple Silicons M1, M2)
*  osx-x64: OSX (Intel)
*  linux-x64: Linux (Intel)
*  linux-arm64: Linux (ARM)
*  win-x64: Windows (Intel)
*  win-arm64: Windows (ARM)

	
### Download it from the repo:

*  Linux (ARM): [linux-arm64](/publish/linux-arm64/chat-gpt) 
 (SHA256: c23783a7ca09641d3355f693c24f267d8ac78ade782acb47d5e46e03139c0660)
*  Linux (Intel): [linux-x64](/publish/linux-x64/chat-gpt)
 (SHA256: 2bc9b30cf81ed9a45efd443c285e4fb09149c64e1908d6f127d77281bc9df847)
 
*  OSX (Apple Silicons M1, M2): [osx-arm64](/publish/osx-arm64/chat-gpt) 
 (SHA256: c13ce7a61f181fac886e112e02eefe4797ee3b0fc39403137fe1299ba5ce69ca)
*  OSX (Intel): [osx-x64](/publish/osx-x64/chat-gpt)
 (SHA256: 36928c039ac36f079033450aa4121e9832ac6105c472decfcda8018650505ef5)

*  Windows (Intel): [win-x64](/publish/win-x64/chat-gpt.exe)
 (SHA256: 712b1097d9f9861a77ce253f07127dc386a4c3a8bc8b5df162cb6809e1af38d5)
*  Windows (ARM): [win-arm64](/publish/win-arm64/chat-gpt.exe)
 (SHA256: 7c60386006fe649fd455078e4540db011e11b599b15563cfd4d4965bf7b8b570)
	
Of couse you will need to give the permission to execute the file

```bash
 > chmod u+x chat-gpt ⏎
 > ./chat-gpt ⏎
```

 
 For Mac, go to 'System Settings -> Privacy & Security',
 Press 'Allow Anyway'
 
 
### How to get your API KEY from OpenAI.org
 ![How to get your API KEY](how-to-get-your-own-API-KEY.png)
 
 For the first run, it will ask your API KEY, to store it to the 'appsettings.json' like the following.
 
 ```javascript
 {
  "OpenAI": {
    "ApiKey": "{your own OpenAPI key}",
    "Model": "text-davinci-003",
    "EndPoint": "https://api.openai.com/v1/completions"
  }
 }
 ```

### How to setup your own API KEY
 ![How to setup your own API KEY](chat-gpt_first-run.png)

 
### Run on Windows
 ![Run on Windows](windows-terminal.png)
 
### To do
* Working on mobile app versions'
* Various format of response types (images, links, code blocks, etc.) 


### Disclaimer:

> This software is provided 'as-is', without any express or implied warranty. In no event will the authors be held liable for any damages arising from the use of this software.

> Please note that this software has not been thoroughly tested and may contain bugs or errors. Use at your own risk. The authors make no guarantees or warranties regarding the use or functionality of this software."

> You can customize this disclaimer text to suit your specific needs and requirements. For example, you can add a clause stating that the software is provided "as is" and that the authors are not responsible for any damages or losses resulting from the use of the software. You can also include a statement that the software is provided "without any warranties or guarantees of any kind," to make it clear that you are not making any promises about the performance or reliability of the software.

> It's important to include a disclaimer in your open source project to protect yourself and your contributors from liability and to clearly communicate the limitations and risks of using the software. This can help to manage expectations and ensure that users understand the potential risks and limitations of the software.