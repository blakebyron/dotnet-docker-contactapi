#!/usr/bin/env bash
/opt/mssql/bin/sqlservr & setup_database.sh & sleep infinity & wait