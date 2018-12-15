#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 54526
EXPOSE 44320

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY ["ContactsBox.API/ContactsBox.API.csproj", "ContactsBox.API/"]
RUN dotnet restore "ContactsBox.API/ContactsBox.API.csproj"
COPY . .
WORKDIR "/src/ContactsBox.API"
RUN dotnet build "ContactsBox.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ContactsBox.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ContactsBox.API.dll"]