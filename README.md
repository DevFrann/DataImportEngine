## Technologies used

Net6 - Framework
Newtonsoft.Json - Library for manage files in json format
YamlDotNet - Library for manage files in yaml format
FluentValidation - Library for validatations
Xunit - Library for testing
Moq - Library for resolve services as moqs
FluentAssertions - Library for testing asserts

## Run app locally
Console Command:
dotnet run capterra capterra.yaml
OR
dotnet run softwareadvice softwareadvice.json

## Architectural improvements
From my point of view, the best architecture that I would use for the management of importing products from different files would be to first enable a space in a Blob Storage where the files would be left.
Then I would create an Azure Function BlobTriggered that would be executed when a new file was deposited in the Storage and I would execute all the deserialization strategy that has been used in my test for the import of the products.
This way we would asynchronously automate the read process and avoid having to access the email to pick up the files.
The read / deserialization process could be extracted in a separate library to make it more accessible to different possible future product sources.

## Code in GitHub
- Repo Url => https://github.com/DevFrann/DataImportEngine
