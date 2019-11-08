@echo off
echo Execute update scripts 

cd updates

for %%f in (*.*) do mysql -u "%1" --password="%2" "%3" < "%%f"

cd ..
echo End execute update scripts