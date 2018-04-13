FROM microsoft/dotnet

ADD . /app
WORKDIR /app/test/Veggerby.RubiksCube.Core.Tests
RUN dotnet --version
RUN dotnet restore
RUN dotnet build -c Release