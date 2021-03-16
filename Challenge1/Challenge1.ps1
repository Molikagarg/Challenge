az login 
az account set -s "<subscription-id>"
#creating an appservice plan and webapp
$rg = "rg-c1"
az group create -n $rg -l eastus
$appserviceplan = "aspc1"
az appservice plan create -g $rg -n $appserviceplan
az webapp create -g $rg -n wa-c1 -p $appserviceplan

#creating a VM
az vm create -n vm-c1 -g $rg --image Win2019Datacenter

#creating a cosmosdb
$cosmosdb = "cdb-c1"
az cosmosdb create -n $cosmosdb -g $rg 
#creating database and container in cosmosdb
$cosmosdatabase = "dbc1"
az cosmosdb database create --name $cosmosdb --resource-group $rg --db-name $cosmosdatabase
az cosmosdb sql container create --resource-group $rg --account-name $cosmosdb --database-name $cosmosdatabase --name collc1 --partition-key-path "/id"