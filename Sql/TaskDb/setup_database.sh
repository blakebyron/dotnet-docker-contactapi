#!/usr/bin/env bash
./wait-for-it.sh localhost --timeout=0 --strict -- sleep 5s && \
/opt/mssql-tools/bin/sqlcmd -S localhost -i setup.sql -U sa -P SuperStr0ngPa55word