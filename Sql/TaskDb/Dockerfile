FROM mcr.microsoft.com/mssql/server:2019-latest
# Create scripts directory
WORKDIR /usr/src/app
# move the scripts
COPY . /usr/src/app

ENTRYPOINT /bin/bash ./entrypoint.sh