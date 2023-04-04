# Set variables
$resourceGroupName = 'rg-externconfigstore' # Set RG name
$serviceBusName = 'asb4938' # Set Service Bus Name
$serviceBusAccessPolicyName = 'RootManageSharedAccessKey' #default
$keyVaultName = 'kv4970' #Set vault name
$keyVaultSecretKey = 'ServiceBusPrimaryKey' #default

# Regenerate the Service Bus Primary Key
New-AzureRmServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $serviceBusName -Name $serviceBusAccessPolicyName -RegenerateKey PrimaryKey

# Get the newly regenerated Primary Key
$primaryKey = (Get-AzureRmServiceBusKey -ResourceGroupName $resourceGroupName -Namespace $serviceBusName -Name $serviceBusAccessPolicyName).PrimaryKey

# Convert the Primary Key to Secure String
$secureValue = ConvertTo-SecureString $primaryKey -AsPlainText -Force

# Update the Secret Value in the Key Vault
Set-AzureKeyVaultSecret -VaultName $keyVaultName -Name $keyVaultSecretKey -SecretValue $secureValue
