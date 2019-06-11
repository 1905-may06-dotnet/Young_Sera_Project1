FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS buildDomain

WORKDIR /app


COPY PizzaBoxDomain/*.csproj ./
RUN dotnet restore

COPY PizzaBoxDomain ./

ARG config=Release

RUN dotnet build --no-restore -c ${config}

RUN dotnet publish --no-build -c ${config} -o out




FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS buildData

WORKDIR /app

COPY --from=buildDomain /app/out /PizzaBoxDomain

WORKDIR /PizzaBoxData

COPY PizzaBoxData/*.csproj ./
RUN dotnet restore

COPY PizzaBoxData ./

ARG config=Release

RUN dotnet build --no-restore -c ${config}

RUN dotnet publish --no-build -c ${config} -o out



FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS buildWeb

WORKDIR /app

COPY --from=buildDomain /app/out /PizzaBoxDomain
COPY --from=buildData /app/PizzaBoxData/out /PizzaBoxData

WORKDIR /PizzaBoxWeb

COPY PizzaBoxWeb/*.csproj ./
RUN dotenet restore

COPY PizzaBoxWeb ./

ARG config=Release

RUN dotnet build --no-restore -c ${config}

RUN dotnet publish --no-build -c ${config} -o out



FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS Deploy

WORKDIR /app

COPY --from=buildDomain /app/out /PizzaBoxData
COPY --from=buildData /app/out /PizzaBoxData
COPY --from=buildWeb /app/out /PizzaBoxWeb

WORKDIR /PizzaBoxWeb


ENTRYPOINT [ "dotnet", "PizzaBoxWeb.dll" ]