docker container stop identity-server
docker container stop api-one
docker container rm identity-server
docker container rm api-one
docker image rm nisal/identity-server
docker image rm nisal/api-one