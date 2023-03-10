#!/bin/bash

docker build -t yatzy .
mkdir -p output
docker image save -o output/yatzy yatzy
