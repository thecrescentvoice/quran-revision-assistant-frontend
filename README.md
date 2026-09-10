# Quran Revision Assistant — Frontend (ASP.NET Core MVC)

This repository contains a minimal ASP.NET Core MVC frontend scaffold that calls an existing Python backend API (e.g., POST /revise). The goal is to keep the Python business logic and provide a server-rendered Razor UI.

Quick start
1. Clone the repo:
   git clone https://github.com/thecrescentvoice/quran-revision-assistant-frontend.git
   cd quran-revision-assistant-frontend/Presentation
2. Restore and run:
   dotnet restore
   dotnet run

3. The app will start at https://localhost:5001 (or http://localhost:5000). Configure the Python API base URL in Presentation/appsettings.Development.json under PythonApi:BaseUrl, or set the environment variable:
   setx PythonApi__BaseUrl "http://localhost:8000"

4. Open the Revision page (root route) and submit text to call POST /revise on your Python backend.

Notes
- The typed HttpClient (Presentation/Services/PythonApiClient.cs) posts JSON to /revise and expects a JSON response with { "revisedText": "..." }.
- For production, secure your API keys/tokens using secrets or environment variables and call the Python service from server-side to avoid CORS.
