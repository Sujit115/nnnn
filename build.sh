#!/bin/sh
docker build -t leapspark ./src/Leapspark
docker build -t leapspark-api ./src/Leapspark.Api
docker build -t leapspark-web ./src/Leapspark.Web
docker build -t leapspark-hub ./src/Leapspark.Hub
docker build -t leapspark-gateway ./src/Leapspark.Gateway

