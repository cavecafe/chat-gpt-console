# chat-gpt-console
ChatGPT as console app

For deployment:

> dotnet publish -c Release -r win-x64 -p:PublishSingleFile=true --self-contained {false or true}
> dotnet publish -c Release -r osx-x64 -p:PublishSingleFile=true --self-contained {false or true}
> dotnet publish -c Release -r linux-x64 -p:PublishSingleFile=true --self-contained {false or true}

