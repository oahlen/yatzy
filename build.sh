#!/usr/bin/env bash

dotnet restore
rm -rf publish
dotnet publish -c Release -o publish

podman build -t yatzy .
mkdir -p output
# docker image save -o output/yatzy yatzy
