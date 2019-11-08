@echo off

echo Start create database from scratch:

echo Start create database
mysql -u "%1" --password="%2" -e "DROP DATABASE IF EXISTS %3;"
mysql -u "%1" --password="%2" -e "CREATE DATABASE %3;"
echo End create database

echo Start create tables 
mysql -u "%1" --password="%2" "%3" < "schema.sql"
echo End create tables 

echo Start fill initial data
mysql --default-character-set=utf8 -u "%1" --password="%2" "%3" < "ref_data.sql"
echo End fill initial data 

echo End creating database from scratch

echo Execute update scripts 
cd updates
for %%f in (*.*) do mysql -u "%1" --password="%2" "%3" < "%%f"
cd ..
echo End execute update scripts

echo Start fill test data
mysql --default-character-set=utf8 -u "%1" --password="%2" "%3" < "test_data.sql"
echo End fill test data