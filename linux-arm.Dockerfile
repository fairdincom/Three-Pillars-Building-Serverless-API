# Get .NET SDK image
FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS builder

RUN mkdir /functions
COPY src/Demo.FunctionApp /functions

WORKDIR /functions
RUN dotnet build . -o output -r linux-arm

# Get Azure Function runtime image
FROM mcr.microsoft.com/azure-functions/dotnet:2.0-arm32v7 AS runtime

ENV AzureWebJobsScriptRoot=/home/site/wwwroot
ENV AzureFunctionsJobHost__Logging__Console__IsEnabled=true

ENV FUNCTIONS_WORKER_RUNTIME=dotnet
ENV OpenApi__Info__Version="2.0.0"
ENV OpenApi__Info__Title="Open API Sample on Azure Functions"
ENV OpenApi__Info__Description="A sample API that runs on Azure Functions 2.x using Open API specification."
ENV OpenApi__Info__TermsOfService="https://github.com/fairdincom/Three-Pillars-Building-Serverless-API"
ENV OpenApi__Info__Contact__Name="Aliencube Community"
ENV OpenApi__Info__Contact__Email="no-reply@fairdin.com"
ENV OpenApi__Info__Contact__Url="https://github.com/fairdincom/Three-Pillars-Building-Serverless-API/issues"
ENV OpenApi__Info__License__Name=MIT
ENV OpenApi__Info__License__Url="http://opensource.org/licenses/MIT"
ENV OpenApi__ApiKey=""

COPY --from=builder /functions/output /home/site/wwwroot
