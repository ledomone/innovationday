docker build . -t parcelinfo

docker run -d --rm --name parcelinfo -e ASPNETCORE_ENVIRONMENT="Development" -p 8080:80 parcelinfo:latest

http://localhost:8080/swagger/index.html

