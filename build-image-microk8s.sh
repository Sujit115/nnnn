#!/bin/sh
./build.sh
mkdir images
docker save leapspark > ./images/leapspark.tar
docker save leapspark-api > ./images/leapspark-api.tar
docker save leapspark-web > ./images/leapspark-web.tar
docker save leapspark-hub > ./images/leapspark-hub.tar
docker save leapspark-gateway > ./images/leapspark-gateway.tar
microk8s ctr image import ./images/leapspark.tar
microk8s ctr image import ./images/leapspark-api.tar
microk8s ctr image import ./images/leapspark-gateway.tar
microk8s ctr image import ./images/leapspark-hub.tar
microk8s ctr image import ./images/leapspark-web.tar