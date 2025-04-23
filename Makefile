# Makefile ─ coloque na raiz do projeto .NET
.PHONY: restore build run watch test clean publish \
        tool-manifest install-ef user-secrets-init ef-update \
        format lint

## Básico -----------------------------------------------------------
restore:
	@dotnet restore

build: restore
	@dotnet build --no-restore

run: build
	@dotnet run --no-build

dev:
	@dotnet watch run

test:
	@dotnet test --no-build

clean:
	@dotnet clean

publish: build
	@dotnet publish -c Release -o ./out

## Ferramentas & banco ---------------------------------------------
tool-manifest:
	@dotnet new tool-manifest            # cria .config/dotnet-tools.json local

install-ef:
	@dotnet tool install dotnet-ef       # instala Entity Framework CLI

user-secrets-init:
	@dotnet user-secrets init            # habilita segredos de desenvolvimento

ef-update:
	@dotnet ef database update           # aplica migrations ao banco

## Qualidade opcional ----------------------------------------------
format:
	@dotnet format                        # formata código

lint:
	@dotnet build -warnaserror            # trata warnings como erros
