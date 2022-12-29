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

*  OSX (Apple Silicons M1, M2): [osx-arm64](/publish/osx-arm64/chat-gpt) 
 (SHA256: 6d5c727d250ecfa5ec0961bbc9cab57cf3043a39f419b797ccb9179cc336dc7b)
*  OSX (Intel): [osx-x64](/publish/osx-x64/chat-gpt)
 (SHA256: ac300611fe14381c77c032a9e0fb3b440af4e8c5ffeff7d613fe5459b3863e35)
*  Linux (Intel): [linux-x64](/publish/linux-x64/chat-gpt)
 (SHA256: 5e0a9349f19ebb32e3c064145724261ba489ecf618ecbd878e8fc03b103f9a26)
*  Linux (ARM): [linux-arm64](/publish/linux-arm64/chat-gpt) 
 (SHA256: 2c9039977ed2a31fc9079be734f71c479af468a5d53d7987eece6081bd1b817d)
*  Windows (Intel): [win-x64](/publish/win-x64/chat-gpt.exe)
 (SHA256: fd38b3cb52650d3bee4659bd3d7286678b5d7c02464c918241e7a8de2a2ae832)
*  Windows (ARM): [win-arm64](/publish/win-arm64/chat-gpt.exe)
 (SHA256: 0ba011f8b347b06a14c43bd2f4373fde4f765935c759877dd52b30fee4e46541)
	
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