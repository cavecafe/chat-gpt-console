#!/bin/bash

string_list=("linux-arm64" "linux-x64" "osx-arm64" "osx-x64" "win-x64" "win-arm64")
string_bin_list=("chat-gpt" "chat-gpt" "chat-gpt" "chat-gpt" "chat-gpt.exe" "chat-gpt.exe")

index=0

while [[ $index -lt ${#string_list[@]} ]]; do
  dotnet publish -c Release -r ${string_list[$index]} -p:PublishSingleFile=true --self-contained true --output publish/${string_list[$index]}/
  shasum -a 256 publish/${string_list[$index]}/${string_bin_list[$index]}
  rm publish/${string_list[$index]}/*.json
  rm publish/${string_list[$index]}/*.pdb
  index=$((index + 1))
done
