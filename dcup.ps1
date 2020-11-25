Set-StrictMode -Version 3.0
$ErrorActionPreference = "Stop"

& "docker-compose" up --build --remove-orphans

#https://docs.docker.com/compose/reference/up/
#docker-compose up
#docker-compose up --build
#docker-compose up --build --remove-orphans
#docker-compose up --build --remove-orphans -d
#docker-compose config