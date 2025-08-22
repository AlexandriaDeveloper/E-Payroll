# E-Payroll

E-Payroll is a sample payroll application containing a .NET API and an Angular UI. The repository includes a Docker Compose stack to run the API, UI, and a SQL Server database locally.

## Contents
- `API/E-Payroll.API.Web` - .NET 9 Web API
- `UI/E-Payroll.UI` - Angular application (built with Angular CLI)
- `Infrastructure` / `Core` / `Application` - supporting projects
- `docker-compose.yml` - brings up the UI, API and DB for local development

## Prerequisites
- Docker Desktop (with WSL2 on Windows)
- (Optional for local dev) .NET SDK 9.x
- (Optional for local UI dev) Node 20 and npm, Angular CLI

## Quick start (recommended)
1. From the repository root, build and start services with Docker Compose:

```powershell
cd F:\Prog-Projects\E-Payroll
docker compose up -d --build
```

2. UI: Open http://localhost:8080
3. API: Accessible at http://localhost:5000 (HTTP) and https://localhost:5001 (HTTPS)
4. Database: SQL Server listens on host port 1433 (see `docker-compose.yml`).

## Local development (without Docker)
- API
  - Build: `dotnet build API/E-Payroll.API.Web/E-Payroll.API.Web.csproj`
  - Run: `dotnet run --project API/E-Payroll.API.Web/E-Payroll.API.Web.csproj`
- UI
  - Install: `cd UI/E-Payroll.UI; npm install`
  - Serve (dev): `ng serve --host 0.0.0.0`
  - Build (prod): `ng build --configuration production`

## Notes & Troubleshooting
- If you see the nginx welcome page instead of the Angular app on http://localhost:8080:
  - Hard-refresh the browser (Ctrl+F5) or use an incognito window to avoid cache issues.
  - Confirm the UI container contains the Angular files under `/usr/share/nginx/html` (index.html, main-*.js, polyfills-*.js).
  - Rebuild the UI image and restart the UI service: `docker compose build --no-cache e-payroll.ui && docker compose up -d e-payroll.ui`.

- Known code issue encountered during local debugging: some generated C# namespaces contained hyphens (e.g. `E-Payroll.Core.Domain`), which are invalid identifiers in C#. If you get many compiler errors (CS0116 / CS1513 / CS1514), search for `E-Payroll` in the C# files and replace the hyphen with an underscore (for example `E_Payroll.Core.Domain`) or restore the corrected files from the commit history.

## Contributing
- Create a feature branch off `main`.
- Open a pull request with a descriptive title and tests where appropriate.

## License
Add your license here. (This README was generated automatically.)
