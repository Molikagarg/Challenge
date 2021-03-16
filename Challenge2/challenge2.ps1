#Retrives the complete metadata in json format
$metadata = Invoke-RestMethod -Headers @{"Metadata"="true"} -Method GET -Proxy $Null -Uri "http://169.254.169.254/metadata/instance?api-version=2020-12-01" 
$metadata | ConvertTo-Json

# retrieves the specific data key (in this case Location)
$metadata.compute.location
