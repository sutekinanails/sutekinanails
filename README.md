# sutekinanails

All developement for beauty services, named by the first beauty project.

## updating service on sutekinanails server

ssh sutekinanails
docker run -v /apps/suteservice:/data -p 8080:8080 --restart unless-stopped -d sutekinanails/suteservice:latest
