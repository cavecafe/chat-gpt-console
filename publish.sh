#!/bin/bash

string_list=("linux-arm64" "linux-x64" "osx-x64" "osx-arm64" "win-x64" "win-arm64")
index=0

while [[ $index -lt ${#string_list[@]} ]]; do
  dotnet publish -c Release -r ${string_list[$index]} -p:PublishSingleFile=true --self-contained true --output publish/${string_list[$index]}/
  rm publish/${string_list[$index]}/*.json
  rm publish/${string_list[$index]}/*.pdb
  index=$((index + 1))
done
