#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 52148
EXPOSE 44348

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY ["ContactsBox.Service/ContactsBox.Service.csproj", "ContactsBox.Service/"]
RUN dotnet restore "ContactsBox.Service/ContactsBox.Service.csproj"
COPY . .
WORKDIR "/src/ContactsBox.Service"
RUN dotnet build "ContactsBox.Service.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ContactsBox.Service.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ContactsBox.Service.dll"]