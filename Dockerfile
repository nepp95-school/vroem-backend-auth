# Base docker image
FROM mcr.microsoft.com/dotnet/sdk:6.0

# Working directory
WORKDIR /app

# Expose ports
EXPOSE 80
EXPOSE 443

# Environment variables
ENV ASPNETCORE_URLS "https://+:443;http://+:80"

# Copy files
COPY . .

# Get dependencies
RUN dotnet restore

# Build application
RUN dotnet publish "backend-auth.sln" -c Release -o /publish

# SSL
RUN dotnet dev-certs https --trust

# Entrypoint
ENTRYPOINT ["dotnet", "/publish/backend-auth.dll"]