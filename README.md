# chat-gpt-console

## ChatGPT as a console app




### For deployment out of source:

 > dotnet publish 
  -c Release 
  -r *{win-x64 or win-arm64 osx-x64 or osx-arm64 or linux-x64 or linux-arm64}* 
  -p:PublishSingleFile=true 
  --self-contained true
  --output publish/*{win-x64 or win-arm64 osx-x64 or osx-arm64 or linux-x64 or linux-arm64}*/
	
### Download it from the repo:

*  OSX (Apple Silicons M1, M2): [osx-arm64](/publish/osx-arm64/chat-gpt)
*  OSX (Intel): [osx-x64](/publish/osx-x64/chat-gpt)
*  Linux (Intel): [linux-x64](/publish/linux-x64/chat-gpt)
*  Linux (ARM): [linux-arm64](/publish/linux-arm64/chat-gpt)
*  Windows (Intel): [win-x64](/publish/win-x64/chat-gpt.exe)
*  Windows (ARM): [win-arm64](/publish/win-arm64/chat-gpt.exe)

