# chat-gpt-console

## A simple app to use ChatGPT in terminal

 ![Logo](project-image.png)

### Disclaimer:

> This software is provided 'as-is', without any express or implied warranty. In no event will the authors be held liable for any damages arising from the use of this software.

> Please note that this software has not been thoroughly tested and may contain bugs or errors. Use at your own risk. The authors make no guarantees or warranties regarding the use or functionality of this software."

> You can customize this disclaimer text to suit your specific needs and requirements. For example, you can add a clause stating that the software is provided "as is" and that the authors are not responsible for any damages or losses resulting from the use of the software. You can also include a statement that the software is provided "without any warranties or guarantees of any kind," to make it clear that you are not making any promises about the performance or reliability of the software.

> It's important to include a disclaimer in your open source project to protect yourself and your contributors from liability and to clearly communicate the limitations and risks of using the software. This can help to manage expectations and ensure that users understand the potential risks and limitations of the software.


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
*  OSX (Intel): [osx-x64](/publish/osx-x64/chat-gpt)
*  Linux (Intel): [linux-x64](/publish/linux-x64/chat-gpt)
*  Linux (ARM): [linux-arm64](/publish/linux-arm64/chat-gpt)
*  Windows (Intel): [win-x64](/publish/win-x64/chat-gpt.exe)
*  Windows (ARM): [win-arm64](/publish/win-arm64/chat-gpt.exe)

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
 